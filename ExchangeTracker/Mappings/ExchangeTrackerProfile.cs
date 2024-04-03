using AutoMapper;
using ExchangeTracker.DAL.DBO;
using ExchangeTracker.Models;

namespace ExchangeTracker.Mappings
{
    public class ExchangeTrackerProfile : Profile
    {
        public ExchangeTrackerProfile()
        {
            CreateMap<User, UserModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.Created_At));

            CreateMap<Currency, CurrencyModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Abbreviation, opt => opt.MapFrom(src => src.Abbreviation));

            CreateMap<CurrencyEntry, CurrencyEntryModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Id_Currency, opt => opt.MapFrom(src => src.Id_Currency))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value));
        }
    }
}
