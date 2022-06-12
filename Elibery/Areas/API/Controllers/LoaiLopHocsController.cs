
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Elibery.Data;
using Elibery.Models;

namespace Elibery.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiLopHocsController : ControllerBase
    {
        private readonly EliberyContext _context;

        public LoaiLopHocsController(EliberyContext context)
        {
            _context = context;
        }

        // GET: api/LoaiLopHocs
        [HttpGet]
        [Route("xemloailophoc")]
        public async Task<ActionResult<IEnumerable<LoaiLopHoc>>> GetLoaiLopHoc()
        {
            return await _context.LoaiLopHoc.ToListAsync();
        }
        [HttpGet]
        [Route("timKiemlophoctheoloai/{data}")]
        public async Task<ActionResult<IEnumerable<LopHoc>>> timKiemLopHocTheoLoai(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return NotFound();
            }
            else
            {
                var ss = await _context.LopHoc.Where(a => a.loaiLopHoc.tenLoai.Contains(data)).ToListAsync();
                return ss;
            }
        }

        // GET: api/LoaiLopHocs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoaiLopHoc>> GetLoaiLopHoc(int id)
        {
            var loaiLopHoc = await _context.LoaiLopHoc.FindAsync(id);

            if (loaiLopHoc == null)
            {
                return NotFound();
            }

            return loaiLopHoc;
        }

        // PUT: api/LoaiLopHocs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoaiLopHoc(int id, LoaiLopHoc loaiLopHoc)
        {
            if (id != loaiLopHoc.id)
            {
                return BadRequest();
            }

            _context.Entry(loaiLopHoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaiLopHocExists(id))
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

        // POST: api/LoaiLopHocs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoaiLopHoc>> PostLoaiLopHoc(LoaiLopHoc loaiLopHoc)
        {
            _context.LoaiLopHoc.Add(loaiLopHoc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoaiLopHoc", new { id = loaiLopHoc.id }, loaiLopHoc);
        }

        // DELETE: api/LoaiLopHocs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoaiLopHoc(int id)
        {
            var loaiLopHoc = await _context.LoaiLopHoc.FindAsync(id);
            if (loaiLopHoc == null)
            {
                return NotFound();
            }

            _context.LoaiLopHoc.Remove(loaiLopHoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoaiLopHocExists(int id)
        {
            return _context.LoaiLopHoc.Any(e => e.id == id);
        }
    }
}
