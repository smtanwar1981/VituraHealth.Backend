using AutoMapper;
using VituraHealth.Application.DTOs;
using VituraHealth.Application.Interfaces;
using VituraHealth.Domain.Entities;
using VituraHealth.Domain.Repositories;

namespace VituraHealth.Application.Services
{
    public class PrescriptionService(IPrescriptionRepository _prescriptionRepository, IMapper _mapper) : IPrescriptionService
    {
        /// <inheritdoc />
        public async Task<PrescriptionDTO> AddPrescriptionAsync(CreatePrescriptionRequest request)
        {
            var prescription = _mapper.Map<Prescription>(request);
            prescription.Id = new Random().Next(1000, 9999);
            prescription.DatePrescribed = DateTime.Today.ToString("yyyy-MM-dd");
            await _prescriptionRepository.AddPrescriptionAsync(prescription);
            return _mapper.Map<PrescriptionDTO>(prescription);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<PrescriptionDTO>> GetPrescriptionListAsync()
        {
            var prescriptions = await _prescriptionRepository.GetAllPrescriptionsAsync();
            return _mapper.Map<IEnumerable<PrescriptionDTO>>(prescriptions);
        }
    }
}
