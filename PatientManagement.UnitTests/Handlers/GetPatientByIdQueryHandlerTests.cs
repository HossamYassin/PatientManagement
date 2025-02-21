using AutoMapper;
using FluentAssertions;
using Moq;
using PatientManagement.Application.Contracts;
using PatientManagement.Application.DTOs;
using PatientManagement.Application.Features.Patients.Handlers;
using PatientManagement.Application.Features.Patients.Queries;
using PatientManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement.UnitTests.Handlers
{
    public class GetPatientByIdQueryHandlerTests
    {
        private readonly Mock<IPatientRepository> _mockRepo;
        private readonly GetPatientByIdCommandHandler _handler;
        private readonly Mock<IMapper> _mockMapper;

        public GetPatientByIdQueryHandlerTests()
        {
            _mockRepo = new Mock<IPatientRepository>();
            _mockMapper = new Mock<IMapper>();

            _handler = new GetPatientByIdCommandHandler(_mockRepo.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task Handle_ExistingPatientId_ReturnsMappedPatientDto()
        {
            // Arrange
            var patientId = 1;
            var patientEntity = new Patient { Id = patientId, FullName = "John Doe" };
            var expectedDto = new PatientDto { Id = patientId, FullName = "John Doe" };

            _mockRepo.Setup(repo => repo.GetByIdAsync(patientId)).ReturnsAsync(patientEntity);
            _mockMapper.Setup(m => m.Map<PatientDto>(patientEntity)).Returns(expectedDto);

            var query = new GetPatientByIdQuery(patientId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().BeEquivalentTo(expectedDto);
        }


        [Fact]
        public async Task Handle_NonExistingPatientId_ReturnsNull()
        {
            // Arrange
            var query = new GetPatientByIdQuery(99);
            _mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Patient)null);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().BeNull();
        }
    }

}
