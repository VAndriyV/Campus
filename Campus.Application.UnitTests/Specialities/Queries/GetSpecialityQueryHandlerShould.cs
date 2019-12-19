using Campus.Application.Exceptions;
using Campus.Application.Specialities.Queries.DataTransferObjects;
using Campus.Application.Specialities.Queries.GetSpeciality;
using Campus.Application.UnitTests.Common;
using Campus.Domain.Entities;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.Specialities.Queries
{
    [TestFixture]
    public class GetSpecialityQueryHandlerShould : TestBase
    {
        protected override void LoadTestData()
        {
            SpecialitiesTestHelper.LoadSpecialitiesTestData(Context);
        }
        
        [Test]
        public async Task ReturnSpecialityDto_WhenSpecialityExists()
        {
            var handler = new GetSpecialityQueryHandler(Context);

            var result = await handler.Handle(new GetSpecialityQuery { Id = 1 }, CancellationToken.None);
           
            Assert.IsInstanceOf(typeof(SpecialityDto), result);            
        }

        [Test]
        public async Task ThrowNotFoundException_WhenSpecialityIsNotExists()
        {
            var notExistingSubjectId = 1000;
            var handler = new GetSpecialityQueryHandler(Context);

            var exception = Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(new GetSpecialityQuery { Id = notExistingSubjectId}, CancellationToken.None));

            Assert.AreEqual(exception.Message, ExceptionMessagesBuilderHelper.GetNotFoundExceptionMessage(nameof(Speciality), notExistingSubjectId));
        }

    }
}
