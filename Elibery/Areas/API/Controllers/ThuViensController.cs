using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Elibery.Data;
using Elibery.Models;

namespace Elibery.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThuViensController : ControllerBase
    {
        private readonly EliberyContext _context;

        public ThuViensController(EliberyContext context)
        {
            _context = context;
        }

        // GET: api/ThuViens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThuVien>>> GetThuVien()
        {
            return await _context.ThuVien.ToListAsync();
        }

        // GET: api/ThuViens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThuVien>> GetThuVien(int id)
        {
            var thuVien = await _context.ThuVien.FindAsync(id);

            if (thuVien == null)
            {
                return NotFound();
            }

            return thuVien;
        }

        // PUT: api/ThuViens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThuVien(int id, [FromBody] ThuVien thuVien)
        {
            if (id != thuVien.Id)
            {
                return BadRequest();
            }

            _context.Entry(thuVien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThuVienExists(id))
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

        // POST: api/ThuViens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ThuVien>> PostThuVien([FromBody] ThuVien thuVien)
        {
            _context.ThuVien.Add(thuVien);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThuVien", new { id = thuVien.Id }, thuVien);
        }

        // DELETE: api/ThuViens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThuVien(int id)
        {
            var thuVien = await _context.ThuVien.FindAsync(id);
            if (thuVien == null)
            {
                return NotFound();
            }

            _context.ThuVien.Remove(thuVien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThuVienExists(int id)
        {
            return _context.ThuVien.Any(e => e.Id == id);
        }
    }
}
