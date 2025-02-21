using AutoMapper;
using PatientManagement.Application.DTOs;
using PatientManagement.Domain.Entities;

namespace PatientManagement.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, PatientDto>().ReverseMap();
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
        }
    }
}
