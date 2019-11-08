using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Campus.Domain.Entities;

namespace Campus.Persistence.Configurations
{
    public class LectorSubjectConfiguration : IEntityTypeConfiguration<LectorSubject>
    {
        public void Configure(EntityTypeBuilder<LectorSubject> builder)
        {
            builder.HasKey(ls => new { ls.LectorId, ls.SubjectId });

            builder.HasOne(ls=>ls.LessonType)
                .WithMany(lt=>lt.LectorSubjects)
                .HasForeignKey(ls=>ls.LessonTypeId);

            builder.HasOne(ls => ls.Subject)
                .WithMany(s=>s.LectorSubjects)
                .HasForeignKey(ls=>ls.SubjectId)
                .IsRequired();

            builder.HasOne(ls => ls.Lector)
                .WithMany(l => l.LectorSubjects)
                .HasForeignKey(ls => ls.LectorId)
                .IsRequired();
        }
    }
}
