using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elibery.Models
{
    public class ThongBao
    {
        [Key]
        public int Id { get; set; }
        public string? LoaiThongBao { get; set; }
        public int? idQuyen { get; set; }
        public PhanQuyen? phanQuyen { get; set; }
        public string? ChuDe { get; set; }
        public string? NoiDung { get; set; }
        public DateTime? ThoiGian { get; set; }

    }
}
