using Campus.Application.Exceptions;
using Campus.Application.Lectors.Queries.GetLectorDetail;
using Campus.Application.UnitTests.Common;
using Campus.Domain.Entities;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.Lectors.Queries
{
    [TestFixture]
    public class GetLectorQueryHandlerShould : TestBase
    {
        protected override void LoadTestData()
        {
            LectorsTestHelper.LoadLectorsTestData(Context);
        }

        [Test]
        public async Task ReturnLectorDetailModel_WhenLectorExists()
        {
            var handler = new GetLectorDetailQueryHandler(Context);

            var result = await handler.Handle(new GetLectorDetailQuery { Id = 1 }, CancellationToken.None);

            Assert.IsInstanceOf(typeof(LectorDetailModel), result);
        }

        [Test]
        public async Task ThrowNotFoundException_WhenLectorIsNotExists()
        {
            var notExistingLectorId = 1000;
            var handler = new GetLectorDetailQueryHandler(Context);

            var exception = Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(new GetLectorDetailQuery { Id = notExistingLectorId }, CancellationToken.None));

            Assert.AreEqual(exception.Message, ExceptionMessagesBuilderHelper.GetNotFoundExceptionMessage(nameof(Lector), notExistingLectorId));
        }
    }
}
