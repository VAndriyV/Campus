using Campus.Application.Enumerations.Queries.GetAllWeatherTypes;
using Campus.Application.Enumerations.Queries.Models;
using Campus.Domain.Entities;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.Enumerations.Queries
{
    [TestFixture]
    public class GetAllWeatherTypesQueryHandlerShould : TestBase
    {
        [SetUp]
        protected override void LoadTestData()
        {
            InitDbContext();
            Context.WeatherTypes.Add(new WeatherType { Id = 1, Name = "Weather type 1" });
            Context.SaveChanges();
        }

        [Test]
        public async Task ReturnCorrectWeatherTypesAmount()
        {
            var handler = new GetAllWeatherTypesQueryHandler(Context);

            var result = await handler.Handle(new GetAllWeatherTypesQuery(), CancellationToken.None);

            Assert.AreEqual(result.Items.Count, 1);
        }

        [Test]
        public async Task ReturnEnumerationItemsListViewModel()
        {
            var handler = new GetAllWeatherTypesQueryHandler(Context);

            var result = await handler.Handle(new GetAllWeatherTypesQuery(), CancellationToken.None);

            Assert.IsInstanceOf(typeof(EnumerationItemsListViewModel), result);
        }
    }
}
