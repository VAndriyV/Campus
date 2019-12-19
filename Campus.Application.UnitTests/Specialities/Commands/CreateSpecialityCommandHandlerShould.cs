using Campus.Application.Exceptions;
using Campus.Application.Specialities.Commands.CreateSpeciality;
using Campus.Application.UnitTests.Common;
using Campus.Domain.Entities;
using NUnit.Framework;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.Specialities.Commands
{
    [TestFixture]
    public class CreateSpecialityCommandHandlerShould : TestBase
    {
        protected override void LoadTestData()
        {
            base.LoadTestData();
            SpecialitiesTestHelper.LoadSpecialitiesTestData(Context);
        }

        [Test]
        public async Task CreateSpeciality()
        {
            var request = new CreateSpecialityCommand
            {             
                Code = 103,
                Name = "Test Speciality 3"
            };

            var handler = new CreateSpecialityCommandHandler(Context);

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.IsTrue(Context.Specialities.Any(x => x.Id == result));
        }

        [Test]
        public async Task ThrowDuplicateException_WhenSpecialityCodeExists()
        {
            var request = new CreateSpecialityCommand
            {              
                Code = 101,
                Name = "Test Speciality 3"
            };

            var handler = new CreateSpecialityCommandHandler(Context);

            var exception = Assert.ThrowsAsync<DuplicateException>(async () => await handler.Handle(request, CancellationToken.None));

            Assert.AreEqual(exception.Message, ExceptionMessagesBuilderHelper.GetDuplicateExceptionMessage(nameof(Speciality), "Code", request.Code));
        }
    }
}
