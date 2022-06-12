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
    public class DeThisController : ControllerBase
    {
        private readonly EliberyContext _context;

        public DeThisController(EliberyContext context)
        {
            _context = context;
        }

        // GET: api/DeThis
        [HttpGet]
        [Route("XemDeThi")]
        public async Task<ActionResult<IEnumerable<DeThi>>> GetDeThi()
        {
            return await _context.DeThi.ToListAsync();
        }
        [HttpPut("{id}")]
        [Route("duyetdethi/{id}")]
        public async Task<ActionResult<IEnumerable<DeThi>>> duyetdethi(int id)
        {
            var deThi = await _context.DeThi.FindAsync(id);

            if (deThi == null)
            {
                return NotFound();
            }
            ThongBao thongBao = new ThongBao();
            thongBao.idQuyen = 1;
            thongBao.LoaiThongBao = "Thông báo người dùng";
            thongBao.ChuDe = "Thông báo đề thi";
            thongBao.NoiDung ="Đề thi "+deThi.tendethi+" đả được duyệt" ;
            thongBao.ThoiGian = DateTime.Now;
            _context.Add(thongBao);
            deThi.PheDuyet = true;
            deThi.NguoiPheDuyet = Convert.ToInt32(HttpContext.Session.GetString("Id"));
            _context.Update(deThi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeThi", new { id = deThi.Id }, deThi);
        }
        [HttpPut("{id}")]

        [Route("huyduyetdethi/{id}")]
        public async Task<ActionResult<IEnumerable<DeThi>>> huyduyetdethi(int id)
        {
            var deThi = await _context.DeThi.FindAsync(id);

            if (deThi == null)
            {
                return NotFound();
            }
            ThongBao thongBao = new ThongBao();
            thongBao.ChuDe = "Thông báo người dùng";
            thongBao.NoiDung = "Đề thi '" + _context.DeThi.Where(a => a.Id == id).FirstOrDefault().tendethi +"' đả bị hủy";
            thongBao.ThoiGian = DateTime.Now;
            _context.Add(thongBao);
            deThi.PheDuyet = false;
            deThi.NguoiPheDuyet = Convert.ToInt32(HttpContext.Session.GetString("Id"));
            _context.Update(deThi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeThi", new { id = deThi.Id }, deThi);
        }
        [HttpGet]
        [Route("searchtheoten/{data}")]
        public async Task<ActionResult<IEnumerable<DeThi>>> searchDeThiTenDeThi(string data)//tìm theo tên
        {

            if (string.IsNullOrEmpty(data))
            {
                return NotFound();
            }
            else
            {

                var ss = await _context.DeThi.Where(a => a.tendethi.Contains(data)).ToListAsync();
                return ss;
                
            }

        }
        [HttpGet]
        [Route("timdethitheobomon")]
        public async Task<ActionResult<IEnumerable<DeThi>>> searchDeThitheobomon(int bomon)
        {

            if (bomon==null)
            {
                return NotFound();
            }
            else
            {
                var x = await _context.BoMon.FindAsync(bomon);
                var result = (from a in _context.DeThi
                              join b in _context.MonHoc on a.idMonHoc equals b.Id
                              where b.BoMonId == bomon
                              select new
                              {
                                  LoaiFile = a.Tep.TheLoai,
                                  TenDeThi = a.tendethi,
                                  ThoiLuong = a.ThoiLuong,
                                  ThoiGianTao = a.NgayTao,
                                  TinhTrang = a.TinhTrang
                              }).ToList();

                return Ok(result);

            }

        }
        //[HttpGet]
        //[Route("timdethitheolop")]
        //public async Task<ActionResult<IEnumerable<DeThi>>> searchDeThitheolop(string name)
        //{

        //    if (string.IsNullOrEmpty(name))
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        var result = (from a in _context.DeThi
        //                      join b in _context.LopHoc on a.idLopHoc equals b.Id
        //                      where b.TenLop.Contains(name)
        //                      select new
        //                      {
        //                          LoaiFile = a.Tep.TheLoai,
        //                          TenDeThi = a.tendethi,
        //                          ThoiLuong = a.ThoiLuong,
        //                          ThoiGianTao = a.NgayTao,
        //                          TinhTrang = a.TinhTrang
        //                      }).ToList();

        //        return Ok(result);

        //    }

        //}
        [HttpGet]
        [Route("searchtheomonhoc/{id}")]
        public async Task<ActionResult<IEnumerable<DeThi>>> searchDeThimonhoc(int id)
        {

            if (id != null)
            {
                var ss = await _context.DeThi.Where(a => a.idMonHoc==id).ToListAsync();
                return ss;
            }
            else
            {
                return NotFound();
            }

        }
        //[HttpGet]
        //[Route("chitietdethi/{id}")]
        //public async Task<ActionResult> ChiTietDeThi(int id)
        //{
        //    var data = (from a in _context.DeThi
        //                join b in _context.NguoiDung on a.NguoiDungId equals b.Id
        //                join c in _context.MonHoc on a.idMonHoc equals c.Id
        //                where a.Id == id
        //                select new
        //                {
        //                    TenDeThi = a.tendethi,
        //                    MonHoc = c.TenMonHoc,
        //                    GiangVien = b.Ten,
        //                    HinhThuc = a.HinhThuc,
        //                    ThoiLuong = a.ThoiLuong,
        //                    NgayTao = a.NgayTao,
        //                    TinhTrang = a.TinhTrang

        //                }).ToList();
        //    return Ok(data);
        //}
        //[HttpGet]
        //[Route("DanhSachDethi")]
        //public async Task<IActionResult> NganHangDeThi() //admin
        //{

        //    var data =  (from a in _context.NguoiDung
        //                join b in _context.DeThi  on a.Id equals  b.NguoiDungId
        //                join c in _context.MonHoc on b.idMonHoc equals c.Id
        //                select new
        //                  {
        //                      b.tendethi,
        //                      c.TenMonHoc,
        //                      a.Ten,
        //                      b.HinhThuc,
        //                      b.ThoiLuong,
        //                      b.TinhTrang

        //                  }).ToList();

        //    return Ok(data);
        //}

        // PUT: api/DeThis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeThi(int id, [FromBody] DeThi deThi)
        {
            if (id != deThi.Id)
            {
                return BadRequest();
            }

            _context.Entry(deThi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeThiExists(id))
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

        // POST: api/DeThis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DeThi>> PostDeThi([FromBody] DeThi deThi)
        {

            
            deThi.PheDuyet = false;
            deThi.NguoiPheDuyet = 1;
            deThi.NgayTao = DateTime.Now;
            ThongBao thongBao = new ThongBao();
            thongBao.idQuyen = 2;
            thongBao.LoaiThongBao = "Thông báo người dùng";
            thongBao.ChuDe = "Thông báo học sinh";
            thongBao.NoiDung = "Đề thi "+deThi.tendethi+" đả được thêm mới" ;
            thongBao.ThoiGian = DateTime.Now;
            _context.DeThi.Add(deThi);
            _context.Add(thongBao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeThi", new { id = deThi.Id }, deThi);
        }

        // DELETE: api/DeThis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeThi(int id)
        {
            var deThi = await _context.DeThi.FindAsync(id);
            if (deThi == null)
            {
                return NotFound();
            }
            ThongBao thongBao = new ThongBao();
            thongBao.idQuyen = 2;
            thongBao.LoaiThongBao = "Thông báo người dùng";
            thongBao.ChuDe = "Thông báo học sinh";
            thongBao.NoiDung = "Đề thi " + deThi.tendethi + " đả được xóa";
            thongBao.ThoiGian = DateTime.Now;
            _context.Add(thongBao);
            _context.DeThi.Remove(deThi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeThiExists(int id)
        {
            return _context.DeThi.Any(e => e.Id == id);
        }
    }
}
