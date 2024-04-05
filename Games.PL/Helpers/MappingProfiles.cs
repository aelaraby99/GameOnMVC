using AutoMapper;
using Games.DAL.Data.Models;
using Games.PL.ViewModels;

namespace GameOn.PL.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Game, GameViewModel>().ReverseMap();
                
            //CreateMap<Category, CategoryViewModel>().ReverseMap();

        }
    }
}
