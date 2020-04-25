﻿using AutoMapper;
using EGMS.BusinessAssociates.Domain;
using EGMS.BusinessAssociates.Query.ReadModels;
using Microsoft.Extensions.Configuration;

namespace EGMS.BusinessAssociates.Data.EF.InMemory
{
    public class AutoMapperEF : Profile
    {
        // ReSharper disable once UnusedParameter.Local
        public AutoMapperEF(IConfiguration configuration)
        {
            CreateMap<Associate, AssociateRM>()
                .ForMember(dst => dst.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.DUNSNumber,
                    opt => opt.MapFrom(src => src.DUNSNumber))
                .ForMember(dst => dst.LongName,
                    opt => opt.MapFrom(src => (string) src.LongName))
                .ForMember(dst => dst.ShortName,
                    opt => opt.MapFrom(src => (string) src.ShortName))
                .ForMember(dst => dst.AssociateTypeId,
                    opt => opt.MapFrom(src => src.AssociateTypeId))
                .ForMember(dst => dst.IsDeactivating,
                    opt => opt.MapFrom(src => src.IsDeactivating))
                .ForMember(dst => dst.IsInternal,
                    opt => opt.MapFrom(src => src.IsInternal))
                .ForMember(dst => dst.IsParent,
                    opt => opt.MapFrom(src => src.IsParent))
                .ForMember(dst => dst.StatusCodeId,
                    opt => opt.MapFrom(src => src.StatusCodeId));


            CreateMap<OperatingContext, OperatingContextRM>()
                .ForMember(dst => dst.ActingBAType,
                    opt => opt.MapFrom(src => src.ActingBAType))
                .ForMember(dst => dst.CertificationId,
                    opt => opt.MapFrom(src => src.CertificationId.Value))
                .ForMember(dst => dst.FacilityId,
                    opt => opt.MapFrom(src => src.FacilityId.Value))
                .ForMember(dst => dst.IsDeactivating,
                    opt => opt.MapFrom(src => src.IsDeactivating))
                .ForMember(dst => dst.LegacyId,
                    opt => opt.MapFrom(src => src.LegacyId))
                .ForMember(dst => dst.OperatingContextType,
                    opt => opt.MapFrom(src => src.OperatingContextType))
                .ForMember(dst => dst.ProviderType,
                    opt => opt.MapFrom(src => src.ProviderType))
                .ForMember(dst => dst.StartDate,
                    opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dst => dst.Status,
                    opt => opt.MapFrom(src => src.Status))
                .ForMember(dst => dst.ThirdPartySupplierId,
                    opt => opt.MapFrom(src => src.ThirdPartySupplierId));
        }
    }
}
