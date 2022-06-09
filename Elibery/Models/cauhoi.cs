using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elibery.Models
{
    public class cauhoi
    {
        [Key]
        public int id { get; set; }
        public int idDeThi { get; set; }
        public DeThi? deThi { get; set; }
        public string cauHoi { get; set; }
        public string dokho { get; set; }
        public bool trangthai { get; set; }
        public List<dapan> dapans { get; set; }

    }
}
