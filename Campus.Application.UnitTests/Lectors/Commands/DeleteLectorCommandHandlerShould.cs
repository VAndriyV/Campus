using Campus.Application.Exceptions;
using Campus.Application.Lectors.Commands.DeleteLector;
using Campus.Application.UnitTests.Common;
using Campus.Domain.Entities;
using NUnit.Framework;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.Lectors.Commands
{
    [TestFixture]
    public class DeleteLectorCommandHandlerShould : TestBase
    {
        [SetUp]
        protected override void LoadTestData()
        {
            InitDbContext();
            LectorsTestHelper.LoadLectorsTestData(Context);
        }

        [Test]
        public async Task DeleteLector_And_UserRole_And_User()
        {
            var request = new DeleteLectorCommand
            {
                Id = 1
            };

            var handler = new DeleteLectorCommandHandler(Context);

            await handler.Handle(request, CancellationToken.None);

            Assert.IsFalse(Context.Lectors.Any(x => x.Id == 1));
            Assert.IsFalse(Context.Users.Any(x => x.Id == 100));
            Assert.IsFalse(Context.UserRoles.Any(x => x.UserId == 100 && x.RoleId == 1));
        }

        [Test]
        public async Task ThrowNotFoundException_WhenLectorIsNotExists()
        {
            var request = new DeleteLectorCommand
            {
                Id = 100
            };

            var handler = new DeleteLectorCommandHandler(Context);

            var exception = Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(request, CancellationToken.None));

            Assert.AreEqual(exception.Message, ExceptionMessagesBuilderHelper.GetNotFoundExceptionMessage(nameof(Lector), request.Id));
        }

        [Test]
        public async Task ThrowDeleteFailureException_WhenLectorSubjectWithLectorExists()
        {
            var request = new DeleteLectorCommand
            {
                Id = 2
            };

            var handler = new DeleteLectorCommandHandler(Context);

            var exception = Assert.ThrowsAsync<DeleteFailureException>(async () => await handler.Handle(request, CancellationToken.None));

            Assert.AreEqual(exception.Message, ExceptionMessagesBuilderHelper.GetDeleteFailureExceptionMessage(nameof(Lector), request.Id, "There are subject(s) assigned to this lector"));
        }
    }
}
