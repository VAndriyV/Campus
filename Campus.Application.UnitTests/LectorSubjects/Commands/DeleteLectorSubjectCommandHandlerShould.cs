using Campus.Application.Exceptions;
using Campus.Application.LectorSubjects.Commands.DeleteLectorSubject;
using Campus.Application.UnitTests.Common;
using Campus.Domain.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.LectorSubjects.Commands
{
    [TestFixture]
    public class DeleteLectorSubjectCommandHandlerShould : TestBase
    {
        [SetUp]
        protected override void LoadTestData()
        {
            InitDbContext();
            LectorSubjectsTestHelper.LoadLectorSubjectsTestData(Context);
        }

        [Test]
        public async Task DeleteLectorSubject()
        {
            var request = new DeleteLectorSubjectCommand
            {
                Id = 1
            };

            var handler = new DeleteLectorSubjectCommandHandler(Context);

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.IsFalse(Context.LectorSubjects.Any(x => x.Id == request.Id));
        }

        [Test]
        public async Task ThrowNotFoundException_WhenLectorSubjectIsNotExists()
        {
            var request = new DeleteLectorSubjectCommand
            {
                Id = 100
            };

            var handler = new DeleteLectorSubjectCommandHandler(Context);

            var exception = Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(request, CancellationToken.None));

            Assert.AreEqual(exception.Message, ExceptionMessagesBuilderHelper.GetNotFoundExceptionMessage(nameof(LectorSubject), request.Id));
        }

        [Test]
        public async Task ThrowDeleteFailureException_WhenLessonWithLectorSubjectExists()
        {
            var request = new DeleteLectorSubjectCommand
            {
                Id = 2
            };

            var handler = new DeleteLectorSubjectCommandHandler(Context);

            var exception = Assert.ThrowsAsync<DeleteFailureException>(async () => await handler.Handle(request, CancellationToken.None));

            Assert.AreEqual(exception.Message, ExceptionMessagesBuilderHelper.GetDeleteFailureExceptionMessage(nameof(LectorSubject), request.Id, "This record is used in lesson(s)"));
        }
    }
}
