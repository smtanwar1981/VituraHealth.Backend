using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VituraHealth.Application.DTOs;
using VituraHealth.Application.Interfaces;
using VituraHealth.Application.Services;
using VituraHealth.Domain.Entities;
using VituraHealth.Domain.Repositories;

namespace VituraHealth.UnitTests.Services
{
    public class PatientServiceTests
    {
        private readonly Mock<IPatientRespository> _patientRepositoryMock;
        private readonly IMapper _mapperMock;
        private readonly PatientService _patientServiceMock;
        public PatientServiceTests()
        {
            _patientRepositoryMock = new Mock<IPatientRespository>();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Patient, PatientDTO>();
            });
            _mapperMock = config.CreateMapper();
            _patientServiceMock = new PatientService(_patientRepositoryMock.Object, _mapperMock);
        }

        [Fact]
        public async Task GetAllPatientsAsync_ReturnsMappedPatientDTOs()
        {
            // Arrange
            var patientList = new List<Patient>
            {
                new() { Id = 1, FullName = "Jackie Chan", DateOfBirth = "11/11/1911" },
                new() { Id = 2, FullName = "Michael Jackson", DateOfBirth = "11/11/1922" }
            };

            _patientRepositoryMock.Setup(repo => repo.GetAllPatientsAsync())
                           .ReturnsAsync(patientList);

            // Act
            var result = await _patientServiceMock.GetAllPatientsAsync();

            // Assert
            Assert.NotNull(result);
            var resultList = Assert.IsAssignableFrom<IEnumerable<PatientDTO>>(result);
            Assert.Collection(resultList,
                item =>
                {
                    Assert.Equal(1, item.Id);
                    Assert.Equal("Jackie Chan", item.FullName);
                },
                item =>
                {
                    Assert.Equal(2, item.Id);
                    Assert.Equal("Michael Jackson", item.FullName);
                });
        }

        [Fact]
        public async Task GetAllPatientsAsync_ReturnsEmptyList_WhenNoPatientsExist()
        {
            // Arrange
            _patientRepositoryMock.Setup(repo => repo.GetAllPatientsAsync())
                           .ReturnsAsync(new List<Patient>());

            // Act
            var result = await _patientServiceMock.GetAllPatientsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}
