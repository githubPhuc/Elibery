using Elibery.Data;
using Elibery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Elibery.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoMonsController : ControllerBase
    {
        private readonly EliberyContext _context;

        public BoMonsController(EliberyContext context)
        {
            _context = context;
        }

        // GET: api/BoMons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoMon>>> GetBoMon()
        {
            return await _context.BoMon.ToListAsync();
        }



        // GET: api/BoMons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BoMon>> GetBoMon(int id)
        {
            var boMon = await _context.BoMon.FindAsync(id);

            if (boMon == null)
            {
                return NotFound();
            }

            return boMon;
        }

        // PUT: api/BoMons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoMon(int id, [FromForm] BoMon boMon)
        {
            if (id != boMon.Id)
            {
                return BadRequest();
            }

            _context.Entry(boMon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoMonExists(id))
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

        // POST: api/BoMons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BoMon>> PostBoMon([FromForm] BoMon boMon)
        {
            _context.BoMon.Add(boMon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoMon", new { id = boMon.Id }, boMon);
        }

        // DELETE: api/BoMons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoMon(int id)
        {
            var boMon = await _context.BoMon.FindAsync(id);
            if (boMon == null)
            {
                return NotFound();
            }

            _context.BoMon.Remove(boMon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BoMonExists(int id)
        {
            return _context.BoMon.Any(e => e.Id == id);
        }
    }
}
