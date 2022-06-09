using Elibery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elibery.Models
{
    public class HoiDap
    {
        public int? Id { get; set; }
        public string TaiKhoanId { get; set; }
        public ApplicationUser? TaiKhoan { get; set; }
        public string? ChuDe { get; set; }
        public string? NoiDung { get; set; }
    }
}
