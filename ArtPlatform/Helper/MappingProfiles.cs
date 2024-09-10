using ArtPlatform.Models;
using ArtPlatform.ViewModels;
using AutoMapper;
using System.Globalization;

namespace ServicesApp.Helper
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
            CreateMap<Talent, TalentCardVM>()
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FName} {src.LName}"))
             .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<TalentCardVM, Talent>();

            CreateMap<Talent, TalentProfileVM>()
             .ForMember(dest => dest.SelectedCategory, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<TalentProfileVM, Talent>();
        }
	}
}