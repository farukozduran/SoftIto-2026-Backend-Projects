using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.AtYarisi.API.Data;
using Project.AtYarisi.API.Models;

namespace Project.AtYarisi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacecoursesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RacecoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Racecourses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Racecourse>>> GetRacecourses()
        {
            return await _context.Racecourses.ToListAsync();
        }

        // GET: api/Racecourses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Racecourse>> GetRacecourse(int id)
        {
            var racecourse = await _context.Racecourses.FindAsync(id);

            if (racecourse == null)
            {
                return NotFound();
            }

            return racecourse;
        }

        // POST: api/Racecourses
        [HttpPost]
        public async Task<ActionResult<Racecourse>> PostRacecourse(Racecourse racecourse)
        {
            _context.Racecourses.Add(racecourse);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRacecourse), new { id = racecourse.RacecourseId }, racecourse);
        }

        // PUT: api/Racecourses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRacecourse(int id, Racecourse racecourse)
        {
            if (id != racecourse.RacecourseId)
            {
                return BadRequest();
            }

            _context.Entry(racecourse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RacecourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Racecourses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRacecourse(int id)
        {
            var racecourse = await _context.Racecourses.FindAsync(id);
            if (racecourse == null)
            {
                return NotFound();
            }

            _context.Racecourses.Remove(racecourse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RacecourseExists(int id)
        {
            return _context.Racecourses.Any(e => e.RacecourseId == id);
        }
    }
}
