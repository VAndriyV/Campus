using Campus.Application.Exceptions;
using Campus.Application.Subjects.Commands.UpdateSubject;
using Campus.Application.UnitTests.Common;
using Campus.Domain.Entities;
using NUnit.Framework;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.Subjects.Commands
{
    [TestFixture]
    public class UpdateSubjectCommandHandlerShould : TestBase
    {
        [SetUp]
        protected override void LoadTestData()
        {
            InitDbContext();
            SubjectsTestHelper.LoadSubjectsTestData(Context);
        }

        [Test]
        public async Task UpdateSubject()
        {
            var request = new UpdateSubjectCommand
            {
                Id = 1,              
                Name = "Test Subject 1 edited"
            };

            var handler = new UpdateSubjectCommandHandler(Context);

            await handler.Handle(request, CancellationToken.None);

            Assert.IsTrue(Context.Subjects.Where(x => x.Id == request.Id && x.Name == request.Name).Count() == 1);
        }

        [Test]
        public async Task ThrowNotFoundException_WhenSubjectIsNotExists()
        {
            var request = new UpdateSubjectCommand
            {
                Id = 100,               
                Name = "Test Subject Edited"
            };

            var handler = new UpdateSubjectCommandHandler(Context);

            var exception = Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(request, CancellationToken.None));

            Assert.AreEqual(exception.Message, ExceptionMessagesBuilderHelper.GetNotFoundExceptionMessage(nameof(Subject), request.Id));
        }
    }
}
