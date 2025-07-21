using VituraHealth.Domain.Entities;

namespace VituraHealth.Domain.Repositories
{
    public interface IPatientRespository
    {
        /// <summary>
        /// Get list of all patients.
        /// </summary>
        /// <returns>List of patients.</returns>
        public Task<IEnumerable<Patient>> GetAllPatientsAsync();
    }
}
