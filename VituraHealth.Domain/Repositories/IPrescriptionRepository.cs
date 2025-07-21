using VituraHealth.Domain.Entities;

namespace VituraHealth.Domain.Repositories
{
    public interface IPrescriptionRepository
    {
        /// <summary>
        /// Get list of all prescriptions.
        /// </summary>
        /// <returns>List of prescriptions.</returns>
        public Task<IEnumerable<Prescription>> GetAllPrescriptionsAsync();

        /// <summary>
        /// Add a prescription.
        /// </summary>
        /// <param name="prescription">Prescription model.</param>
        public Task AddPrescriptionAsync(Prescription prescription);
    }
}
