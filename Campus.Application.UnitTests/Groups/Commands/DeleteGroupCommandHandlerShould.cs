using Campus.Application.Exceptions;
using Campus.Application.Groups.Commands.DeleteGroup;
using Campus.Application.UnitTests.Common;
using Campus.Domain.Entities;
using NUnit.Framework;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.Groups.Commands
{
    [TestFixture]
    public class DeleteGroupCommandHandlerShould : TestBase
    {
        protected override void LoadTestData()
        {
            base.LoadTestData();
            GroupsTestHelper.LoadGroupsTestData(Context);
        }

        [Test]
        public async Task DeleteGroup()
        {
            var request = new DeleteGroupCommand
            {
                Id = 1
            };

            var handler = new DeleteGroupCommandHandler(Context);

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.IsFalse(Context.Groups.Any(x => x.Id == request.Id));
        }

        [Test]
        public async Task ThrowNotFoundException_WhenGroupIsNotExists()
        {
            var request = new DeleteGroupCommand
            {
                Id = 100
            };

            var handler = new DeleteGroupCommandHandler(Context);

            var exception = Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(request, CancellationToken.None));

            Assert.AreEqual(exception.Message, ExceptionMessagesBuilderHelper.GetNotFoundExceptionMessage(nameof(Group), request.Id));
        }

        [Test]
        public async Task ThrowDeleteFailureException_WhenLessonWithGroupExists()
        {
            var request = new DeleteGroupCommand
            {
                Id = 2
            };

            var handler = new DeleteGroupCommandHandler(Context);

            var exception = Assert.ThrowsAsync<DeleteFailureException>(async () => await handler.Handle(request, CancellationToken.None));

            Assert.AreEqual(exception.Message, ExceptionMessagesBuilderHelper.GetDeleteFailureExceptionMessage(nameof(Group), request.Id, "There are lesson(s) with this group"));
        }
    }
}
