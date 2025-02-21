using AutoMapper;
using Moq;
using Xunit;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using PatientManagement.Application.Contracts;
using PatientManagement.Application.Features.Patients.Commands;
using PatientManagement.Domain.Entities;
using PatientManagement.Application.DTOs;
using PatientManagement.Application.Features.Patients.Handlers;

namespace PatientManagement.UnitTests.Handlers;
public class AddPatientCommandHandlerTests
{
    private readonly Mock<IPatientRepository> _mockRepo;
    private readonly Mock<IMapper> _mockMapper;
    private readonly AddPatientCommandHandler _handler;

    public AddPatientCommandHandlerTests()
    {
        _mockRepo = new Mock<IPatientRepository>();
        _mockMapper = new Mock<IMapper>();

        _handler = new AddPatientCommandHandler(_mockRepo.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task Handle_ValidCommand_AddsPatientAndReturnsId()
    {
        // Arrange
        var command = new AddPatientCommand(new PatientDto
        {
            FullName = "John Doe",
            Email = "john@example.com",
            DateOfBirth = new DateTime(1990, 1, 1),
            Street = "123 Main St",
            City = "New York",
            State = "NY",
            ZipCode = "10001"
        });

        var patientEntity = new Patient
        {
            Id = 1,
            FullName = command.Patient.FullName,
            Email = command.Patient.Email,
            DateOfBirth = command.Patient.DateOfBirth,
            Street = command.Patient.Street,
            City = command.Patient.City,
            State = command.Patient.State,
            ZipCode = command.Patient.ZipCode
        };

        _mockMapper.Setup(m => m.Map<Patient>(command)).Returns(patientEntity);
        _mockRepo.Setup(repo => repo.AddAsync(It.IsAny<Patient>())).ReturnsAsync(patientEntity.Id);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().Be(patientEntity.Id);
        _mockRepo.Verify(repo => repo.AddAsync(It.IsAny<Patient>()), Times.Once);
    }
}
