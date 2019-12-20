using Campus.Application.Exceptions;
using Campus.Application.Specialities.Commands.UpdateSpeciality;
using Campus.Application.UnitTests.Common;
using Campus.Domain.Entities;
using NUnit.Framework;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.Specialities.Commands
{
    [TestFixture]
    public class UpdateSpecialityCommandHandlerShould : TestBase
    {
        [SetUp]
        protected override void LoadTestData()
        {
            InitDbContext();
            SpecialitiesTestHelper.LoadSpecialitiesTestData(Context);
        }

        [Test]
        public async Task UpdateSpeciality()
        {
            var request = new UpdateSpecialityCommand
            {
                Id = 1,
                Code = 100,
                Name = "Test Speciality 3 edited"
            };

            var handler = new UpdateSpecialityCommandHandler(Context);

            await handler.Handle(request, CancellationToken.None);

            Assert.IsTrue(Context.Specialities.Where(x => x.Id == request.Id 
                                                   && x.Name == request.Name
                                                   && x.Code == request.Code).Count() == 1);
        }

        [Test]
        public async Task ThrowNotFoundException_WhenSpecialityIsNotExists()
        {
            var request = new UpdateSpecialityCommand
            {
                Id = 100,
                Code = 103,
                Name ="Test Speciality Edited"
            };

            var handler = new UpdateSpecialityCommandHandler(Context);

            var exception = Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(request, CancellationToken.None));

            Assert.AreEqual(exception.Message, ExceptionMessagesBuilderHelper.GetNotFoundExceptionMessage(nameof(Speciality), request.Id));
        }

        [Test]
        public async Task ThrowDuplicateException_WhenSpecialityCodeExists()
        {
            var request = new UpdateSpecialityCommand
            {
                Id = 1,
                Code = 101,
                Name = "Test Speciality 3"
            };

            var handler = new UpdateSpecialityCommandHandler(Context);

            var exception = Assert.ThrowsAsync<DuplicateException>(async () => await handler.Handle(request, CancellationToken.None));

            Assert.AreEqual(exception.Message, ExceptionMessagesBuilderHelper.GetDuplicateExceptionMessage(nameof(Speciality), "Code", request.Code));
        }
    }
}
