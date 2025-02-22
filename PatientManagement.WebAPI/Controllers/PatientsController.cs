using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatientManagement.Application.DTOs;
using PatientManagement.Application.Features.Patients.Commands;
using PatientManagement.Application.Features.Patients.Queries;

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
            return Ok(patients);
        }

        /// <summary>
        /// Get a patient by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDto>> GetById(int id)
        {
            var patient = await _mediator.Send(new GetPatientByIdQuery(id));
            if (patient == null)
                return NotFound();
            return Ok(patient);
        }

        /// <summary>
        /// Add a new patient
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<int>> Add([FromBody] PatientDto patient)
        {
            var patientId = await _mediator.Send(new AddPatientCommand(patient));
            return CreatedAtAction(nameof(GetById), new { id = patientId }, patientId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PatientDto patient)
        {
            if (id != patient.Id) return BadRequest("ID mismatch.");

            bool isUpdated = await _mediator.Send(new UpdatePatientCommand(patient));
            if (!isUpdated) return NotFound("Patient not found.");

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool isDeleted = await _mediator.Send(new DeletePatientCommand { Id = id });
            if (!isDeleted) return NotFound("Patient not found.");

            return NoContent();
        }
    }
}
