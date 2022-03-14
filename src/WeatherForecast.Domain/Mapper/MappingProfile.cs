using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Domain.Commands;

namespace WeatherForecast.Domain.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddWeatherForecastCommand, Entities.WeatherForecast>()
               .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateTime.Now))
               .ForMember(dest => dest.TemperatureF, opt => opt.MapFrom(src => 32 + (int)(src.TemperatureC / 0.5556)))
               .ReverseMap();

            CreateMap<PutWeatherForecastCommand, Entities.WeatherForecast>()
               .ForMember(dest => dest.TemperatureF, opt => opt.MapFrom(src => 32 + (int)(src.TemperatureC / 0.5556)))
               .ReverseMap();
        }
    }
}
