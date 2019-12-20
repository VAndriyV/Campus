using Campus.Application.Exceptions;
using Campus.Application.LectorSubjects.Commands.UpdateLectorSubject;
using Campus.Application.UnitTests.Common;
using Campus.Domain.Entities;
using NUnit.Framework;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.LectorSubjects.Commands
{
    [TestFixture]
    public class UpdateLectorSubjectCommandHandlerShould : TestBase
    {
        [SetUp]
        protected override void LoadTestData()
        {
            InitDbContext();
            LectorSubjectsTestHelper.LoadLectorSubjectsTestData(Context);
        }

        [Test]
        public async Task UpdateLectorSubject()
        {
            var request = new UpdateLectorSubjectCommand
            {
                Id = 1,                
                LectorId = 1,
                LessonTypeId = 2,
                SubjectId = 1
            };

            var handler = new UpdateLectorSubjectCommandHandler(Context);

            await handler.Handle(request, CancellationToken.None);

            Assert.IsTrue(Context.LectorSubjects.Where(x => x.Id == request.Id
                                                     && x.LectorId == request.LectorId
                                                     && x.LessonTypeId == request.LessonTypeId
                                                     && x.SubjectId == request.SubjectId).Count() == 1);
        }

        [Test]
        public async Task ThrowNotFoundException_WhenLectorSubjectIsNotExists()
        {
            var request = new UpdateLectorSubjectCommand
            {
                Id = 100,
                LectorId = 1,
                LessonTypeId = 2,
                SubjectId = 1
            };

            var handler = new UpdateLectorSubjectCommandHandler(Context);

            var exception = Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(request, CancellationToken.None));

            Assert.AreEqual(exception.Message, ExceptionMessagesBuilderHelper.GetNotFoundExceptionMessage(nameof(LectorSubject), request.Id));
        }

        [Test]
        public async Task ThrowDuplicateException_WhenLectorSubjectNameExists()
        {
            var request = new UpdateLectorSubjectCommand
            {
                Id = 1,
                LectorId = 1,
                SubjectId = 2,
                LessonTypeId = 1
            };

            var handler = new UpdateLectorSubjectCommandHandler(Context);

            var exception = Assert.ThrowsAsync<DuplicateException>(async () => await handler.Handle(request, CancellationToken.None));

            Assert.AreEqual(exception.Message, ExceptionMessagesBuilderHelper.GetDuplicateExceptionMessage(nameof(LectorSubject)));
        }
    }
}
