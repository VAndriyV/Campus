using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Campus.Domain.Entities;

namespace Campus.Persistence.Configurations
{
    public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();

            builder.Property(a => a.Date)
                .HasColumnType("datetime")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(a => a.StudentsCount)
                .IsRequired();

            builder.HasOne(a=>a.Lesson)
               .WithMany(l => l.Attendances)
               .HasForeignKey(a=>a.LessonId)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired();

            builder.HasOne(a => a.DayOfWeek)
               .WithMany(d => d.Attendances)
               .HasForeignKey(a =>a.DayOfWeekId)
               .IsRequired();

            builder.HasOne(a => a.WeatherType)
               .WithMany(w => w.Attendances)
               .HasForeignKey(a => a.WeatherTypeId)
               .IsRequired();
        }
    }
}
