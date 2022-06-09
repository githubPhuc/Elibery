using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elibery.Models
{
    public class ThuVien
    {
        [Key]
        public int Id { get; set; }
        public string? MaTruongHoc { get; set; }
        public string? TenTruongHoc { get; set; }
        public string? HieuTruong { get; set; }
        public string? Website { get; set; }
        public string? TenHeThong { get; set; }
        public string? DiaChiTruyCap { get; set; }
        public string? SoDienThoai { get; set; }
        public string? Gmail { get; set; }
        public string? NgonNguXacDinh { get; set; }
        public string? NienKhoaMacDinh { get; set; }
        public bool? TrangThai { get; set; }
    }
}
