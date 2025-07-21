using AutoMapper;
using FluentAssertions;
using Moq;
using VituraHealth.Application.DTOs;
using VituraHealth.Application.Interfaces;
using VituraHealth.Application.Services;
using VituraHealth.Domain.Entities;
using VituraHealth.Domain.Repositories;

namespace VituraHealth.UnitTests.Services
{
    public class PrescriptionServiceTests
    {
        private readonly Mock<IPrescriptionRepository> _prescriptionRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly PrescriptionService _prescriptionServiceMock;

        public PrescriptionServiceTests()
        {
            _prescriptionRepositoryMock = new Mock<IPrescriptionRepository>();
            _mapperMock = new Mock<IMapper>();
            _prescriptionServiceMock = new PrescriptionService(_prescriptionRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task AddPrescriptionAsync_ShouldAddPrescriptionAndReturnDto()
        {
            // Arrange
            var newPrescriptionRequest = new CreatePrescriptionRequest
            {
                PatientId = 1,
                DrugName = "Amoxicillin",
                Dosage = "500mg",
                DatePrescribed = DateTime.UtcNow.ToString()
            };

            var entity = new Prescription();
            var dto = new PrescriptionDTO();

            _mapperMock.Setup(m => m.Map<Prescription>(newPrescriptionRequest)).Returns(entity);
            _mapperMock.Setup(m => m.Map<PrescriptionDTO>(It.IsAny<Prescription>())).Returns(dto);

            _prescriptionRepositoryMock.Setup(r => r.AddPrescriptionAsync(It.IsAny<Prescription>()))
                           .Returns(Task.CompletedTask);

            // Act
            var result = await _prescriptionServiceMock.AddPrescriptionAsync(newPrescriptionRequest);

            // Assert
            _mapperMock.Verify(m => m.Map<Prescription>(newPrescriptionRequest), Times.Once);
            _prescriptionRepositoryMock.Verify(r => r.AddPrescriptionAsync(It.IsAny<Prescription>()), Times.Once);
            result.Should().BeOfType<PrescriptionDTO>();
        }

        [Fact]
        public async Task GetPrescriptionListAsync_ShouldReturnListOfPrescriptionDTO()
        {
            // Arrange
            var prescriptions = new List<Prescription> { new Prescription(), new Prescription() };
            var prescriptionDtos = new List<PrescriptionDTO> { new PrescriptionDTO(), new PrescriptionDTO() };

            _prescriptionRepositoryMock.Setup(r => r.GetAllPrescriptionsAsync()).ReturnsAsync(prescriptions);
            _mapperMock.Setup(m => m.Map<IEnumerable<PrescriptionDTO>>(prescriptions)).Returns(prescriptionDtos);

            // Act
            var result = await _prescriptionServiceMock.GetPrescriptionListAsync();

            // Assert
            result.Should().HaveCount(2);
            result.Should().BeEquivalentTo(prescriptionDtos);
        }

        [Fact]
        public async Task GetPrescriptionListAsync_ReturnsMappedDTOs_WhenDataExists()
        {
            // Arrange
            var prescriptions = new List<Prescription>
            {
                new() { Id = 1, DrugName = "Panadol", Dosage = "500mg" },
                new() { Id = 2, DrugName = "Ibuprofen", Dosage = "200mg" }
            };

            var expectedDTOs = new List<PrescriptionDTO>
            {
                new() { Id = 1, DrugName = "Panadol" },
                new() { Id = 2, DrugName = "Ibuprofen" }
            };

            _prescriptionRepositoryMock
                .Setup(repo => repo.GetAllPrescriptionsAsync())
                .ReturnsAsync(prescriptions);

            _mapperMock
                .Setup(m => m.Map<IEnumerable<PrescriptionDTO>>(prescriptions))
                .Returns(expectedDTOs);

            // Act
            var result = await _prescriptionServiceMock.GetPrescriptionListAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Collection(result,
                item => Assert.Equal("Panadol", item.DrugName),
                item => Assert.Equal("Ibuprofen", item.DrugName));
        }

        [Fact]
        public async Task GetPrescriptionListAsync_ReturnsEmptyList_WhenNoPrescriptionsExist()
        {
            // Arrange
            var prescriptions = new List<Prescription>();
            var expectedDTOs = new List<PrescriptionDTO>();

            _prescriptionRepositoryMock
                .Setup(repo => repo.GetAllPrescriptionsAsync())
                .ReturnsAsync(prescriptions);

            _mapperMock
                .Setup(m => m.Map<IEnumerable<PrescriptionDTO>>(prescriptions))
                .Returns(expectedDTOs);

            // Act
            var result = await _prescriptionServiceMock.GetPrescriptionListAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}
