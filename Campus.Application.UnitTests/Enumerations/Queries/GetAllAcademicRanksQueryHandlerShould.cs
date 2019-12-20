using Campus.Application.Enumerations.Queries.GetAllAcademicRanks;
using Campus.Application.Enumerations.Queries.Models;
using Campus.Domain.Entities;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.Enumerations.Queries
{
    [TestFixture]
    public class GetAllAcademicRanksQueryHandlerShould : TestBase
    {
        [SetUp]
        protected override void LoadTestData()
        {
            InitDbContext();
            Context.AcademicRanks.Add(new AcademicRank { Id = 1, Name = "Academic rank 1" });
            Context.SaveChanges();
        }

        [Test]
        public async Task ReturnCorrectAcademicRanksAmount()
        {
            var handler = new GetAllAcademicRanksQueryHandler(Context);

            var result = await handler.Handle(new GetAllAcademicRanksQuery(), CancellationToken.None);

            Assert.AreEqual(result.Items.Count, 1);
        }

        [Test]
        public async Task ReturnEnumerationItemsListViewModel()
        {
            var handler = new GetAllAcademicRanksQueryHandler(Context);

            var result = await handler.Handle(new GetAllAcademicRanksQuery(), CancellationToken.None);

            Assert.IsInstanceOf(typeof(EnumerationItemsListViewModel), result);
        }
    }
}
