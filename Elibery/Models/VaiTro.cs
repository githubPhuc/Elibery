using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elibery.Models
{
    public class VaiTro
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Tên vai trò")]
        public string TenVaiTro { get; set; }
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }
        public int idQuyen { get; set; }
        public string ThongBao { get; set; }
        public PhanQuyen phanQuyen { get; set; }

    }
}
