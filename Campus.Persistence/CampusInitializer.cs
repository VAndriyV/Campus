using System;
using System.Linq;

using Campus.Domain.Entities;
using DayOfWeek = Campus.Domain.Entities.DayOfWeek;

namespace Campus.Persistence
{
    public class CampusInitializer
    {  
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

            SeedRoles(context);
            SeedUsers(context);
            SeedUserRoles(context);

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
        }

        private void SeedAcademicDegrees(CampusDbContext context)
        {
            var academicDegrees = new[]
            {
                new AcademicDegree{ Id = 1, Name="Higher doctorate"},
                new AcademicDegree{Id = 2, Name ="PhD" }
            };

            context.AcademicDegrees.AddRange(academicDegrees);

            context.SaveChanges();
        }

        private void SeedAcademicRanks(CampusDbContext context)
        {
            var academicRanks = new[]
            {
                new AcademicRank{Id= 1, Name = "Research fellow"},
                new AcademicRank{Id = 2, Name = "Associate professor"},
                new AcademicRank{Id = 3, Name = "Professor"}
            };

            context.AcademicRanks.AddRange(academicRanks);

            context.SaveChanges();
        }

        private void SeedAttendances(CampusDbContext context)
        {
            /*var attendances = new[]
            {
                new Attendance{}
            };

            context.Attendances.AddRange(attendances);

            context.SaveChanges();*/
        }

        private void SeedDayOfWeeks(CampusDbContext context)
        {
            var dayOfWeeks = new[]
            {
                new DayOfWeek{Id = 1, Name="Monday"},
                new DayOfWeek{Id = 2, Name ="Tuesday"},
                new DayOfWeek{Id = 3, Name = "Wednesday"},
                new DayOfWeek{Id = 4, Name="Thursday"},
                new DayOfWeek{Id = 5, Name = "Friday"},
                new DayOfWeek{Id = 6, Name = "Saturday"},
                new DayOfWeek{Id = 7, Name="Sunday"}
            };

            context.DayOfWeeks.AddRange(dayOfWeeks);

            context.SaveChanges();
        }

        private void SeedEducationalDegrees(CampusDbContext context)
        {
            var educationalDegrees = new[]
            {
                new EducationalDegree{Id = 1 , Name="Bachelor degree"},
                new EducationalDegree{Id = 2, Name="Master degree"}
            };

            context.EducationalDegrees.AddRange(educationalDegrees);

            context.SaveChanges();
        }

        private void SeedGroups(CampusDbContext context)
        {
            var groups = new[]
            {
                new Group{Id = 1, Name="TB-61", SpecialityId=1, StudentsCount=24, EducationalDegreeId = 1, Year = 4},
                new Group{Id = 2, Name="TB-71", SpecialityId=1, StudentsCount=14, EducationalDegreeId = 1, Year = 3},
                new Group{Id = 3, Name="TP-81", SpecialityId=2, StudentsCount=20, EducationalDegreeId = 1, Year = 2},
                new Group{Id = 4, Name="TI-91M", SpecialityId=1, StudentsCount=10, EducationalDegreeId = 2, Year = 1},
                new Group{Id = 5, Name="TM-91", SpecialityId=1, StudentsCount=24, EducationalDegreeId = 1, Year = 1},
                new Group{Id = 6, Name="TI-81", SpecialityId=2, StudentsCount=28, EducationalDegreeId = 1, Year = 2},
                new Group{Id = 7, Name="TM-91M", SpecialityId=2, StudentsCount=8, EducationalDegreeId = 1, Year = 1}
            };

            context.Groups.AddRange(groups);

            context.SaveChanges();
        }

        private void SeedLectors(CampusDbContext context)
        {
            var lectors = new[]
            {
                new Lector{Id = 1, FirstName="John", LastName="Patron",Patronymic="Michael",
                           AcademicDegreeId=1,AcademicRankId=2, UserId = 1,
                           Email = "email1@mail.com",PhoneNumber ="+380449212345"},
                new Lector{Id = 2, FirstName="Jack", LastName="Johnes",Patronymic="Donald",
                           AcademicDegreeId=2,AcademicRankId=3, UserId = 2,
                           Email = "email2@mail.com",PhoneNumber ="+380509212345"},
                new Lector{Id = 3, FirstName="Mark", LastName="Clapton",Patronymic="Steven",
                           AcademicDegreeId=1,AcademicRankId=1, UserId = 3,
                           Email = "email3@mail.com",PhoneNumber ="+38099921235"},
                new Lector{Id = 4, FirstName="Louie", LastName="Vaughan",Patronymic="Raynold",
                           AcademicDegreeId=2,AcademicRankId=1, UserId = 4,
                           Email = "email4@mail.com",PhoneNumber ="+380891231232"}
            };

            context.Lectors.AddRange(lectors);

            context.SaveChanges();
        }

        private void SeedLectorSubjects(CampusDbContext context)
        {
            var lectorSubjects = new[]
            {
                new LectorSubject{Id = 1, LectorId = 1, SubjectId = 1, LessonTypeId = 1},
                new LectorSubject{Id = 2, LectorId = 2, SubjectId = 1, LessonTypeId = 2},
                new LectorSubject{Id = 3, LectorId = 1, SubjectId = 2, LessonTypeId = 3},
                new LectorSubject{Id = 4, LectorId = 3, SubjectId = 3, LessonTypeId = 2},
                new LectorSubject{Id = 5, LectorId = 4, SubjectId = 4, LessonTypeId = 1},
                new LectorSubject{Id = 6, LectorId = 4, SubjectId = 5, LessonTypeId = 3},
                new LectorSubject{Id = 7, LectorId = 1, SubjectId = 2, LessonTypeId = 1},
                new LectorSubject{Id = 8, LectorId = 2, SubjectId = 1, LessonTypeId = 3},
                new LectorSubject{Id = 9, LectorId = 3, SubjectId = 3, LessonTypeId = 1},
                new LectorSubject{Id = 10, LectorId = 4, SubjectId = 4, LessonTypeId = 2},
                new LectorSubject{Id = 11, LectorId = 1, SubjectId = 5, LessonTypeId = 2},
                new LectorSubject{Id = 12, LectorId = 4, SubjectId = 2, LessonTypeId = 2},
                new LectorSubject{Id = 13, LectorId = 2, SubjectId = 1, LessonTypeId = 3},
                new LectorSubject{Id = 14, LectorId = 3, SubjectId = 2, LessonTypeId = 1},
                new LectorSubject{Id = 15, LectorId = 3, SubjectId = 4, LessonTypeId = 2},
                new LectorSubject{Id = 16, LectorId = 4, SubjectId = 5, LessonTypeId = 3},
                new LectorSubject{Id = 17, LectorId = 2, SubjectId = 6, LessonTypeId = 1},
                new LectorSubject{Id = 18, LectorId = 1, SubjectId = 1, LessonTypeId = 2}
            };

            context.LectorSubjects.AddRange(lectorSubjects);

            context.SaveChanges();
        }

        private void SeedLessons(CampusDbContext context)
        {
            var lessons = new[]
            {
                new Lesson{Id = 1, GroupId = 1, LectorSubjectId = 1},
                new Lesson{Id = 2, GroupId = 1, LectorSubjectId = 2},
                new Lesson{Id = 3, GroupId = 1, LectorSubjectId = 3},
                new Lesson{Id = 4, GroupId = 1, LectorSubjectId = 4},
                new Lesson{Id = 5, GroupId = 2, LectorSubjectId = 5},
                new Lesson{Id = 6, GroupId = 2, LectorSubjectId =6},
                new Lesson{Id = 7, GroupId = 2, LectorSubjectId = 7},
                new Lesson{Id = 8, GroupId = 2, LectorSubjectId = 7},
                new Lesson{Id = 9, GroupId = 2, LectorSubjectId = 9},
                new Lesson{Id = 10, GroupId = 2, LectorSubjectId = 10},
                new Lesson{Id = 11, GroupId = 2, LectorSubjectId = 11},
                new Lesson{Id = 12, GroupId = 3, LectorSubjectId = 12},
                new Lesson{Id = 13, GroupId = 3, LectorSubjectId = 13},
                new Lesson{Id = 14, GroupId = 3, LectorSubjectId = 14},
                new Lesson{Id = 15, GroupId = 3, LectorSubjectId = 15},
                new Lesson{Id = 16, GroupId = 3, LectorSubjectId = 16},
                new Lesson{Id = 17, GroupId = 4, LectorSubjectId = 17},
                new Lesson{Id = 18, GroupId = 4, LectorSubjectId = 18},
                new Lesson{Id = 19, GroupId = 5, LectorSubjectId = 13},
                new Lesson{Id = 20, GroupId = 5, LectorSubjectId = 12},
                new Lesson{Id = 21, GroupId = 5, LectorSubjectId = 11},
                new Lesson{Id = 22, GroupId = 5, LectorSubjectId = 10},
                new Lesson{Id = 23, GroupId = 5, LectorSubjectId = 9},
                new Lesson{Id = 24, GroupId = 5, LectorSubjectId = 8},
                new Lesson{Id = 25, GroupId = 6, LectorSubjectId = 7},
                new Lesson{Id = 26, GroupId = 6, LectorSubjectId = 6},
                new Lesson{Id = 27, GroupId = 6, LectorSubjectId = 5},
                new Lesson{Id = 28, GroupId = 7, LectorSubjectId = 4},
                new Lesson{Id = 29, GroupId = 7, LectorSubjectId = 3},
                new Lesson{Id = 30, GroupId = 7, LectorSubjectId = 2},
                new Lesson{Id = 31, GroupId = 7, LectorSubjectId = 1}
            };

            context.Lessons.AddRange(lessons);

            context.SaveChanges();
        }

        private void SeedLessonTypes(CampusDbContext context)
        {
            var lessonTypes = new[]
            {
                new LessonType{Id = 1, Name="Lection"},
                new LessonType{Id = 2, Name="Lab"},
                new LessonType{Id = 3, Name="Seminar/Practice"}
            };

            context.LessonTypes.AddRange(lessonTypes);

            context.SaveChanges();
        }

        private void SeedRoles(CampusDbContext context)
        {
            var roles = new[]
            {
                new Role{Id = 100,Name = "SuperAdmin"},
                new Role{Id = 1, Name = "Lector"},
                new Role{Id = 2, Name = "Admin"}
            };

            context.Roles.AddRange(roles);

            context.SaveChanges();
        }

        private void SeedSpecialities(CampusDbContext context)
        {
            var specialities = new[]
            {
                new Speciality{Id = 1, Name="Software engineering",Code=121},
                new Speciality{Id = 2, Name="Computer science", Code = 122}               
            };

            context.Specialities.AddRange(specialities);

            context.SaveChanges();
        }

        private void SeedSubjects(CampusDbContext context)
        {
            var subjects = new[]
            {
                new Subject{ Id = 1, Name = "Design and Analysis Of Algorithms"},
                new Subject{ Id = 2, Name = "Data Structures"},
                new Subject{ Id = 3, Name = "Object Oriented Programming"},
                new Subject{ Id = 4, Name = "Operating Systems"},
                new Subject{ Id = 5, Name = "Probability Statistics and Numerical Techniques"},
                new Subject{ Id = 6, Name = "Compiler Design"},
                new Subject{ Id = 7, Name = "System Software"},
                new Subject{ Id = 8, Name = "Artificial Intelligence"},
                new Subject{ Id = 9, Name = "Theory of Computation"}
            };

            context.Subjects.AddRange(subjects);

            context.SaveChanges();
        }

        private void SeedUsers(CampusDbContext context)
        {
            var users = new[]
            {
                new User{Id = 1, Email ="email1@mail.com", IsActive = true, PasswordHash="password123", LastVisit = DateTime.Now},
                new User{Id = 2, Email ="email2@mail.com", IsActive = true, PasswordHash="password123", LastVisit = DateTime.Now},
                new User{Id = 3, Email ="email3@mail.com", IsActive = true, PasswordHash="password123", LastVisit = DateTime.Now},
                new User{Id = 4, Email ="email4@mail.com", IsActive = true, PasswordHash="password123", LastVisit = DateTime.Now},
                new User{Id = 5, Email ="admin@mail.com", IsActive = true, PasswordHash="password123",  LastVisit= DateTime.Now},
                new User{Id = 6, Email ="superAdmin@mail.com", IsActive = true, PasswordHash="password123", LastVisit= DateTime.Now},
            };

            context.Users.AddRange(users);

            context.SaveChanges();
        }

        private void SeedUserRoles(CampusDbContext context)
        {
            var userRoles = new[]
            {
                new UserRole{ UserId = 1, RoleId = 1 },
                new UserRole{ UserId = 2, RoleId = 1 },
                new UserRole{ UserId = 3, RoleId = 1 },
                new UserRole{ UserId = 4, RoleId = 1 },
                new UserRole{ UserId = 5, RoleId = 2 },
                new UserRole{ UserId = 6, RoleId = 100 },
            };

            context.UserRoles.AddRange(userRoles);

            context.SaveChanges();
        }

        private void SeedWeatherTypes(CampusDbContext context)
        {
            var weatherTypes = new[]
            {
                new WeatherType{Id = 1, Name="Sunny"},
                new WeatherType{Id = 2, Name="Cloudy"},
                new WeatherType{Id = 3, Name="Overcast"},
                new WeatherType{Id = 4, Name="Thunder storm"},
                new WeatherType{Id = 5, Name="Snowy"},
                new WeatherType{Id = 6, Name="Rain"}
            };

            context.WeatherTypes.AddRange(weatherTypes);

            context.SaveChanges();
        }
    }
}
