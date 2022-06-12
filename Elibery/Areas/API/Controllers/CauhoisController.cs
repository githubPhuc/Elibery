using Elibery.Data;
using Elibery.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Elibery.Areas.API.Controllers
{
    //[Authorize(Roles = "User")]
    [Route("api/[controller]")]
    [ApiController]
    public class CauhoisController : ControllerBase
    {
        private readonly EliberyContext _context;
        public CauhoisController(EliberyContext context)
        {
            _context= context;
        }
        // GET: api/<CauhoisController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<cauhoi>>> getCauHoi()
        {
            var data = await _context.cauhoi.ToListAsync();
            return data;
        }

        // GET api/<CauhoisController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<cauhoi>> getCauHoi(int id)
        {
            var data = await _context.cauhoi.FindAsync(id);
            if( data== null)
            {
                return NotFound();
            }
            return data;
        }

        // POST api/<CauhoisController>
        [HttpPost]
        public async Task<IActionResult> PostCauHoi([FromBody] cauhoi cauHoi)
        {
            _context.cauhoi.Add(cauHoi);
            await _context.SaveChangesAsync();
            return CreatedAtAction("getCauHoi", new { id = cauHoi.id }, cauHoi);
        }

        // PUT api/<CauhoisController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCauHoi(int id, [FromBody] cauhoi cauHoi)
        {
            if(id!= cauHoi.id)
            {
                return Content("Không tìm thấy câu hỏi");
            }
            _context.Entry(cauHoi).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cauHoiExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Content("Chỉnh sửa thành công ");

        }

        private bool cauHoiExists(int id)
        {
            return _context.cauhoi.Any(e => e.id == id);
        }

        // DELETE api/<CauhoisController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dataa = await _context.cauhoi.FindAsync(id);
            if (dataa == null)
            {
                return NotFound();
            }

            _context.cauhoi.Remove(dataa);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
