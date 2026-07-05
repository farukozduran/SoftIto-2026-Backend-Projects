using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Dapper.Hospital.Project.Data.Repositories;
using Web.Dapper.Hospital.Project.Entity.Models;

namespace Web.Dapper.Hospital.Project.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var patients = await _patientRepository.GetAllAsync();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Patient patient)
        {
            if (patient == null)
            {
                return BadRequest();
            }
            var id = await _patientRepository.InsertAsync(patient);
            return CreatedAtAction(nameof(GetById), new { id = id }, patient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Patient patient)
        {
            if (patient == null || patient.Id != id)
            {
                return BadRequest();
            }
            var result = await _patientRepository.UpdateAsync(patient);
            if (result == 0)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _patientRepository.DeleteAsync(id);
            if (result == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
