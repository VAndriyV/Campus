using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Campus.Domain.Entities;

namespace Campus.Persistence.Configurations
{
    public class WeatherTypeConfiguration : IEntityTypeConfiguration<WeatherType>
    {
        public void Configure(EntityTypeBuilder<WeatherType> builder)
        {
            builder.HasKey(x => x.Id)
                .IsClustered(false);

            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(wt=>wt.Attendances)
                .WithOne(a=>a.WeatherType)
                .HasForeignKey(a => a.WeatherTypeId)
                .IsRequired();
        }
    }
}
