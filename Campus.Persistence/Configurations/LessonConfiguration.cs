using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Campus.Domain.Entities;

namespace Campus.Persistence.Configurations
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(l => l.Group)
                .WithMany(g=>g.Lessons)
                .HasForeignKey(l => l.GroupId)
                .IsRequired();

            builder.HasOne(l => l.LectorSubject)
                .WithMany(ls => ls.Lessons)
                .HasForeignKey(l => l.LectorSubjectId)
                .IsRequired();

            builder.HasMany(l => l.Attendances)
                .WithOne(a => a.Lesson)
                .HasForeignKey(a => a.LessonId)
                .IsRequired();
        }
    }
}
