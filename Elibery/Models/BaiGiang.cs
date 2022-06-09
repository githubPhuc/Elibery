using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elibery.Models
{
    public class BaiGiang
    {
        public int Id { get; set; }
        public string? tenBaiGiang { get; set; }
        public int MonHocId { get; set; }
        public MonHoc ?MonHoc { get; set; }
        public int NguoiChinhSua { get; set; }
        public int NguoiChinhSuaCuoi { get; set; }
        public bool PheDuyet { get; set; }
        public int idTep { get; set; }
        public Tep ?tep { get; set; }
    }
}
