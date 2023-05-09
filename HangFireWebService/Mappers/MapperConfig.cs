using AutoMapper;
using HangFireWebService.DB.WBC_DB;
using HangFireWebService.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HangFireWebService.Mappers
{
    public static class MapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(
               cfg =>
               {
                   cfg.CreateMap<so_binnacle_visit, VisitDto>()
                   .ForMember(dest => dest.BinnacleVisitId, opt => opt.MapFrom(src => src.binnacleId))
                   .ForMember(dest => dest.BranchCode, opt => opt.MapFrom(src => src.so_user.so_branch.code))
                   .ForMember(dest => dest.UserCode, opt => opt.MapFrom(src => src.so_user.code))
                   .ForMember(dest => dest.CustomerCode, opt => opt.MapFrom(src => src.so_customer.code))
                   .ForMember(dest => dest.Figura, opt => opt.MapFrom(src => (src.so_user.type == 0 ? "Preventa" : "Reparto" )))
                   .ForMember(dest => dest.UserType, opt => opt.MapFrom(src => src.so_user.type));                   
               });
        }
    }
}