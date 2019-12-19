using Campus.Application.Exceptions;
using Campus.Application.Subjects.Commands.DeleteSubject;
using Campus.Application.UnitTests.Common;
using Campus.Domain.Entities;
using NUnit.Framework;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.Subjects.Commands
{
    [TestFixture]
    public class DeleteSubjectCommandHandlerShould : TestBase
    {
        protected override void LoadTestData()
        {
            base.LoadTestData();
            SubjectsTestHelper.LoadSubjectsTestData(Context);
        }

        [Test]
        public async Task DeleteSubject()
        {
            var request = new DeleteSubjectCommand
            {
                Id = 1
            };

            var handler = new DeleteSubjectCommandHandler(Context);

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.IsFalse(Context.Subjects.Any(x => x.Id == request.Id));
        }

        [Test]
        public async Task ThrowNotFoundException_WhenSubjectIsNotExists()
        {
            var request = new DeleteSubjectCommand
            {
                Id = 100
            };

            var handler = new DeleteSubjectCommandHandler(Context);

            var exception = Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(request, CancellationToken.None));

            Assert.AreEqual(exception.Message, ExceptionMessagesBuilderHelper.GetNotFoundExceptionMessage(nameof(Subject), request.Id));
        }

        [Test]
        public async Task ThrowDeleteFailureException_WhenLectorSubjectWithSubjectExists()
        {
            var request = new DeleteSubjectCommand
            {
                Id = 2
            };

            var handler = new DeleteSubjectCommandHandler(Context);

            var exception = Assert.ThrowsAsync<DeleteFailureException>(async () => await handler.Handle(request, CancellationToken.None));

            Assert.AreEqual(exception.Message, ExceptionMessagesBuilderHelper.GetDeleteFailureExceptionMessage(nameof(Subject), request.Id, "This subjects is assigned to lectors"));
        }
    }
}
