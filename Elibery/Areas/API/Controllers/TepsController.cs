using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Elibery.Data;
using Elibery.Models;

namespace Elibery.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TepsController : ControllerBase
    {
        private readonly EliberyContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        
        public TepsController(EliberyContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            
        }
        [HttpGet]
        [Route("loctep")]
        public async Task<ActionResult<IEnumerable<Tep>>> locDanhSachTep(string context)
        {
            if (string.IsNullOrEmpty(context))
            {
                return NotFound();
            }
            else
            {
                var data = await _context.Tep.Where(a => a.TheLoai.Contains(context)).ToListAsync();
                return data;
            }
        }

        // GET: api/Teps
        [HttpGet]
        [Route("xemtep")]
        public async Task<ActionResult<IEnumerable<Tep>>> GetTep()
        {
            return await _context.Tep.ToListAsync();
        }

        // GET: api/Teps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tep>> GetTep(int id)
        {
            var tep = await _context.Tep.FindAsync(id);

            if (tep == null)
            {
                return NotFound();
            }

            return tep;
        }

        // PUT: api/Teps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut]
        //[Route("suatep")]
        //public async Task<IActionResult> PutTep(int id, [FromForm] Tep tep,IFormFile formFile)
        //{
        //    if (id != tep.Id)
        //    {
        //        return BadRequest();
        //    }
        //    if (formFile != null)
        //    {
        //        var data = await _context.Tep.FindAsync(id);
        //        var name =data.TenTep ;
        //        var fileToDelete = Path.Combine(_webHostEnvironment.WebRootPath, "file",  name);
        //        FileInfo file = new FileInfo(fileToDelete);
        //        file.Delete();
        //        var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "file");
        //        var filePath = Path.Combine(uploadPath, formFile.FileName);
        //        using (FileStream fs = System.IO.File.Create(filePath))
        //        {
        //            formFile.CopyTo(fs);
        //            fs.Flush();
        //        }
        //    }

        //    tep.TheLoai = Path.GetExtension(formFile.FileName);
        //    tep.TenTep = formFile.FileName;
        //    tep.KichThuoc = Convert.ToInt32(formFile.Length);
        //    tep.NgaySuaCuoi = DateTime.Now;
        //    tep.NguoiChinhSua = 1;
        //    _context.Entry(tep).State = EntityState.Modified;


        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TepExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}



        // POST: api/Teps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("themtep")]

        public async Task<ActionResult<Tep>> PostTep([FromForm] Tep tep, IFormFile formFile)
        {
            if (ModelState.IsValid)
            {
                ThongBao thongBao = new ThongBao();
                string name = "";
                _context.Tep.Add(tep);
                await _context.SaveChangesAsync();
                if (formFile != null)
                {
                    var extens = Path.GetExtension(formFile.FileName);
                    var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "file");
                    var filePath = Path.Combine(uploadPath, formFile.FileName);
                    using (FileStream fs = System.IO.File.Create(filePath))
                    {
                        formFile.CopyTo(fs);
                        fs.Flush();
                    }
                    tep.TheLoai = extens;
                    tep.TenTep = formFile.FileName;
                    name = tep.TenTep;
                    tep.KichThuoc = Convert.ToInt32(formFile.Length);
                    tep.NgaySuaCuoi = DateTime.Now;
                    _context.Tep.Update(tep);
                    await _context.SaveChangesAsync();
                }
                thongBao.idQuyen = 1;
                thongBao.LoaiThongBao = "Thông báo người dùng";
                thongBao.ChuDe = "Thông báo Tệp";
                thongBao.NoiDung = name + " Đả được thêm " ;
                thongBao.ThoiGian = DateTime.Now;
                _context.ThongBao.Add(thongBao);
                return CreatedAtAction("GetTep", new { id = tep.Id }, tep);
            }
            return NoContent();
        }

        [HttpGet]
        [Route("Download")]
        public async Task<FileStreamResult> DownloadFile(int id)
        {
            var data = await _context.Tep.FindAsync(id);
            var context = data.TenTep;
            if (context == null)
            {

            }
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "file", context);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));

        }
        [HttpPut]
        [Route("renamefile")]
        public async Task<IActionResult> reNameFile(int id, string tenFileMoi)
        {
            ThongBao thongBao = new ThongBao();
            var tep = await _context.Tep.FindAsync(id);
            string content = tep.TenTep;
            string name="";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "file");
            if (tep.TheLoai == ".docx")
            {
                Directory.Move(path + "\\" + content, path + "\\" + tenFileMoi + tep.TheLoai);
                tep.TenTep = tenFileMoi + tep.TheLoai;
            }
            else
            {
                name = tenFileMoi + "." + tep.TheLoai;
                Directory.Move(path + "\\" + content, path + "\\" + name);
                tep.TenTep = name;
            }
            tep.NguoiChinhSua = Convert.ToInt32(HttpContext.Session.GetString("Id"));
            tep.NgaySuaCuoi = DateTime.Now;
            _context.Update(tep);
            thongBao.idQuyen = 1;
            thongBao.LoaiThongBao = "Thông báo người dùng";
            thongBao.ChuDe = "Thông báo Tệp";
            thongBao.NoiDung = content + " Đả bị đổi tên thành " + name;
            thongBao.ThoiGian = DateTime.Now;
            _context.ThongBao.Add(thongBao);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTep", new { id = tep.Id }, tep);
        }

        // DELETE: api/Teps/5
        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTep(int id)
        {
            ThongBao thongBao = new ThongBao();
            var tep = await _context.Tep.FindAsync(id);
            if (tep == null)
            {
                return NotFound();
            }
            var fileToDelete = Path.Combine(_webHostEnvironment.WebRootPath, "file",  tep.TenTep);
            FileInfo file = new FileInfo(fileToDelete);
            file.Delete();
            thongBao.idQuyen = 1;
            thongBao.LoaiThongBao = "Thông báo người dùng";
            thongBao.ChuDe = "Thông báo Tệp";
            thongBao.NoiDung = tep.TenTep+" đả bị xóa";
            thongBao.ThoiGian = DateTime.Now;
            _context.ThongBao.Add(thongBao);
            _context.Tep.Remove(tep);
            _context.ThongBao.Add(thongBao);
            await _context.SaveChangesAsync();

            return Content("xóa thành công");
        }

        private bool TepExists(int id)
        {
            return _context.Tep.Any(e => e.Id == id);
        }
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }
        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
    }
}
