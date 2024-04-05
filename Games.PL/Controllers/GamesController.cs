using AutoMapper;
using GameOn.BLL.Interfaces;
using GameOn.PL.Helpers;
using Games.DAL.Data.Models;
using Games.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace Games.PL.Controllers
{
    public class GamesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GamesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var games = await _unitOfWork.GameRepository.GetAllAsync();
            var GameVM = _mapper.Map<IEnumerable<GameViewModel>>(games);
            return View(GameVM);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(GameViewModel gameVM)
        {
            if (ModelState.IsValid)
            {
                gameVM.CoverName = DocumentSettings.UploadFile(gameVM.Cover, "Images");
                var game = _mapper.Map<Game>(gameVM);
                foreach (var deviceId in gameVM.SelectedDevices)
                {
                    var device = await _unitOfWork.DeviceRepository.GetAsync(deviceId);
                    if (device != null)
                    {
                        game.Devices.Add(device);
                    }
                }
                await _unitOfWork.GameRepository.AddAsync(game);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError(String.Empty, "Something went wrong...");
            return View(gameVM);
        }
        [HttpGet]
        public async Task<IActionResult> Update([FromRoute] int Id)
        {
            var game = await _unitOfWork.GameRepository.GetAsync(Id);
            var gameVM = _mapper.Map<GameViewModel>(game);
            foreach (var devices in game.Devices)
            {
                var device = await _unitOfWork.DeviceRepository.GetAsync(devices.Id);
                if (device != null)
                {
                    gameVM.SelectedDevices.Add(device.Id);
                }
            }
            return View(gameVM);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int Id, GameViewModel gameVM)
        {
            if (Id != gameVM.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                var game = await _unitOfWork.GameRepository.GetAsync(gameVM.Id);

                foreach (var device in game.Devices)
                {
                    game.Devices.Remove(device);
                }
                await _unitOfWork.CompleteAsync();
                try
                {
                    if (gameVM.Cover is not null)
                    {
                        if (!string.IsNullOrEmpty(game.CoverName))
                            DocumentSettings.DeleteFile(game.CoverName, "Images");

                        gameVM.CoverName = DocumentSettings.UploadFile(gameVM.Cover, "Images");
                    }
                    else
                        gameVM.CoverName = game.CoverName;
                    _unitOfWork.GameRepository.DetachEntity(game);
                    var newGame = _mapper.Map<Game>(gameVM);
                    foreach (var ids in gameVM.SelectedDevices)
                    {
                        var device = await _unitOfWork.DeviceRepository.GetAsync(ids);
                        if (device != null)
                        {
                            newGame.Devices.Add(device);
                        }
                    }
                    _unitOfWork.GameRepository.Update(newGame);
                    await _unitOfWork.CompleteAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {

                    ModelState.AddModelError(string.Empty, e.Message);
                }
            }

            return View(gameVM);
        }
        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var game = await _unitOfWork.GameRepository.GetAsync(id);
            var gameVM = _mapper.Map<GameViewModel>(game);
            return View(gameVM);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromRoute] int id, GameViewModel gameVM)
        {
            if (id != gameVM.Id)
            {
                return BadRequest();
            }
            var game = await _unitOfWork.GameRepository.GetAsync(gameVM.Id);
            if (game is not null)
            {
                gameVM.CoverName = game.CoverName;
                _unitOfWork.GameRepository.Delete(game);
                var result = await _unitOfWork.CompleteAsync();
                if (result > 0)
                {
                    DocumentSettings.DeleteFile(gameVM.CoverName, "Images");
                    return RedirectToAction(nameof(Index));
                }

            }
            ModelState.AddModelError(string.Empty, "Somthing Went Wrong..!");
            return View(gameVM);
        }
    }
}
