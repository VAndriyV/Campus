using Campus.Application.Exceptions;
using Campus.Application.Subjects.Queries.DataTransferObjects;
using Campus.Application.Subjects.Queries.GetSubject;
using Campus.Application.UnitTests.Common;
using Campus.Domain.Entities;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.Subjects.Queries
{
    [TestFixture]
    public class GetSubjectQueryHandlerShould : TestBase
    {
        [SetUp]
        protected override void LoadTestData()
        {
            InitDbContext();
            SubjectsTestHelper.LoadSubjectsTestData(Context);
        }

        [Test]
        public async Task ReturnSubjectDto_WhenSubjectExists()
        {
            var handler = new GetSubjectQueryHandler(Context);

            var result = await handler.Handle(new GetSubjectQuery { Id = 1 }, CancellationToken.None);

            Assert.IsInstanceOf(typeof(SubjectDto), result);
        }

        [Test]
        public async Task ThrowNotFoundException_WhenSubjectIsNotExists()
        {
            var notExistingSubjectId = 1000;
            var handler = new GetSubjectQueryHandler(Context);

            var exception = Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(new GetSubjectQuery { Id = notExistingSubjectId }, CancellationToken.None));

            Assert.AreEqual(exception.Message, ExceptionMessagesBuilderHelper.GetNotFoundExceptionMessage(nameof(Subject), notExistingSubjectId));
        }
    }
}
