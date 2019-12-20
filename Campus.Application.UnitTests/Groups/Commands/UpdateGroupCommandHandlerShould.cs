using Campus.Application.Exceptions;
using Campus.Application.Groups.Commands.UpdateGroup;
using Campus.Application.UnitTests.Common;
using Campus.Domain.Entities;
using NUnit.Framework;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.Groups.Commands
{
    [TestFixture]
    public class UpdateGroupCommandHandlerShould : TestBase
    {
        [SetUp]
        protected override void LoadTestData()
        {
            InitDbContext();
            GroupsTestHelper.LoadGroupsTestData(Context);
        }

        [Test]
        public async Task UpdateGroup()
        {
            var request = new UpdateGroupCommand
            {
                Id = 1,
                Name = "Test Group 1 edited",
                StudentsCount = 10,
                SpecialityId = 1,
                EducationalDegreeId = 1,
                Year = 1
            };

            var handler = new UpdateGroupCommandHandler(Context);

            await handler.Handle(request, CancellationToken.None);

            Assert.IsTrue(Context.Groups.Where(x => x.Id == request.Id 
                                             && x.Name == request.Name
                                             && x.EducationalDegreeId == request.EducationalDegreeId
                                             && x.SpecialityId == request.SpecialityId
                                             && x.Year == request.Year).Count() == 1);
        }

        [Test]
        public async Task ThrowNotFoundException_WhenGroupIsNotExists()
        {
            var request = new UpdateGroupCommand
            {
                Id = 100,
                Name = "Test Group Edited",
                SpecialityId = 1,
                StudentsCount = 10,
                EducationalDegreeId = 1,
                Year = 1
            };

            var handler = new UpdateGroupCommandHandler(Context);

            var exception = Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle(request, CancellationToken.None));

            Assert.AreEqual(exception.Message, ExceptionMessagesBuilderHelper.GetNotFoundExceptionMessage(nameof(Group), request.Id));
        }

        [Test]
        public async Task ThrowDuplicateException_WhenGroupNameExists()
        {
            var request = new UpdateGroupCommand
            {
                Id = 1,                
                Name = "Group 2",
                StudentsCount = 10,
                SpecialityId = 1,
                Year = 1,
                EducationalDegreeId = 1
            };

            var handler = new UpdateGroupCommandHandler(Context);

            var exception = Assert.ThrowsAsync<DuplicateException>(async () => await handler.Handle(request, CancellationToken.None));

            Assert.AreEqual(exception.Message, ExceptionMessagesBuilderHelper.GetDuplicateExceptionMessage(nameof(Group), "Name", request.Name));
        }
    }
}
