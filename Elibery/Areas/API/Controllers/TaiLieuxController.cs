
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Elibery.Data;
using Elibery.Models;

namespace Elibery.Areas.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaiLieuxController : ControllerBase
    {
        private readonly EliberyContext _context;

        public TaiLieuxController(EliberyContext context)
        {
            _context = context;
        }

        // GET: api/TaiLieux
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaiLieu>>> GetTaiLieu()
        {
            return await _context.TaiLieu.Where(a=>a.TinhTrang==true).ToListAsync();
        }
        [HttpPut]
        [Route("pheduyettailieumonhoc/{id}")]
        public async Task<ActionResult<IEnumerable<TaiLieu>>> pheduyettailieu(int id)
        {
            var taiLieu = await _context.TaiLieu.FindAsync(id);

            if (taiLieu == null)
            {
                return NotFound();
            }
            taiLieu.PheDuyet = true;
            _context.Update(taiLieu);
            ThongBao thongBao = new ThongBao();
            thongBao.idQuyen = 2;
            thongBao.LoaiThongBao = "Thông báo người dùng";
            thongBao.ChuDe = "Thông báo học sinh";
            thongBao.NoiDung = "Tài Liệu " + taiLieu.tentailieu + " đả được duyệt";
            thongBao.ThoiGian = DateTime.Now;
            _context.Add(thongBao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaiLieu", new { id = taiLieu.Id }, taiLieu);

        }
        [HttpPut]
        [Route("huytailieu/{id}")]
        public async Task<ActionResult<IEnumerable<TaiLieu>>> huytailieu(int id)
        {
            var taiLieu = await _context.TaiLieu.FindAsync(id);

            if (taiLieu == null)
            {
                return NotFound();
            }
            taiLieu.TinhTrang = false;
            _context.Update(taiLieu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaiLieu", new { id = taiLieu.Id }, taiLieu);

        }
        // GET: api/TaiLieux/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaiLieu>> GetTaiLieu(int id)
        {
            var taiLieu = await _context.TaiLieu.FindAsync(id);

            if (taiLieu == null)
            {
                return NotFound();
            }

            return taiLieu;
        }

        // PUT: api/TaiLieux/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaiLieu(int id, TaiLieu taiLieu)
        {
            if (id != taiLieu.Id)
            {
                return BadRequest();
            }

            _context.Entry(taiLieu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaiLieuExists(id))
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

        // POST: api/TaiLieux
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaiLieu>> PostTaiLieu(TaiLieu taiLieu)
        {
            _context.TaiLieu.Add(taiLieu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaiLieu", new { id = taiLieu.Id }, taiLieu);
        }

        // DELETE: api/TaiLieux/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaiLieu(int id)
        {
            var taiLieu = await _context.TaiLieu.FindAsync(id);
            if (taiLieu == null)
            {
                return NotFound();
            }

            _context.TaiLieu.Remove(taiLieu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaiLieuExists(int id)
        {
            return _context.TaiLieu.Any(e => e.Id == id);
        }
    }
}
