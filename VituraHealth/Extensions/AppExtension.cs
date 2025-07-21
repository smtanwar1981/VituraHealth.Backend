using VituraHealth.Api.Middleware;
using VituraHealth.Application.DTOs;
using VituraHealth.Application.Interfaces;

namespace VituraHealth.Api.Extensions
{
    public static class AppExtension
    {
        public static WebApplication RegisterAppServices(this WebApplication app)
        {
            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.RegisterPrescriptionEndpoints();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            //app.MapControllers();

            app.UseCors();

            return app;
        }

        private static WebApplication RegisterPrescriptionEndpoints(this WebApplication app)
        {
            app.MapGet("/api/prescriptions", async (
                IPrescriptionService prescriptionService,
                ILogger<Program> logger) =>
            {
                logger.LogInformation("Fetching list of all prescriptions");
                var prescriptions = await prescriptionService.GetPrescriptionListAsync();
                return Results.Ok(prescriptions);
            }).Produces<List<PrescriptionDTO>>(StatusCodes.Status200OK);

            return app;
        }
    }
}
