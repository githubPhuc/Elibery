
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
        //public DbSet<Elibery.Models.TaiLieu>? TaiLieus { get; set; }
        //public DbSet<Elibery.Models.cauhoi>? cauhois { get; set; }
        //public DbSet<Elibery.Models.dapan>? dapans { get; set; }
        public DbSet<Elibery.Models.ThongBao>? ThongBao { get; set; }

    }
}
