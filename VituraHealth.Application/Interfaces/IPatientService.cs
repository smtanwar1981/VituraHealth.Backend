using VituraHealth.Application.DTOs;

namespace VituraHealth.Application.Interfaces
{
    public interface IPatientService
    {
        /// <summary>
        /// Get list of all patients.
        /// </summary>
        /// <returns>list of Patient dto object</returns>
        public Task<IEnumerable<PatientDTO>> GetAllPatientsAsync();
    }
}
