using Campus.Application.Enumerations.Queries.GetAllAcademicDegrees;
using Campus.Application.Enumerations.Queries.Models;
using Campus.Domain.Entities;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.Enumerations.Queries
{
    [TestFixture]
    public class GetAllAcademicDegreesQueryHandlerShould : TestBase
    {
        protected override void LoadTestData()
        {
            Context.AcademicDegrees.Add(new AcademicDegree { Id = 1, Name = "Academic rank 1" });
            Context.SaveChanges();
        }

        [Test]
        public async Task ReturnCorrectAcademicDegreesAmount()
        {
            var handler = new GetAllAcademicDegreesQueryHandler(Context);

            var result = await handler.Handle(new GetAllAcademicDegreesQuery(), CancellationToken.None);

            Assert.AreEqual(result.Items.Count, 1);
        }

        [Test]
        public async Task ReturnEnumerationItemsListViewModel()
        {
            var handler = new GetAllAcademicDegreesQueryHandler(Context);

            var result = await handler.Handle(new GetAllAcademicDegreesQuery(), CancellationToken.None);

            Assert.IsInstanceOf(typeof(EnumerationItemsListViewModel), result);
        }
    }
}
