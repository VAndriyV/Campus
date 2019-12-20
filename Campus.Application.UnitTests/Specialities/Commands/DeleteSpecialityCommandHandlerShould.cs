using Campus.Application.Exceptions;
using Campus.Application.Specialities.Commands.DeleteSpeciality;
using Campus.Application.UnitTests.Common;
using Campus.Domain.Entities;
using NUnit.Framework;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.Specialities.Commands
{
    [TestFixture]
    public class DeleteSpecialityCommandHandlerShould : TestBase
    {
        [SetUp]
        protected override void LoadTestData()
        {
            InitDbContext();
            SpecialitiesTestHelper.LoadSpecialitiesTestData(Context);
        }

        [Test]
        public async Task DeleteSpeciality()
        {
            var request = new DeleteSpecialityCommand
            {
                Id = 1
            };

            var handler = new DeleteSpecialityCommandHandler(Context);

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.IsFalse(Context.Specialities.Where(x => x.Id == request.Id).Count() == 1);
        }

        [Test]
        public async Task ThrowNotFoundException_WhenSpecialityIsNotExists()
        {
            var request = new DeleteSpecialityCommand
            {
                Id = 100
            };

            var handler = new DeleteSpecialityCommandHandler(Context);

            var exception = Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(request, CancellationToken.None));

            Assert.AreEqual(exception.Message, ExceptionMessagesBuilderHelper.GetNotFoundExceptionMessage(nameof(Speciality), request.Id));
        }

        [Test]
        public async Task ThrowDeleteFailureException_WhenGroupWithSpecialityExists()
        {
            var request = new DeleteSpecialityCommand
            {
                Id = 2
            };

            var handler = new DeleteSpecialityCommandHandler(Context);

            var exception = Assert.ThrowsAsync<DeleteFailureException>(async () => await handler.Handle(request, CancellationToken.None));

            Assert.AreEqual(exception.Message, ExceptionMessagesBuilderHelper.GetDeleteFailureExceptionMessage(nameof(Speciality), request.Id, "There are group(s) on this speciality"));
        }
    }
}
