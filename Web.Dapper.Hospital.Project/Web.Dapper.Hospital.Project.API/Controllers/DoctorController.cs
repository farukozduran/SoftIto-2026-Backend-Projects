using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Dapper.Hospital.Project.Data.Repositories;
using Web.Dapper.Hospital.Project.Entity.Models;

namespace Web.Dapper.Hospital.Project.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var doctors = await _doctorRepository.GetAllAsync();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Doctor doctor)
        {
            if (doctor == null)
            {
                return BadRequest();
            }
            var id = await _doctorRepository.InsertAsync(doctor);
            return CreatedAtAction(nameof(GetById), new { id = id }, doctor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Doctor doctor)
        {
            if (doctor == null || doctor.Id != id)
            {
                return BadRequest();
            }
            var result = await _doctorRepository.UpdateAsync(doctor);
            if (result == 0)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _doctorRepository.DeleteAsync(id);
            if (result == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
