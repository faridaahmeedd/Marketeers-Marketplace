using AutoMapper;
using MarketeersMarketplace.Models;
using MarketeersMarketplace.ViewModels;
using System.Globalization;

namespace MarketeersMarketplace.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Talent, TalentCardVM>()
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FName} {src.LName}"))
             .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
             .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.Images.Select(i => i.Path).FirstOrDefault()));
            CreateMap<TalentCardVM, Talent>();

            CreateMap<Talent, TalentProfileVM>()
             .ForMember(dest => dest.SelectedCategory, opt => opt.MapFrom(src => src.Category.Name))
             .ForMember(dest => dest.ExistingImageUrls, opt => opt.MapFrom(src => src.Images.Select(i => i.Path).ToList()));
            CreateMap<TalentProfileVM, Talent>();
        }
    }
}