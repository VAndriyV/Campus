using Microsoft.EntityFrameworkCore;

using Campus.Domain.Entities;
using DayOfWeek = Campus.Domain.Entities.DayOfWeek;
using Campus.Persistence.Extensions;

namespace Campus.Persistence
{
    public class CampusDbContext : DbContext
    {
        public CampusDbContext(DbContextOptions<CampusDbContext> options) : base(options)
        {
        }

        public DbSet<AcademicDegree> AcademicDegrees { get; set; }
        public DbSet<AcademicRank> AcademicRanks { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<DayOfWeek> DayOfWeeks { get; set; }
        public DbSet<EducationalDegree> EducationalDegrees { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Lector> Lectors { get; set; }
        public DbSet<LectorSubject> LectorSubjects { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonType> LessonTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<WeatherType> WeatherTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurations();
        }
    }
}
