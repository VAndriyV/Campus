using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Campus.Domain.Entities;

namespace Campus.Persistence.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id)
                .ValueGeneratedOnAdd();

            builder.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(g => g.Year)
                .IsRequired();

            builder.Property(g => g.StudentsCount)
                .IsRequired();

            builder.HasMany(g => g.Lessons)
                .WithOne(l => l.Group)
                .HasForeignKey(l => l.GroupId)
                .IsRequired();

            builder.HasOne(g=>g.Speciality)
                .WithMany(s=>s.Groups)
                .HasForeignKey(g=>g.SpecialityId)
                .IsRequired();

            builder.HasOne(g => g.EducationalDegree)
                .WithMany(s => s.Groups)
                .HasForeignKey(g => g.EducationalDegreeId)
                .IsRequired();
        }
    }
}
