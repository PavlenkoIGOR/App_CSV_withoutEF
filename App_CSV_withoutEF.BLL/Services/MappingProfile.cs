using App_CSV_withoutEF.BLL.Services;
using App_CSV_withoutEF.Data.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_CSV_withoutEF.BLL.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, CSV_User>()
                .ForMember(dest => dest.UserId_Reader, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.UserName_Reader, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.UserLastname_Reader, opt => opt.MapFrom(src => src.UserLastname))
                .ForMember(dest => dest.UserSurname_Reader, opt => opt.MapFrom(src => src.UserSurname))
                .ForMember(dest => dest.BirthDate_Reader, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.PassportSerial_Reader, opt => opt.MapFrom(src => src.PassportSerial))
                .ForMember(dest => dest.PassportNumber_Reader, opt => opt.MapFrom(src => src.PassportNumber))
                .ForMember(dest => dest.UserOrganizationId_Reader, opt => opt.MapFrom(src => src.UserOrganizationId));

            CreateMap<Organization, CSV_Organization>()
                .ForMember(dest => dest.OrgId_Reader, opt => opt.MapFrom(src => src.OrgId))
                .ForMember(dest => dest.Title_ORG_Reader, opt => opt.MapFrom(src => src.Title_ORG))
                .ForMember(dest => dest.INN_ORG_Reader, opt => opt.MapFrom(src => src.INN_ORG))
                .ForMember(dest => dest.UrAddress_ORG_Reader, opt => opt.MapFrom(src => src.UrAddress_ORG))
                .ForMember(dest => dest.FactAddress_ORG_Reader, opt => opt.MapFrom(src => src.FactAddress_ORG));
        }
    }
}