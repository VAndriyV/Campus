using Campus.Application.Lectors.Queries.GetAllLectors;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.Lectors.Queries
{
    [TestFixture]
    public class GetAllLectorsQueryHandlerShould : TestBase
    {
        [SetUp]
        protected override void LoadTestData()
        {
            InitDbContext();
            LectorsTestHelper.LoadLectorsTestData(Context);
        }

        [Test]
        public async Task ReturnCorrectLectorsAmount()
        {
            var handler = new GetAllLectorsQueryHandler(Context);

            var result = await handler.Handle(new GetAllLectorsQuery(), CancellationToken.None);

            Assert.AreEqual(result.Lectors.Count, 2);
        }

        [Test]
        public async Task ReturnLectorsListViewModel()
        {
            var handler = new GetAllLectorsQueryHandler(Context);

            var result = await handler.Handle(new GetAllLectorsQuery(), CancellationToken.None);

            Assert.IsInstanceOf(typeof(LectorsListViewModel), result);
        }
    }
}
