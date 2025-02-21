using Xunit;
using Moq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using MediatR;
using PatientManagement.Application.Features.Patients.Commands;
using PatientManagement.Application.Features.Patients.Queries;
using PatientManagement.Domain.Entities;
using PatientManagement.WebAPI.Controllers;
using PatientManagement.Application.DTOs;

namespace PatientManagement.UnitTests.Controllers;
public class PatientsControllerTests
{
    private readonly Mock<IMediator> _mockMediator;
    private readonly PatientsController _controller;

    public PatientsControllerTests()
    {
        _mockMediator = new Mock<IMediator>();
        _controller = new PatientsController(_mockMediator.Object);
    }

    [Fact]
    public async Task GetById_ReturnsOk_WhenPatientExists()
    {
        // Arrange
        var patientId = 1;

        var patientDto = new PatientDto
        {
            Id = patientId,
            Email = "test@example.com",
            FullName = "John Doe",
            DateOfBirth = new DateTime(1990, 1, 1),
            Street = "123 Main St",
            City = "Sample City",
            State = "Sample State",
            ZipCode = "12345"
        };

        _mockMediator
            .Setup(m => m.Send(It.Is<GetPatientByIdQuery>(q => q.Id == patientId), It.IsAny<CancellationToken>()))
            .ReturnsAsync(patientDto);

        // Act
        var result = await _controller.GetById(patientId);

        // Assert
        result.Result.Should().BeOfType<OkObjectResult>()
            .Which.Value.Should().BeEquivalentTo(patientDto);

        _mockMediator.Verify(m => m.Send(It.IsAny<GetPatientByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task GetById_ReturnsNotFound_WhenPatientDoesNotExist()
    {
        // Arrange
        _mockMediator.Setup(m => m.Send(It.IsAny<GetPatientByIdQuery>(), It.IsAny<CancellationToken>()))
                     .ReturnsAsync((PatientDto?)null);

        // Act
        var result = await _controller.GetById(999);

        // Assert
        result.Result.Should().BeOfType<NotFoundResult>();
    }


    [Fact]
    public async Task AddPatient_ReturnsCreatedAtAction_WhenSuccessful()
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

        var createdPatientId = 1;

        _mockMediator.Setup(m => m.Send(It.IsAny<AddPatientCommand>(), It.IsAny<CancellationToken>()))
                     .ReturnsAsync(createdPatientId);

        // Act
        var result = await _controller.Add(command.Patient);

        // Assert
        var createdResult = result.Result.Should().BeOfType<CreatedAtActionResult>().Subject;
        createdResult.ActionName.Should().Be(nameof(PatientsController.GetById));
        createdResult.RouteValues["id"].Should().Be(createdPatientId);
        createdResult.Value.Should().Be(createdPatientId);
    }

}
