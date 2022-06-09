using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elibery.Models
{
    public class MonHoc
    {
        //nhiều môn học trong 1 lớp học 
        //Trần Ninh phúc
        //Khởi tạo 2:41 12/4/2022
        [Key]
        public int Id { get; set; }
        public string TenMonHoc { get; set; }
        public string MoTa { get; set; }//mô tả về môn học 
        public int BoMonId { get; set; }
        public BoMon boMon { get; set; }
        public int idLopHoc { get; set; }
        public LopHoc lopHocId { get; set; }
        public bool TinhTrang { get; set; }
        public List<TaiLieu> taiLieus { get; set; }
        public List<DeThi> deThis { get; set; }

    }
}
