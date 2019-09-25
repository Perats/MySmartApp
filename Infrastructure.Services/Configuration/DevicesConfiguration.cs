using Infrastructure.Interface.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Services.Configuration
{
    public class DevicesConfiguration : IEntityTypeConfiguration<DevicesInfrastructureModel>
    {
        public void Configure(EntityTypeBuilder<DevicesInfrastructureModel> builder)
        {
           // builder.ToTable("DevicesViewModel");

            builder.HasKey(_ => _.Id);
        }
    }
}
