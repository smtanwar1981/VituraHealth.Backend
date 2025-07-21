﻿using System.Text.Json;
using VituraHealth.Domain.Entities;

namespace VituraHealth.Infrastructure.Data
{
    public static class VituraHealthDataSeeder
    {
        public static void SeedData(VituraHealthDbContext context)
        { 
            if(!context.Prescriptions.Any()) 
            {
                var prescriptionsJsonData = @"
                    [
                      {
                        ""id"": 1001,
                        ""patientId"": 1,
                        ""drugName"": ""Amoxicillin"",
                        ""dosage"": ""500mg"",
                        ""datePrescribed"": ""2024-12-01""
                      },
                      {
                        ""id"": 1002,
                        ""patientId"": 3,
                        ""drugName"": ""Ibuprofen"",
                        ""dosage"": ""200mg"",
                        ""datePrescribed"": ""2024-12-03""
                      },
                      {
                        ""id"": 1003,
                        ""patientId"": 2,
                        ""drugName"": ""Sertraline"",
                        ""dosage"": ""50mg"",
                        ""datePrescribed"": ""2025-01-15""
                      },
                      {
                        ""id"": 1004,
                        ""patientId"": 4,
                        ""drugName"": ""Paracetamol"",
                        ""dosage"": ""500mg"",
                        ""datePrescribed"": ""2025-02-01""
                      },
                      {
                        ""id"": 1005,
                        ""patientId"": 5,
                        ""drugName"": ""Metformin"",
                        ""dosage"": ""850mg"",
                        ""datePrescribed"": ""2025-02-08""
                      },
                      {
                        ""id"": 1006,
                        ""patientId"": 6,
                        ""drugName"": ""Lisinopril"",
                        ""dosage"": ""10mg"",
                        ""datePrescribed"": ""2025-02-15""
                      },
                      {
                        ""id"": 1007,
                        ""patientId"": 7,
                        ""drugName"": ""Atorvastatin"",
                        ""dosage"": ""20mg"",
                        ""datePrescribed"": ""2025-03-01""
                      },
                      {
                        ""id"": 1008,
                        ""patientId"": 8,
                        ""drugName"": ""Omeprazole"",
                        ""dosage"": ""40mg"",
                        ""datePrescribed"": ""2025-03-05""
                      },
                      {
                        ""id"": 1009,
                        ""patientId"": 9,
                        ""drugName"": ""Simvastatin"",
                        ""dosage"": ""10mg"",
                        ""datePrescribed"": ""2025-03-10""
                      },
                      {
                        ""id"": 1010,
                        ""patientId"": 10,
                        ""drugName"": ""Losartan"",
                        ""dosage"": ""50mg"",
                        ""datePrescribed"": ""2025-03-20""
                      },
                      {
                        ""id"": 1011,
                        ""patientId"": 1,
                        ""drugName"": ""Levothyroxine"",
                        ""dosage"": ""100mcg"",
                        ""datePrescribed"": ""2025-03-25""
                      },
                      {
                        ""id"": 1012,
                        ""patientId"": 2,
                        ""drugName"": ""Zoloft"",
                        ""dosage"": ""100mg"",
                        ""datePrescribed"": ""2025-03-28""
                      },
                      {
                        ""id"": 1013,
                        ""patientId"": 3,
                        ""drugName"": ""Melatonin"",
                        ""dosage"": ""3mg"",
                        ""datePrescribed"": ""2025-04-01""
                      },
                      {
                        ""id"": 1014,
                        ""patientId"": 4,
                        ""drugName"": ""Amlodipine"",
                        ""dosage"": ""5mg"",
                        ""datePrescribed"": ""2025-04-04""
                      },
                      {
                        ""id"": 1015,
                        ""patientId"": 5,
                        ""drugName"": ""Prednisone"",
                        ""dosage"": ""20mg"",
                        ""datePrescribed"": ""2025-04-10""
                      },
                      {
                        ""id"": 1016,
                        ""patientId"": 6,
                        ""drugName"": ""Gabapentin"",
                        ""dosage"": ""300mg"",
                        ""datePrescribed"": ""2025-04-15""
                      },
                      {
                        ""id"": 1017,
                        ""patientId"": 7,
                        ""drugName"": ""Clopidogrel"",
                        ""dosage"": ""75mg"",
                        ""datePrescribed"": ""2025-04-20""
                      },
                      {
                        ""id"": 1018,
                        ""patientId"": 8,
                        ""drugName"": ""Hydrochlorothiazide"",
                        ""dosage"": ""25mg"",
                        ""datePrescribed"": ""2025-04-25""
                      },
                      {
                        ""id"": 1019,
                        ""patientId"": 9,
                        ""drugName"": ""Escitalopram"",
                        ""dosage"": ""10mg"",
                        ""datePrescribed"": ""2025-04-30""
                      },
                      {
                        ""id"": 1020,
                        ""patientId"": 10,
                        ""drugName"": ""Bupropion"",
                        ""dosage"": ""150mg"",
                        ""datePrescribed"": ""2025-05-01""
                      }
                    ]
                ";
                var prescriptions = JsonSerializer.Deserialize<List<Prescription>>(prescriptionsJsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (prescriptions != null)
                { 
                    context.Prescriptions.AddRange(prescriptions);
                    context.SaveChanges();
                }
            }

            if (!context.Patients.Any())
            {
                var patientsJsonData = @"
                        [
                            {
                            ""id"": 1,
                            ""fullName"": ""Alice Smith"",
                            ""dateOfBirth"": ""1985-04-10""
                            },
                            {
                            ""id"": 2,
                            ""fullName"": ""Bob Jones"",
                            ""dateOfBirth"": ""1978-09-22""
                            },
                            {
                            ""id"": 3,
                            ""fullName"": ""Carlos Mendes"",
                            ""dateOfBirth"": ""1990-01-15""
                            },
                            {
                            ""id"": 4,
                            ""fullName"": ""Dana Wilson"",
                            ""dateOfBirth"": ""1972-07-08""
                            },
                            {
                            ""id"": 5,
                            ""fullName"": ""Ella Thompson"",
                            ""dateOfBirth"": ""1995-12-01""
                            },
                            {
                            ""id"": 6,
                            ""fullName"": ""Frank Li"",
                            ""dateOfBirth"": ""1982-03-19""
                            },
                            {
                            ""id"": 7,
                            ""fullName"": ""Grace Lee"",
                            ""dateOfBirth"": ""1988-06-23""
                            },
                            {
                            ""id"": 8,
                            ""fullName"": ""Henry Kim"",
                            ""dateOfBirth"": ""1992-11-30""
                            },
                            {
                            ""id"": 9,
                            ""fullName"": ""Isla Patel"",
                            ""dateOfBirth"": ""1984-05-05""
                            },
                            {
                            ""id"": 10,
                            ""fullName"": ""Jack Nguyen"",
                            ""dateOfBirth"": ""1999-08-17""
                            }
                        ]
                    ";
                var patients = JsonSerializer.Deserialize<List<Patient>>(patientsJsonData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (patients != null)
                {
                    context.Patients.AddRange(patients);
                    context.SaveChanges();
                }
            }
        }
    }
}
