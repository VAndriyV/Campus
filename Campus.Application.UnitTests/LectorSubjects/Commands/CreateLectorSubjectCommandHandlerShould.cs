using Campus.Application.Exceptions;
using Campus.Application.LectorSubjects.Commands.CreateLectorSubject;
using Campus.Application.UnitTests.Common;
using Campus.Domain.Entities;
using NUnit.Framework;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.LectorSubjects.Commands
{
    [TestFixture]
    public class CreateLectorSubjectCommandHandlerShould : TestBase
    {
        protected override void LoadTestData()
        {
            base.LoadTestData();
            LectorSubjectsTestHelper.LoadLectorSubjectsTestData(Context);
        }

        [Test]
        public async Task CreateLectorSubject()
        {
            var request = new CreateLectorSubjectCommand
            {
                LectorId = 1,
                LessonTypeId = 2,
                SubjectId = 2
            };

            var handler = new CreateLectorSubjectCommandHandler(Context);

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.IsTrue(Context.LectorSubjects.Any(x => x.Id == result));
        }

        [Test]
        public async Task ThrowDuplicateException_WhenLectorSubjectExists()
        {
            var request = new CreateLectorSubjectCommand
            {
                LectorId = 1,
                LessonTypeId = 1,
                SubjectId = 1
            };

            var handler = new CreateLectorSubjectCommandHandler(Context);

            var exception = Assert.ThrowsAsync<DuplicateException>(async () => await handler.Handle(request, CancellationToken.None));

            Assert.AreEqual(exception.Message, ExceptionMessagesBuilderHelper.GetDuplicateExceptionMessage(nameof(LectorSubject)));
        }
    }
}
