using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Elibery.Models
{
    public class LopHoc
    {
        //1 lớp học có nhiều học sinh
        //1 lớp học có nhiều môn học 
        //Trần Ninh phúc
        //Khởi tạo 2:41 12/4/2022
        [Key]
        public int Id { get; set; }
        public string TenLop { get; set; }
        public int loaiId { get; set; }
        public LoaiLopHoc loaiLopHoc { get; set; }
        public string NienKhoa { get; set; }
        public List<MonHoc> monHocs { get; set; }
        public List<DeThi> deThis { get; set; }
    }
}
