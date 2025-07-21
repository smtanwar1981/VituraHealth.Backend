using AutoMapper;
using VituraHealth.Application.DTOs;
using VituraHealth.Domain.Entities;

namespace VituraHealth.Application.MappingProfiles
{
    public class VirtualHealthMappingProfile : Profile
    {
        public VirtualHealthMappingProfile()
        {
            CreateMap<Prescription, PrescriptionDTO>();
            CreateMap<Patient, PatientDTO>();   
            CreateMap<CreatePrescriptionRequest, Prescription>();
        }
    }
}
