namespace VituraHealth.Domain.Entities
{
    public class Patient
    {
        /// <summary>
        /// Gets or sets Patient Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets FullName
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets Date of Birth for Patient
        /// </summary>
        public string DateOfBirth { get; set; }
    }
}
