using System;
using AutoMapper;
using EGMS.BusinessAssociates.Domain;
using EGMS.BusinessAssociates.Query.ReadModels;
using Microsoft.Extensions.Configuration;

namespace EGMS.BusinessAssociates.Data.EF
{
    public class AutoMapperEF : Profile
    {
        public AutoMapperEF(IConfiguration configuration)
        {
            CreateMap<Associate, AssociateRM>()
                .ForMember(dst => dst.Id,
                    opt => opt.MapFrom(src => (int) src.Id))
                .ForMember(dst => dst.DUNSNumber,
                    opt => opt.MapFrom(src => src.DUNSNumber))
                .ForMember(dst => dst.LongName,
                    opt => opt.MapFrom(src => (string) src.LongName))
                .ForMember(dst => dst.ShortName,
                    opt => opt.MapFrom(src => (string) src.ShortName))
                .ForMember(dst => dst.AssociateType,
                    opt => opt.MapFrom(src => (int) src.AssociateType))
                .ForMember(dst => dst.IsActive,
                    opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dst => dst.IsDeactivating,
                    opt => opt.MapFrom(src => src.IsDeactivating))
                .ForMember(dst => dst.IsInternal,
                    opt => opt.MapFrom(src => src.IsInternal))
                .ForMember(dst => dst.IsParent,
                    opt => opt.MapFrom(src => src.IsParent))
                .ForMember(dst => dst.Status,
                    opt => opt.MapFrom(src => (int) src.Status));
        }
    }
}
