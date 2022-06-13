using Elibery.Data;
using Elibery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Elibery.Areas.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DapAnsController : ControllerBase
    {
        private readonly EliberyContext _context;
        public DapAnsController(EliberyContext context)
        {
            _context = context;
        }

        // GET: api/<DapAnsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dapan>>> Get()
        {
            var data = await _context.dapan.ToListAsync();
            return data;
        }

        // GET api/<DapAnsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<dapan>> Get(int id)
        {
            var data= await _context.dapan.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return data;
        }
        // POST api/<CauhoisController>
        [HttpPost]
        public async Task<IActionResult> PostCauHoi([FromBody] dapan dapAn)
        {
            _context.dapan.Add(dapAn);
            await _context.SaveChangesAsync();
            return CreatedAtAction("getCauHoi", new { id = dapAn.id }, dapAn);
        }

        // PUT api/<dapAnsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCauHoi(int id, [FromBody] dapan dapAn)
        {
            if (id != dapAn.id)
            {
                return Content("Không tìm thấy câu hỏi");
            }
            _context.Entry(dapAn).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!dapAnExists(id))
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

        private bool dapAnExists(int id)
        {
            return _context.cauhoi.Any(e => e.id == id);
        }

        // DELETE api/<dapAnsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dataa = await _context.dapan.FindAsync(id);
            if (dataa == null)
            {
                return NotFound();
            }

            _context.dapan.Remove(dataa);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
