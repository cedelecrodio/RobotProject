using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Config
{
    public class ContextBase : DbContext
    {

        public ContextBase()
        {

        }
        public ContextBase(DbContextOptions<ContextBase> options ) : base(options)
        {

        }

        public DbSet<Robot> Robot { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetStringConnect());
                base.OnConfiguring(optionsBuilder);
            }
        }

        public string GetStringConnect()
        {
            return "server=localhost\\SQLEXPRESS01;database=Robot;trusted_connection=true;TrustServerCertificate=True";
        }
    }
}
