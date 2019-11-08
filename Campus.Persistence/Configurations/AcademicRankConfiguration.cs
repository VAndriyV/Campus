using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Campus.Domain.Entities;

namespace Campus.Persistence.Configurations
{
    public class AcademicRankConfiguration : IEntityTypeConfiguration<AcademicRank>
    {
        public void Configure(EntityTypeBuilder<AcademicRank> builder)
        {
            builder.HasKey(x => x.Id)
                .IsClustered(false);

            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(ar => ar.Lectors)
                .WithOne(l=>l.AcademicRank)
                .HasForeignKey(l=>l.AcademicRankId)
                .IsRequired();
        }
    }
}
