using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DayOfWeek = Campus.Domain.Entities.DayOfWeek;

namespace Campus.Persistence.Configurations
{
    public class DayOfWeekConfiguration : IEntityTypeConfiguration<DayOfWeek>
    {
        public void Configure(EntityTypeBuilder<DayOfWeek> builder)
        {
            builder.HasKey(x => x.Id)
                .IsClustered(false);

            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasMany(d=>d.Attendances)
                .WithOne(a=>a.DayOfWeek)
                .HasForeignKey(a=>a.DayOfWeekId)
                .IsRequired();
        }
    }
}
