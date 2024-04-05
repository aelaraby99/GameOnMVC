using Games.DAL.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Games.PL.ViewModels
{
    public class GameViewModel
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(2500)]
        public string Description { get; set; }
        public IFormFile? Cover { get; set; }
        public string? CoverName { get; set; }
        [Display(Name = "Game Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        [Display(Name = "Supported Devices")]
        public List<int> SelectedDevices { get; set; } = new List<int>();
        [Display(Name="Supported Devices")]
        public ICollection<Device>? Devices { get; set; } = new HashSet<Device>();

    }
}
