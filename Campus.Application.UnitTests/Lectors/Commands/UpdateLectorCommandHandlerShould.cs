using Campus.Application.Exceptions;
using Campus.Application.Lectors.Commands.UpdateLector;
using Campus.Application.UnitTests.Common;
using Campus.Domain.Entities;
using NUnit.Framework;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.Lectors.Commands
{
    [TestFixture]
    public class UpdateLectorCommandHandlerShould : TestBase
    {
        [SetUp]
        protected override void LoadTestData()
        {
            InitDbContext();
            LectorsTestHelper.LoadLectorsTestData(Context);
        }

        [Test]
        public async Task UpdateLector_And_User()
        {
            var request = new UpdateLectorCommand
            {
                Id = 1,
                AcademicDegreeId = 1,
                AcademicRankId = 1,
                Email = "updatedEmail@mail.com",
                FirstName = "Name 1",
                LastName = "LastName 1",
                Patronymic = "Patronymic 1",
                PhoneNumber = "+0000000000"
            };

            var handler = new UpdateLectorCommandHandler(Context);

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.IsTrue(Context.Lectors.Where(x => x.Id == request.Id && x.Email == request.Email).Count() == 1);
            Assert.IsTrue(Context.Users.Where(x => x.Id == 100 && x.Email == request.Email).Count() == 1);
        }

        [Test]
        public async Task ThrowsDuplicateException_WhenEmailExists()
        {
            var request = new UpdateLectorCommand
            {
                Id = 1,
                AcademicDegreeId = 1,
                AcademicRankId = 1,
                Email = "email2@mail.com",
                FirstName = "Name 1",
                LastName = "LastName 1",
                Patronymic = "Patronymic 1",
                PhoneNumber = "+0000000000"
            };

            var handler = new UpdateLectorCommandHandler(Context);

            var exception = Assert.ThrowsAsync<DuplicateException>(async () => await handler.Handle(request, CancellationToken.None));

            Assert.AreEqual(exception.Message, ExceptionMessagesBuilderHelper.GetDuplicateExceptionMessage(nameof(Lector), "Email", request.Email));
        }

        [Test]
        public async Task ThrowNotFoundException_WhenLectorIsNotExists()
        {
            var request = new UpdateLectorCommand
            {
                Id = 100,
                AcademicDegreeId = 1,
                AcademicRankId = 1,
                Email = "updatedEmail@mail.com",
                FirstName = "Name 1",
                LastName = "LastName 1",
                Patronymic = "Patronymic 1",
                PhoneNumber = "+0000000000"
            };

            var handler = new UpdateLectorCommandHandler(Context);
            var exception = Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(request, CancellationToken.None));

            Assert.AreEqual(exception.Message, ExceptionMessagesBuilderHelper.GetNotFoundExceptionMessage(nameof(Lector), request.Id));
        }
    }
}
