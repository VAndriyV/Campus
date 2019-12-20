using Campus.Application.Exceptions;
using Campus.Application.LectorSubjects.Queries.DataTransferObjects;
using Campus.Application.LectorSubjects.Queries.GetLectorSubjectQuery;
using Campus.Application.UnitTests.Common;
using Campus.Domain.Entities;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.LectorSubjects.Queries
{
    [TestFixture]
    public class GetLectorSubjectQueryHandlerShould : TestBase
    {
        [SetUp]
        protected override void LoadTestData()
        {
            InitDbContext();
            LectorSubjectsTestHelper.LoadLectorSubjectsTestData(Context);
        }

        [Test]
        public async Task ReturnLectorSubjectDto_WhenLectorSubjectExists()
        {
            var handler = new GetLectorSubjectQueryHandler(Context);

            var result = await handler.Handle(new GetLectorSubjectQuery { Id = 1 }, CancellationToken.None);

            Assert.IsInstanceOf(typeof(LectorSubjectDto), result);
        }

        [Test]
        public async Task ThrowNotFoundException_WhenLectorSubjectIsNotExists()
        {
            var notExistingLectorSubjectId = 1000;
            var handler = new GetLectorSubjectQueryHandler(Context);

            var exception = Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(new GetLectorSubjectQuery { Id = notExistingLectorSubjectId }, CancellationToken.None));

            Assert.AreEqual(exception.Message, ExceptionMessagesBuilderHelper.GetNotFoundExceptionMessage(nameof(LectorSubject), notExistingLectorSubjectId));
        }
    }
}
