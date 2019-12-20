using Campus.Application.Subjects.Queries.GetAllSubjects;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.Subjects.Queries
{
    [TestFixture]
    public class GetAllSubjectsQueryHandlerShould : TestBase
    {
        [SetUp]
        protected override void LoadTestData()
        {
            InitDbContext();
            SubjectsTestHelper.LoadSubjectsTestData(Context);
        }

        [Test]
        public async Task ReturnCorrectSubjectsAmount()
        {
            var handler = new GetAllSubjectsQueryHandler(Context);

            var result = await handler.Handle(new GetAllSubjectsQuery(), CancellationToken.None);

            Assert.AreEqual(result.Subjects.Count, 2);
        }

        [Test]
        public async Task ReturnSubjectsListViewModel()
        {
            var handler = new GetAllSubjectsQueryHandler(Context);

            var result = await handler.Handle(new GetAllSubjectsQuery(), CancellationToken.None);

            Assert.IsInstanceOf(typeof(SubjectsListViewModel), result);
        }
    }
}
