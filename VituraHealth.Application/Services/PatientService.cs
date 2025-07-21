using AutoMapper;
using VituraHealth.Application.DTOs;
using VituraHealth.Application.Interfaces;
using VituraHealth.Domain.Repositories;

namespace VituraHealth.Application.Services
{
    public class PatientService(IPatientRespository _patientRepository, IMapper _mapper) : IPatientService
    {
        /// <inheritdoc />
        public async Task<IEnumerable<PatientDTO>> GetAllPatientsAsync()
        {
            var patients = await _patientRepository.GetAllPatientsAsync();
            return _mapper.Map<IEnumerable<PatientDTO>>(patients);
        }
    }
}
