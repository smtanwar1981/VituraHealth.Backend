namespace VituraHealth.Application.DTOs
{
    public class PrescriptionBase
    {
        /// <summary>
        /// Gets or sets PatientId
        /// </summary>
        public int PatientId { get; set; }

        /// <summary>
        /// Gets or sets Drug Name
        /// </summary>
        public string DrugName { get; set; }

        /// <summary>
        /// Gets or sets Dosage
        /// </summary>
        public string Dosage { get; set; }

        /// <summary>
        /// Gets or sets Date of Prescription
        /// </summary>
        public string DatePrescribed { get; set; }
    }
}
