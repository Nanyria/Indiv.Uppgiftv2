using AutoMapper;
using IndUppClassModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndProjModels
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<AppointmentDTO, Appointment>()
         .ForMember(dest => dest.Customer, opt => opt.Ignore())
         .ForMember(dest => dest.Changes, opt => opt.Ignore());

            CreateMap<Appointment, AppointmentDTO>()
                .ForMember(dest => dest.CustomerID, opt => opt.MapFrom(src => src.CustomerID))
                // Explicitly ignore the Changes collection
                .ForMember(dest => dest.Changes, opt => opt.Ignore());


            CreateMap<AppointmentChangeDTO, AppointmentChanges>();
            CreateMap<AppointmentChanges, AppointmentChangeDTO>()
    .ForMember(dest => dest.AppointmentID, opt => opt.MapFrom(src => src.AppointmentID))
    .ReverseMap();
        }
    }
}
