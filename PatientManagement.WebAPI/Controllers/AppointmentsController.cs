using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatientManagement.Application.DTOs;
using PatientManagement.Application.Features.Appointments.Commands;
using PatientManagement.Application.Features.Appointments.Queries;
using PatientManagement.Domain.Entities;
using PatientManagement.WebAPI.Models;

namespace PatientManagement.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppointmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all appointments for a patient
        /// </summary>
        [HttpGet("patient/{patientId}")]
        public async Task<ActionResult<List<AppointmentDto>>> GetByPatientId(int patientId)
        {
            var appointments = await _mediator.Send(new GetAppointmentsByPatientIdQuery(patientId));
            
            return Ok(new ApiResponse<List<AppointmentDto>>(
                "success", appointments
            ));
        }

        /// <summary>
        /// Get an appointment by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDto>> GetById(int id)
        {
            var appointment = await _mediator.Send(new GetAppointmentByIdQuery(id));

            if (appointment == null)
                return NotFound(new ApiResponse<List<AppointmentDto>>(
                "fail", new List<string> { "appointment does not exist" }));

            return Ok(new ApiResponse<AppointmentDto>(
                "success", appointment
            ));
        }

        /// <summary>
        /// Add a new appointment
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<int>> Add([FromBody] AppointmentDto appointment)
        {
            var appointmentId = await _mediator.Send(new AddAppointmentCommand(appointment));

            return CreatedAtAction(nameof(GetById), new ApiResponse<int>(
                "success", appointmentId
            ), appointmentId);
        }
    }
}
