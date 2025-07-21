using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using VituraHealth.Application.DTOs;
using VituraHealth.Application.Interfaces;

namespace VituraHealth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController(
        IPrescriptionService _prescriptionService, 
        ILogger<PrescriptionsController> _logger,
        IValidator<CreatePrescriptionRequest> _validator) : ControllerBase
    {
        /// <summary>
        /// Retrieves all prescriptions in the system.
        /// </summary>
        /// <returns>A list of prescriptions.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PrescriptionDTO>>> GetPrescriptions()
        {
            _logger.LogInformation("Fetching list of all prescriptions");
            var prescriptions = await _prescriptionService.GetPrescriptionListAsync();
            return Ok(prescriptions);
        }

        /// <summary>
        /// Create new prescription.
        /// </summary>
        /// <param name="request">Request object to create new prescription.</param>
        /// <returns>Newly create prescription in the system.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes("application/json")]
        public async Task<ActionResult<PrescriptionDTO>> AddPrescription(CreatePrescriptionRequest request)
        {
            _logger.LogInformation("Validating new prescription request.");
            var validateRequestResult = await _validator.ValidateAsync(request);

            if (!validateRequestResult.IsValid)
            {
                var errorMessages = validateRequestResult.Errors.Select(x => x.ErrorMessage);
                _logger.LogInformation("Invalid request due to - {erroMessages}", errorMessages);
                return BadRequest(errorMessages);
            }

            _logger.LogInformation("Adding new prescription");
            var prescription = await _prescriptionService.AddPrescriptionAsync(request);
            return Ok(prescription);
        }
    }
}
