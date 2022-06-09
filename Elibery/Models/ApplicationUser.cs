using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Elibery.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        public VaiTro? VaiTro { get; set; }
        public List<TaiLieu>? TaiLieu { get; set; }
        public List<DeThi>? DeThi { get; set; }
    }
}
