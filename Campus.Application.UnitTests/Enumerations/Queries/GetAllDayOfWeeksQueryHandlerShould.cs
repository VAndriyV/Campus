using Campus.Application.Enumerations.Queries.GetAllDayOfWeeks;
using Campus.Application.Enumerations.Queries.Models;
using Campus.Domain.Entities;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.Enumerations.Queries
{
    [TestFixture]
    public class GetAllDayOfWeeksQueryHandlerShould : TestBase
    {
        protected override void LoadTestData()
        {
            Context.DayOfWeeks.Add(new DayOfWeek { Id = 1, Name = "Day of week 1" });
            Context.SaveChanges();
        }

        [Test]
        public async Task ReturnCorrectDayOfWeeksAmount()
        {
            var handler = new GetAllDayOfWeeksQueryHandler(Context);

            var result = await handler.Handle(new GetAllDayOfWeeksQuery(), CancellationToken.None);

            Assert.AreEqual(result.Items.Count, 1);
        }

        [Test]
        public async Task ReturnEnumerationItemsListViewModel()
        {
            var handler = new GetAllDayOfWeeksQueryHandler(Context);

            var result = await handler.Handle(new GetAllDayOfWeeksQuery(), CancellationToken.None);

            Assert.IsInstanceOf(typeof(EnumerationItemsListViewModel), result);
        }
    }
}
