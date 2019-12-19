using Campus.Application.Specialities.Queries.GetAllSpecialities;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.Specialities.Queries
{
    [TestFixture]
    public class GetAllSpecialitiesQueryHandlerShould : TestBase
    {
        protected override void LoadTestData()
        {
            base.LoadTestData();
            SpecialitiesTestHelper.LoadSpecialitiesTestData(Context);
        }

        [Test]
        public async Task ReturnCorrectSpecialitiesAmount()
        {
            var handler = new GetAllSpecialitiesQueryHandler(Context);

            var result = await handler.Handle(new GetAllSpecialitiesQuery(), CancellationToken.None);

            Assert.AreEqual(result.Specialities.Count, 2);
        }

        [Test]
        public async Task ReturnSpecialitiesListViewModel()
        {
            var handler = new GetAllSpecialitiesQueryHandler(Context);

            var result = await handler.Handle(new GetAllSpecialitiesQuery(), CancellationToken.None);

            Assert.IsInstanceOf(typeof(SpecialitiesListViewModel), result);
        }
    }
}
