using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elibery.Models
{
    public class NguoiDung
    {
        [Key]
        public int Id { get; set; }
        public string Ten { get; set; }
        public string Email { get; set; }
        public int LopHocId { get; set; }
        public LopHoc LopHoc { get; set; }
        public int VaitroId { get; set; }
        public VaiTro VaiTro { get; set; }
        public List<TaiLieu> TaiLieu { get; set; }
        public List<BaiGiang> BaiGiang { get; set; }
        public List<DeThi> DeThi { get; set; }
    }
}
