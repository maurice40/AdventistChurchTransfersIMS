using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACTMS.Models;
using AutoMapper;
using ACTMS.Dtos;

namespace ACTMS.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            Mapper.CreateMap<Church, ChurchDto>();
            Mapper.CreateMap<ChurchDto, Church>();
            Mapper.CreateMap<Province, ProvinceDto>();
            Mapper.CreateMap<ProvinceDto, Province>();

            // Dto to Domain
           
        }
    }
}