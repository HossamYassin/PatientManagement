using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatientManagement.Application.DTOs;
using PatientManagement.Application.Features.Patients.Commands;
using PatientManagement.Application.Features.Patients.Queries;
using PatientManagement.Domain.Entities;
using PatientManagement.WebAPI.Models;

namespace PatientManagement.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all patients
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<PatientDto>>> GetAll()
        {
            var patients = await _mediator.Send(new GetPatientsQuery());

            return Ok(new ApiResponse<List<PatientDto>>(
                "success", patients
            ));
        }

        /// <summary>
        /// Get a patient by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDto>> GetById(int id)
        {
            var patient = await _mediator.Send(new GetPatientByIdQuery(id));

            if (patient == null)
                return NotFound(new ApiResponse<PatientDto>(
                "fail", new List<string> { "patient does not exist" }));

            return Ok(new ApiResponse<PatientDto>(
                "success", patient
            ));
        }

        /// <summary>
        /// Add a new patient
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<int>> Add([FromBody] PatientDto patient)
        {
            var patientId = await _mediator.Send(new AddPatientCommand(patient));
            return Ok(new ApiResponse<PatientDto>(
                "success", patient));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PatientDto patient)
        {
            if (id != patient.Id) return BadRequest(new ApiResponse<PatientDto>(
                "fail", new List<string> { "ID mismatch." }));

            bool isUpdated = await _mediator.Send(new UpdatePatientCommand(patient));
            if (!isUpdated) return NotFound(new ApiResponse<PatientDto>(
                "fail", new List<string> { "Patient not found." }));

            return Ok(new ApiResponse<PatientDto>(
                "success", patient
            ));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool isDeleted = await _mediator.Send(new DeletePatientCommand { Id = id });
            if (!isDeleted) return NotFound(new ApiResponse<PatientDto>(
                "fail", new List<string> { "Patient not found." }));

            return Ok(new ApiResponse<int>("success", id));

        }
    }
}
