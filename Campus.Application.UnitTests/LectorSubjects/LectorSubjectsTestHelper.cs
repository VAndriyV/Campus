using Campus.Domain.Entities;
using Campus.Persistence;
using System;

namespace Campus.Application.UnitTests.LectorSubjects
{
    static class LectorSubjectsTestHelper
    {
        public static void LoadLectorSubjectsTestData(CampusDbContext context)
        {
            context.AcademicRanks.Add(new AcademicRank { Id = 1, Name = "Academic rank 1" });
            context.AcademicDegrees.Add(new AcademicDegree { Id = 1, Name = "Academic degree 1" });
            context.Users.Add(new User { Id = 100, Email = "email1@mail.com", PasswordHash = "testPassword123", LastVisit = DateTime.Now });
            context.UserRoles.Add(new UserRole { RoleId = 1, UserId = 100 });           

            context.Specialities.Add(new Speciality { Id = 1, Name = "Test Speciality 1", Code = 100 });
            context.EducationalDegrees.Add(new EducationalDegree { Id = 1, Name = "Educational Degree 1" });
            context.Groups.Add(new Group { Id = 1, EducationalDegreeId = 1, Name = "Group 1", SpecialityId = 1, StudentsCount = 10, Year = 1 });

            context.Lectors.Add(new Lector
            {
                Id = 1,
                FirstName = "Name 1",
                LastName = "LastName 1",
                Patronymic = "Patronymic 1",
                AcademicDegreeId = 1,
                AcademicRankId = 1,
                UserId = 100,
                Email = "email1@mail.com",
                PhoneNumber = "+99999999999"
            });
            context.LessonTypes.Add(new LessonType { Id = 1, Name = "Lesson type 1" });

            context.Subjects.Add(new Subject { Id = 1, Name = "Subject 1" });
            context.Subjects.Add(new Subject { Id = 2, Name = "Subject 2" });

            context.LectorSubjects.Add(new LectorSubject { Id = 1, LectorId = 1, SubjectId = 1, LessonTypeId = 1 });
            context.LectorSubjects.Add(new LectorSubject { Id = 2, LectorId = 1, SubjectId = 2, LessonTypeId = 1});

            context.WeatherTypes.Add(new WeatherType { Id = 1, Name = "Weather type 1" });

            context.Lessons.Add(new Lesson { Id = 1, GroupId = 1, LectorSubjectId = 2 });

            context.SaveChanges();
        }
    }
}
