using AirPlaneDDD.Domain.Entities;
using AirPlaneDDD.Infra.Config.EntitysConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AirPlaneDDD.Infra.Config
{
    public class ContextBase : DbContext
    {

        public ContextBase() { }

        public ContextBase(DbContextOptions<ContextBase> options) : base(options) {}

        public DbSet<AirPlaneModel> AirPlaneModel { get; set; }

        public DbSet<AirPlane> AirPlane { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AirPlaneModelConfigurations());
            modelBuilder.ApplyConfiguration(new AirPlaneConfigurations());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                   .UseSqlServer(this.StringConnectionConfig()); //.UseLazyLoadingProxies()
            }
        }

        private string StringConnectionConfig()
        {
            var conn = "Data Source=localhost;Initial Catalog=AirPlaneDDD;Integrated Security=False;User ID =sa;Password=@Trunks";

            return conn;
        }
    }
}
