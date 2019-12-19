using Campus.Domain.Entities;
using Campus.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests
{
    public abstract class TestBase : IDisposable
    {
        protected CampusDbContext Context { get; private set; }

        protected TestBase(bool useSqlLite = false)
        {
            InitDbContext(useSqlLite);          
        }

        protected void InitDbContext(bool useSqlLite = false)
        {
            var builder = new DbContextOptionsBuilder<CampusDbContext>();
            if (useSqlLite)
            {
                builder.UseSqlite("DataSource=:memory:", x => { });
            }
            else
            {
                builder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            }

            var dbContext = new CampusDbContext(builder.Options);
            if (useSqlLite)
            {                
                dbContext.Database.OpenConnection();
            }

            dbContext.Database.EnsureCreated();

            Context = dbContext;
        }

        protected virtual void LoadTestData()
        {
            var roles = new[]
            {
                new Role{Id = 100,Name = "SuperAdmin"},
                new Role{Id = 1, Name = "Lector"},
                new Role{Id = 2, Name = "Admin"}
            };

            Context.Roles.AddRange(roles);

            var users = new[]
            {
                new User{Email ="Admin@mail.com",  PasswordHash="testPassword123",  LastVisit = DateTime.Now},
                new User{Email ="SuperAdmin@mail.com", PasswordHash="testPassword123", LastVisit = DateTime.Now},
            };

            Context.Users.AddRange(users);

            var userRoles = new[]
            {
                new UserRole{User = users[0], Role = roles[2]},
                new UserRole{User = users[1], Role = roles[0]}
            };

            Context.UserRoles.AddRange(userRoles);
        }

        protected virtual async Task LoadTestDataAsync()
        {
            await Task.Delay(0);
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
