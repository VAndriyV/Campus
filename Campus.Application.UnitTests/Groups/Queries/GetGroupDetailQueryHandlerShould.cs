using Campus.Application.Exceptions;
using Campus.Application.Groups.Queries.GetGroupDetail;
using Campus.Application.UnitTests.Common;
using Campus.Domain.Entities;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.Groups.Queries
{
    [TestFixture]
    public class GetGroupQueryHandlerShould : TestBase
    {
        protected override void LoadTestData()
        {
            GroupsTestHelper.LoadGroupsTestData(Context);
        }

        [Test]
        public async Task ReturnGroupDetailModel_WhenGroupExists()
        {
            var handler = new GetGroupDetailQueryHandler(Context);

            var result = await handler.Handle(new GetGroupDetailQuery { Id = 1 }, CancellationToken.None);

            Assert.IsInstanceOf(typeof(GroupDetailModel), result);
        }

        [Test]
        public async Task ThrowNotFoundException_WhenGroupIsNotExists()
        {
            var notExistingGroupId = 1000;
            var handler = new GetGroupDetailQueryHandler(Context);

            var exception = Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(new GetGroupDetailQuery { Id = notExistingGroupId }, CancellationToken.None));

            Assert.AreEqual(exception.Message, ExceptionMessagesBuilderHelper.GetNotFoundExceptionMessage(nameof(Group), notExistingGroupId));
        }
    }
}
