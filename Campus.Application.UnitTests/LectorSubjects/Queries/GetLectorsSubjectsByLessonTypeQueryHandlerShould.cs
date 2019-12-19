using Campus.Application.LectorSubjects.Queries.GetLectorsSubjectsByLessonType;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.LectorSubjects.Queries
{
    [TestFixture]
    public class GetLectorsSubjectsByLessonTypeQueryHandlerShould : TestBase
    {
        protected override void LoadTestData()
        {
            LectorSubjectsTestHelper.LoadLectorSubjectsTestData(Context);
        }

        [Test]
        public async Task ReturnCorrectLectorsSubjectsAmount()
        {
            var request = new GetLectorsSubjectsByLessonTypeQuery
            {
                LectorId = 1,
                LessonTypeId = 1
            };

            var handler = new GetLectorsSubjectsByLessonTypeQueryHandler(Context);

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.AreEqual(result.LectorsSubjects.Count, 2);
        }

        [Test]
        public async Task ReturnLectorsSubjectsByLessonTypeListViewModel()
        {
            var request = new GetLectorsSubjectsByLessonTypeQuery
            {
                LectorId = 1,
                LessonTypeId = 1
            };

            var handler = new GetLectorsSubjectsByLessonTypeQueryHandler(Context);

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.IsInstanceOf(typeof(LectorsSubjectsByLessonTypeListViewModel), result);
        }
    }
}
