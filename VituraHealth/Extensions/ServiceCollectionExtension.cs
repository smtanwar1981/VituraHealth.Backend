using FluentValidation;
using Microsoft.EntityFrameworkCore;
using VituraHealth.Application.DTOs;
using VituraHealth.Application.Interfaces;
using VituraHealth.Application.MappingProfiles;
using VituraHealth.Application.Services;
using VituraHealth.Application.Validators;
using VituraHealth.Domain.Repositories;
using VituraHealth.Infrastructure.Data;
using VituraHealth.Infrastructure.Repositories;

namespace VituraHealth.Api.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            /********** CORS Configuration **********/
            services.AddCors(options => 
            {
                options.AddPolicy(name: "VirtualHealthAllowOrigin", policy => { 
                    policy
                        .WithOrigins("http://localhost:5173")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

            /********** Add in memory database context **********/
            services.AddDbContext<VituraHealthDbContext>(options =>
            {
                options.UseInMemoryDatabase("VituraHealthDb");
            });

            /********** Seeding Data **********/
            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<VituraHealthDbContext>();
                VituraHealthDataSeeder.SeedData(context);
            }

            /********** Registring Dependencies **********/
            services
                .AddScoped<IPatientRespository, PatientRepository>()
                .AddScoped<IPrescriptionRepository, PrescriptionRepository>()
                .AddScoped<IPrescriptionService, PrescriptionService>()
                .AddScoped<IPatientService, PatientService>()
                .AddAutoMapper(typeof(Program).Assembly, typeof(VirtualHealthMappingProfile).Assembly);

            services.AddControllers();

            services.AddScoped<IValidator<CreatePrescriptionRequest>, CreatePrescriptionRequestValidator>();

            /********** Swagger Configuration **********/
            services.AddEndpointsApiExplorer().AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Virtua Health",
                    Description = "A Virtua Health Microservice for Patients and Prescriptions queries"
                });
            });

            return services;
        }
    }
}
