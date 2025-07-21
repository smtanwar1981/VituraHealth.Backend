using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using VituraHealth.Application.DTOs;
using VituraHealth.Application.Interfaces;

namespace VituraHealth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class PatientsController(IPatientService _patientService, ILogger<PatientsController> _logger) : ControllerBase
    {
        /// <summary>
        /// Retrieves all patients in the system.
        /// </summary>
        /// <returns>A list of patients.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PatientDTO>>> GetPatients()
        {
            _logger.LogInformation("Fetching list of all patients");
            var patients = await _patientService.GetAllPatientsAsync();
            return Ok(patients);
        }
    }
}
