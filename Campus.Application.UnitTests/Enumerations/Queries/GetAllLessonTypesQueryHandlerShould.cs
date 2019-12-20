using Campus.Application.Enumerations.Queries.GetAllLessonTypes;
using Campus.Application.Enumerations.Queries.Models;
using Campus.Domain.Entities;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.Enumerations.Queries
{
    [TestFixture]
    public class GetAllLessonTypesQueryHandlerShould : TestBase
    {
        [SetUp]
        protected override void LoadTestData()
        {
            InitDbContext();
            Context.LessonTypes.Add(new LessonType { Id = 1, Name = "Lesson type 1" });
            Context.SaveChanges();
        }

        [Test]
        public async Task ReturnCorrectLessonTypesAmount()
        {
            var handler = new GetAllLessonTypesQueryHandler(Context);

            var result = await handler.Handle(new GetAllLessonTypesQuery(), CancellationToken.None);

            Assert.AreEqual(result.Items.Count, 1);
        }

        [Test]
        public async Task ReturnEnumerationItemsListViewModel()
        {
            var handler = new GetAllLessonTypesQueryHandler(Context);

            var result = await handler.Handle(new GetAllLessonTypesQuery(), CancellationToken.None);

            Assert.IsInstanceOf(typeof(EnumerationItemsListViewModel), result);
        }
    }
}
