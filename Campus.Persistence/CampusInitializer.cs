using Campus.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Campus.Persistence
{
    public class CampusInitializer
    {
        private readonly Dictionary<int, Group> Groups = new Dictionary<int, Group>();
        private readonly Dictionary<int, Lesson> Lessons = new Dictionary<int, Lesson>();
        private readonly Dictionary<int, Lector> Lectors = new Dictionary<int, Lector>();
        private readonly Dictionary<int, LectorSubject> LectorSubjects = new Dictionary<int, LectorSubject>();

        public static void Initialize(CampusDbContext context)
        {
            var initializer = new CampusInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(CampusDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Groups.Any())
            {
                return; // Db has been seeded
            }

            SeedAcademicDegrees(context);
            SeedAcademicRanks(context);
            SeedDayOfWeeks(context);
            SeedEducationalDegrees(context);
            SeedWeatherTypes(context);
            SeedLessonTypes(context);
            SeedSpecialities(context);
            SeedSubjects(context);
            SeedGroups(context);
            SeedLectors(context);
            SeedLectorSubjects(context);
            SeedLessons(context);
            SeedAttendances(context);

            SeedRoles(context);
            SeedUsers(context);
            SeedUserRoles(context);

        }

        private void SeedAcademicDegrees(CampusDbContext context)
        {
            var academicDegrees = new[]
            {
                new AcademicDegree{}
            };

            context.AcademicDegrees.AddRange(academicDegrees);

            context.SaveChanges();
        }

        private void SeedAcademicRanks(CampusDbContext context)
        {
            var academicRanks = new[]
            {
                new AcademicRank{}
            };

            context.AcademicRanks.AddRange(academicRanks);

            context.SaveChanges();
        }

        private void SeedAttendances(CampusDbContext context)
        {
            var attendances = new[]
            {
                new Attendance{}
            };

            context.Attendances.AddRange(attendances);

            context.SaveChanges();
        }

        private void SeedDayOfWeeks(CampusDbContext context)
        {
            var dayOfWeeks = new[]
            {
                new DayOfWeek{}
            };

            context.DayOfWeeks.AddRange(dayOfWeeks);

            context.SaveChanges();
        }

        private void SeedEducationalDegrees(CampusDbContext context)
        {
            var educationalDegrees = new[]
            {
                new EducationalDegree{}
            };

            context.EducationalDegrees.AddRange(educationalDegrees);

            context.SaveChanges();
        }

        private void SeedGroups(CampusDbContext context)
        {
            var groups = new[]
            {
                new Group{}
            };

            context.Groups.AddRange(groups);

            context.SaveChanges();
        }

        private void SeedLectors(CampusDbContext context)
        {
            var lectors = new[]
            {
                new Lector{}
            };

            context.Lectors.AddRange(lectors);

            context.SaveChanges();
        }

        private void SeedLectorSubjects(CampusDbContext context)
        {
            var lectorSubjects = new[]
            {
                new LectorSubject{}
            };

            context.LectorSubjects.AddRange(lectorSubjects);

            context.SaveChanges();
        }

        private void SeedLessons(CampusDbContext context)
        {
            var lessons = new[]
            {
                new Lesson{}
            };

            context.Lessons.AddRange(lessons);

            context.SaveChanges();
        }

        private void SeedLessonTypes(CampusDbContext context)
        {
            var lessonTypes = new[]
            {
                new LessonType{}
            };

            context.LessonTypes.AddRange(lessonTypes);

            context.SaveChanges();
        }

        private void SeedRoles(CampusDbContext context)
        {
            var roles = new[]
            {
                new Role{}
            };

            context.Roles.AddRange(roles);

            context.SaveChanges();
        }

        private void SeedSpecialities(CampusDbContext context)
        {
            var specialities = new[]
            {
                new Speciality{}
            };

            context.Specialities.AddRange(specialities);

            context.SaveChanges();
        }

        private void SeedSubjects(CampusDbContext context)
        {
            var subjects = new[]
            {
                new Subject{}
            };

            context.Subjects.AddRange(subjects);

            context.SaveChanges();
        }

        private void SeedUsers(CampusDbContext context)
        {
            var users = new[]
            {
                new User{}
            };

            context.Users.AddRange(users);

            context.SaveChanges();
        }

        private void SeedUserRoles(CampusDbContext context)
        {
            var userRoles = new[]
            {
                new UserRole{}
            };

            context.UserRoles.AddRange(userRoles);

            context.SaveChanges();
        }

        private void SeedWeatherTypes(CampusDbContext context)
        {
            var weatherTypes = new[]
            {
                new WeatherType{}
            };

            context.WeatherTypes.AddRange(weatherTypes);

            context.SaveChanges();
        }
    }
}
