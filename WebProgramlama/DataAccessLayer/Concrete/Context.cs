using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=tcp:projeaylin.database.windows.net,1433;Initial Catalog=y;Integrated Security=False;User Id=sqladmin@projeaylin;Password=1234Aylin...;Encrypt=True;TrustServerCertificate=False;MultipleActiveResultSets=True");
        }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public Context()
        {
        }

        public DbSet<AppUser> appusers { get; set; }
        public DbSet<mesaj> mesajlar { get; set; }
       
        public DbSet<AppAntrenor> Antrenors { get; set; }

        public DbSet<AppDanisan> Danisans { get; set; }

        public DbSet<EgzersizProgrami> EgzersizProgramis { get; set; }

        public DbSet<BeslenmePlani> BeslenmePlanis { get; set; }

     


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
          


        }




    }
}
