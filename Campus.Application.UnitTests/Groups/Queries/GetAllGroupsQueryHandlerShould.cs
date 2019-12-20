using Campus.Application.Groups.Queries.GetAllGroups;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.Groups.Queries
{
    [TestFixture]
    public class GetAllGroupsQueryHandlerShould : TestBase
    {
        [SetUp]
        protected override void LoadTestData()
        {
            InitDbContext();
            GroupsTestHelper.LoadGroupsTestData(Context);
        }

        [Test]
        public async Task ReturnCorrectGroupsAmount()
        {
            var handler = new GetAllGroupsQueryHandler(Context);

            var result = await handler.Handle(new GetAllGroupsQuery(), CancellationToken.None);

            Assert.AreEqual(result.Groups.Count, 2);
        }

        [Test]
        public async Task ReturnGroupsListViewModel()
        {
            var handler = new GetAllGroupsQueryHandler(Context);

            var result = await handler.Handle(new GetAllGroupsQuery(), CancellationToken.None);

            Assert.IsInstanceOf(typeof(GroupsListViewModel), result);
        }
    }
}
