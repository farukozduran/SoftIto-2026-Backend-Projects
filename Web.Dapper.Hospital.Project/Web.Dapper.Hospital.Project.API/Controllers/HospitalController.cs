using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Dapper.Hospital.Project.Data.Repositories;
using Web.Dapper.Hospital.Project.Entity.Models;
using HospitalEntity = Web.Dapper.Hospital.Project.Entity.Models.Hospital;

namespace Web.Dapper.Hospital.Project.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalRepository _hospitalRepository;

        public HospitalController(IHospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var hospitals = await _hospitalRepository.GetAllAsync();
            return Ok(hospitals);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var hospital = await _hospitalRepository.GetByIdAsync(id);
            if (hospital == null)
            {
                return NotFound();
            }
            return Ok(hospital);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] HospitalEntity hospital)
        {
            if (hospital == null)
            {
                return BadRequest();
            }
            var id = await _hospitalRepository.InsertAsync(hospital);
            return CreatedAtAction(nameof(GetById), new { id = id }, hospital);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] HospitalEntity hospital)
        {
            if (hospital == null || hospital.Id != id)
            {
                return BadRequest();
            }
            var result = await _hospitalRepository.UpdateAsync(hospital);
            if (result == 0)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _hospitalRepository.DeleteAsync(id);
            if (result == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
