using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elibery.Models
{
    public class LoaiLopHoc
    {
        [Key]
        public int id { get; set; }
        public string tenLoai { get; set; }
        public bool trangThai { get; set; }
        
    }
}
