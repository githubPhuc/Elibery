using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Elibery.Models
{
    public class PhanQuyen
    {
        //1 tài khoản có nhiều quyền
        //Trần Ninh phúc
        //Khởi tạo 2:41 12/4/2022
        [Key]
        public int Id { get; set; }
        public string TenQuyen { get; set; }
        public bool TrangThai { get; set; }
    }
}