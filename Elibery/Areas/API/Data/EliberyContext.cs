
using Microsoft.EntityFrameworkCore;
using Elibery.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Elibery.Data
{
    //public class EliberyContext : DbContext
    //{
    //    public EliberyContext (DbContextOptions<EliberyContext> options)
    //        : base(options)
    //    {
    //    }

    //    public DbSet<Elibery.Models.BaiGiang>? BaiGiang { get; set; }
    //}
    public class EliberyContext : IdentityDbContext<ApplicationUser>
    {
        public EliberyContext(DbContextOptions<EliberyContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Elibery.Models.BaiGiang>? BaiGiang { get; set; }
        public DbSet<Elibery.Models.Tep>? Tep { get; set; }
        public DbSet<Elibery.Models.TaiLieu>? TaiLieu { get; set; }
        public DbSet<Elibery.Models.cauhoi>? cauhoi { get; set; }
        public DbSet<Elibery.Models.dapan>? dapan { get; set; }
        public DbSet<Elibery.Models.ThongBao>? ThongBao { get; set; }
        public DbSet<Elibery.Models.VaiTro>? VaiTro { get; set; }
        public DbSet<Elibery.Models.DeThi>? DeThi { get; set; }
        public DbSet<Elibery.Models.ThuVien>? ThuVien { get; set; }
        public DbSet<Elibery.Models.LoaiLopHoc>? LoaiLopHoc { get; set; }
        public DbSet<Elibery.Models.BoMon>? BoMon { get; set; }
        public DbSet<Elibery.Models.LopHoc>? LopHoc { get; set; }
        public DbSet<Elibery.Models.MonHoc>? MonHoc { get; set; }

    }
}
