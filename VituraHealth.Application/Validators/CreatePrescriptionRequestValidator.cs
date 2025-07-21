using FluentValidation;
using VituraHealth.Application.DTOs;

namespace VituraHealth.Application.Validators
{
    public class CreatePrescriptionRequestValidator : AbstractValidator<CreatePrescriptionRequest>
    {
        public CreatePrescriptionRequestValidator()
        {
            RuleFor(x => x.PatientId)
                .GreaterThan(0).WithMessage("PatientId should not be empty or 0");

            RuleFor(x => x.DrugName)
                .NotEmpty().WithMessage("DrugName is required.")
                .Must(val => val?.ToLowerInvariant() != "string").WithMessage("DrugName cannot be a placeholder.")
                .MinimumLength(10).WithMessage("DrugName cannot be less than 10 characters.")
                .MaximumLength(200).WithMessage("DrugName cannot exceed 200 characters.");

            RuleFor(x => x.Dosage)
                .NotEmpty().WithMessage("Dosage is required.")
                .Must(val => val?.ToLowerInvariant() != "string").WithMessage("Dosage cannot be a placeholder.");

            RuleFor(x => x.DatePrescribed)
                .NotEmpty().WithMessage("DatePrescribed is required.")
                .Must(val => val?.ToLowerInvariant() != "string").WithMessage("DatePrescribed cannot be a placeholder.");
        }
    }
}
