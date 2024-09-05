﻿using ArtPlatform.Models;
using ArtPlatform.ViewModels;
using AutoMapper;
using System.Globalization;

namespace ServicesApp.Helper
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
            CreateMap<Talent, TalentVM>()
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FName} {src.LName}"))
             .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<TalentVM, Talent>();

            //CreateMap<RegistrationDto, Customer>();
            //CreateMap<GetCustomerDto, RegistrationDto>();
            //CreateMap<Provider, GetProviderDto>();
            //CreateMap<PostProviderDto, Provider>();
            //CreateMap<RegistrationDto, Provider>();
            //CreateMap<GetProviderDto, RegistrationDto>();
            //CreateMap<RegistrationDto, Admin>();
            //CreateMap<Admin, RegistrationDto>();
            //CreateMap<AppUser, RegistrationDto>();
            //CreateMap<RegistrationDto, AppUser>();

            //         CreateMap<Category, CategoryDto>();
            //CreateMap<CategoryDto, Category>();
            //CreateMap<Subcategory, SubcategoryDto>()
            //	.ForMember(dest => dest.MinFeesAr, opt => opt.MapFrom(src => ConvertIntToArabic(src.MinFeesEn)))
            //	.ForMember(dest => dest.MaxFeesAr, opt => opt.MapFrom(src => ConvertIntToArabic(src.MaxFeesEn))
            //	);
            //CreateMap<SubcategoryDto, Subcategory>();

            //CreateMap<Review, GetReviewDto>();
            //CreateMap<PostReviewDto, Review>();
            //CreateMap<Report, GetReportDto>();
            //CreateMap<PostReportDto, Report>();

            //CreateMap<ServiceRequest, GetServiceRequestDto>()
            //	.ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Customer.Id))
            //             .ForMember(dest => dest.CustomerPhoneNumber, opt => opt.MapFrom(src => src.Customer.MobileNumber ))
            //             .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => $"{src.Customer.FName} {src.Customer.LName}"))
            //	.ForMember(dest => dest.SubCategoryNameAr, opt => opt.MapFrom(src => src.Subcategory.NameAr))
            //             .ForMember(dest => dest.SubCategoryNameEn, opt => opt.MapFrom(src => src.Subcategory.NameEn)
            //             );
            //CreateMap<PostServiceRequestDto, ServiceRequest>();

            //CreateMap<ServiceOffer, GetServiceOfferDto>()
            //	.ForMember(dest => dest.ProviderId, opt => opt.MapFrom(src => src.Provider != null ? src.Provider.Id : ""))
            //	.ForMember(dest => dest.ProviderName, opt => opt.MapFrom(src => src.Provider != null ? $"{src.Provider.FName} {src.Provider.LName}" : "Unknown"))
            //	.ForMember(dest => dest.RequestId, opt => opt.MapFrom(src => src.Request.Id))
            //	.ForMember(dest => dest.Duration, opt => opt.MapFrom(src => ConvertTimeToString(src.Duration)));
            //CreateMap<PostServiceOfferDto, ServiceOffer>()
            //	.ForMember(dest => dest.Duration, opt => opt.MapFrom(src => ConvertStringToTime(src.Duration)));

            //CreateMap<Image, ImageDto>();
            //CreateMap<ImageDto, Image>();

            //CreateMap<TimeSlot, TimeSlotDto>()
            //	.ForMember(dest => dest.Date, opt => opt.MapFrom(src => ConvertDateToString(src.Date)))
            //	.ForMember(dest => dest.FromTime, opt => opt.MapFrom(src => ConvertTimeToString(src.FromTime)));
            //CreateMap<TimeSlotDto, TimeSlot>()
            //	.ForMember(dest => dest.Date, opt => opt.MapFrom(src => ConvertStringToDate(src.Date)))
            //	.ForMember(dest => dest.FromTime, opt => opt.MapFrom(src => ConvertStringToTime(src.FromTime)));
        }


		//private TimeOnly ConvertStringToTime(string time)
		//{
		//	DateTime result;
		//	return DateTime.TryParse(DateOnly.MinValue + " " + time, out result)
		//		? TimeOnly.FromDateTime(result)
		//		: TimeOnly.MinValue;
		//}
		//private DateOnly ConvertStringToDate(string date)
		//{
		//	DateTime result;
		//	return DateTime.TryParse(date + " " + TimeOnly.MinValue, out result)
		//		? DateOnly.FromDateTime(result.Date)
		//		: DateOnly.MinValue;
		//}

		//private string ConvertTimeToString(TimeOnly time)
		//{
		//	return time.ToString("HH:mm");
		//}
		//private string ConvertDateToString(DateOnly date)
		//{
		//	return date.ToString("yyyy-M-d");
		//}

		//private string ConvertIntToArabic(int number)
		//{
		//	return string.Join("", number.ToString().Select(x => CultureInfo.GetCultureInfo("ar-lb").NumberFormat.NativeDigits[int.Parse(x.ToString())]));
		//}
	}
}