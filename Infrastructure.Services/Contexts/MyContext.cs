using Infrastructure.Interface.Models;
using Infrastructure.Services.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Contexts
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

       // public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<DevicesInfrastructureModel> Device { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            base.OnModelCreating(modelBuilder
                .ApplyConfiguration(new DevicesConfiguration())
                );
    }
}
