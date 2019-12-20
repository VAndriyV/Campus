using Campus.Application.LectorSubjects.Queries.GetAllLectorsSubjects;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.LectorSubjects.Queries
{
    [TestFixture]
    public class GetAllLectorsSubjectsQueryHandlerShould : TestBase
    {
        [SetUp]
        protected override void LoadTestData()
        {
            InitDbContext();
            LectorSubjectsTestHelper.LoadLectorSubjectsTestData(Context);
        }

        [Test]
        public async Task ReturnCorrectLectorsSubjectsAmount()
        {
            var request = new GetAllLectorsSubjectsQuery
            {
                LectorId = 1
            };

            var handler = new GetAllLectorsSubjectsQueryHandler(Context);

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.AreEqual(result.LectorsSubjects.Count, 2);
        }

        [Test]
        public async Task ReturnLectorsSubjectsListViewModel()
        {
            var request = new GetAllLectorsSubjectsQuery
            {
                LectorId = 1
            };

            var handler = new GetAllLectorsSubjectsQueryHandler(Context);

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.IsInstanceOf(typeof(LectorsSubjectsListViewModel), result);
        }
    }
}
