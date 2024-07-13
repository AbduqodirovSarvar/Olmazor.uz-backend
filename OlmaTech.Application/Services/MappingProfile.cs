using AutoMapper;
using OlmaTech.Application.Models;
using OlmaTech.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Enum, EnumViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Convert.ToInt32(src)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom<EnumNameResolver<Enum>>());

            /*CreateMap<Enum, EnumViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Convert.ToInt32(src)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(z => z.ToString()));*/
        }
    }
}
