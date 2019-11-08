using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Campus.Domain.Entities;

namespace Campus.Persistence.Configurations
{
    public class EducationalDegreeConfiguration : IEntityTypeConfiguration<EducationalDegree>
    {
        public void Configure(EntityTypeBuilder<EducationalDegree> builder)
        {
            builder.HasKey(x => x.Id)
                .IsClustered(false);

            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Name).HasMaxLength(15);

            builder.HasMany(ed=>ed.Groups)
                .WithOne(g=>g.EducationalDegree)
                .HasForeignKey(g=>g.EducationalDegreeId);
        }
    }
}
