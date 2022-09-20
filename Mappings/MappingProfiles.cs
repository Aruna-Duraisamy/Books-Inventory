using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Books_Inventory.Data.Models;

namespace Books_Inventory.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book, BookDto>()
            .ForMember(dest => dest.Rate, opt =>
            {
                opt.PreCondition(src => src.IsRead);
                opt.MapFrom(src => src.IsRead ? src.Rate : null);
            })
            .ForMember(dest => dest.DateRead, opt =>
            {
                opt.PreCondition(src => src.IsRead);
                opt.MapFrom(src => src.IsRead ? src.DateRead : null);
            }).ReverseMap();
        }
    }
}