using Campus.Domain.Entities;
using Campus.Persistence;
using System;

namespace Campus.Application.UnitTests.Subjects
{
    static class SubjectsTestHelper
    {
        public static void LoadSubjectsTestData(CampusDbContext context)
        {
            context.AcademicRanks.Add(new AcademicRank { Id = 1, Name = "Academic rank 1" });
            context.AcademicDegrees.Add(new AcademicDegree { Id = 1, Name = "Academic degree 1" });
            context.Users.Add(new User {Id = 100, Email = "email1@mail.com", PasswordHash = "testPassword123", LastVisit = DateTime.Now });
            context.UserRoles.Add(new UserRole { RoleId = 1, UserId = 100 });
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

            context.LectorSubjects.Add(new LectorSubject { LectorId = 1, SubjectId = 2 });

            context.SaveChangesAsync();
        }
    }
}
