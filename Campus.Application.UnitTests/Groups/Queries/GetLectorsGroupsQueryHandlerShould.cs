using Campus.Application.Groups.Queries.GetLectorsGroups;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.Groups.Queries
{
    [TestFixture]
    public class GetLectorsGroupsQueryHandlerShould : TestBase
    {
        protected override void LoadTestData()
        {
            base.LoadTestData();
            GroupsTestHelper.LoadGroupsTestData(Context);
        }

        [Test]
        public async Task ReturnCorrectGroupsAmount()
        {
            var request = new GetLectorsGroupsQuery
            {
                LectorId = 1
            };

            var handler = new GetLectorsGroupsQueryHandler(Context);

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.AreEqual(result.Groups.Count, 1);
        }

        [Test]
        public async Task ReturnLectorsGroupsListViewModel()
        {
            var request = new GetLectorsGroupsQuery
            {
                LectorId = 1
            };

            var handler = new GetLectorsGroupsQueryHandler(Context);

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.IsInstanceOf(typeof(LectorsGroupsListViewModel), result);
        }
    }
}
