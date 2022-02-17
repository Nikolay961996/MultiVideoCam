using Microsoft.EntityFrameworkCore;
using MultiVideoCam.Data.EntityConfigurations;
using MultiVideoCam.Data.Entities;

namespace MultiVideoCam.Data
{
    public class CamerasDbContext : DbContext
    {
        public CamerasDbContext(DbContextOptions<CamerasDbContext> options)
            : base(options)
        {
        }

        public DbSet<Camera> Cameras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CameraConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
