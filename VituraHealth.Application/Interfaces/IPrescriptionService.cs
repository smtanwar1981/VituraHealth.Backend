using VituraHealth.Application.DTOs;

namespace VituraHealth.Application.Interfaces
{
    public interface IPrescriptionService
    {
        /// <summary>
        /// Get list of all prescriptions.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<PrescriptionDTO>> GetPrescriptionListAsync();

        /// <summary>
        /// Add new prescription.
        /// </summary>
        /// <param name="prescription">list of Prescription dto object</param>
        /// <returns></returns>
        public Task<PrescriptionDTO> AddPrescriptionAsync(CreatePrescriptionRequest prescription);
    }
}
