using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.AtYarisi.API.Data;
using Project.AtYarisi.API.Models;

namespace Project.AtYarisi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JockeysController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public JockeysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Jockeys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jockey>>> GetJockeys()
        {
            return await _context.Jockeys.ToListAsync();
        }

        // GET: api/Jockeys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jockey>> GetJockey(int id)
        {
            var jockey = await _context.Jockeys.FindAsync(id);

            if (jockey == null)
            {
                return NotFound();
            }

            return jockey;
        }

        // POST: api/Jockeys
        [HttpPost]
        public async Task<ActionResult<Jockey>> PostJockey(Jockey jockey)
        {
            _context.Jockeys.Add(jockey);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetJockey), new { id = jockey.JockeyId }, jockey);
        }

        // PUT: api/Jockeys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJockey(int id, Jockey jockey)
        {
            if (id != jockey.JockeyId)
            {
                return BadRequest();
            }

            _context.Entry(jockey).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JockeyExists(id))
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

        // DELETE: api/Jockeys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJockey(int id)
        {
            var jockey = await _context.Jockeys.FindAsync(id);
            if (jockey == null)
            {
                return NotFound();
            }

            _context.Jockeys.Remove(jockey);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JockeyExists(int id)
        {
            return _context.Jockeys.Any(e => e.JockeyId == id);
        }
    }
}
