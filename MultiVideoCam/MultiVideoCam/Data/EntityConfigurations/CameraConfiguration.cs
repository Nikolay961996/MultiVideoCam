using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiVideoCam.Data.Entities;

namespace MultiVideoCam.Data.EntityConfigurations
{
    public class CameraConfiguration : IEntityTypeConfiguration<Camera>
    {
        public void Configure(EntityTypeBuilder<Camera> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Link).HasMaxLength(300);
            builder.HasQueryFilter(i => i.DeletedDate == null);
        }
    }
}
