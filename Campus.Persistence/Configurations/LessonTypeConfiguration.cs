using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Campus.Domain.Entities;

namespace Campus.Persistence.Configurations
{
    public class LessonTypeConfiguration : IEntityTypeConfiguration<LessonType>
    {
        public void Configure(EntityTypeBuilder<LessonType> builder)
        {
            builder.HasKey(x => x.Id)
               .IsClustered(false);

            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(lt=>lt.LectorSubjects)
                .WithOne(ls=>ls.LessonType)
                .HasForeignKey(ls => ls.LessonTypeId)
                .IsRequired();
        }
    }
}
