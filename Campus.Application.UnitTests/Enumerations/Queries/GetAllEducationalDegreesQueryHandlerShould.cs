using Campus.Application.Enumerations.Queries.GetAllEducationalDegrees;
using Campus.Application.Enumerations.Queries.Models;
using Campus.Domain.Entities;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.Enumerations.Queries
{
    [TestFixture]
    public class GetAllEducationalDegreesQueryHandlerShould : TestBase
    {
        protected override void LoadTestData()
        {
            Context.EducationalDegrees.Add(new EducationalDegree { Id = 1, Name = "Educational degree 1" });
            Context.SaveChanges();
        }

        [Test]
        public async Task ReturnCorrectEducationalDegreesAmount()
        {
            var handler = new GetAllEducationalDegreesQueryHandler(Context);

            var result = await handler.Handle(new GetAllEducationalDegreesQuery(), CancellationToken.None);

            Assert.AreEqual(result.Items.Count, 1);
        }

        [Test]
        public async Task ReturnEnumerationItemsListViewModel()
        {
            var handler = new GetAllEducationalDegreesQueryHandler(Context);

            var result = await handler.Handle(new GetAllEducationalDegreesQuery(), CancellationToken.None);

            Assert.IsInstanceOf(typeof(EnumerationItemsListViewModel), result);
        }
    }
}
