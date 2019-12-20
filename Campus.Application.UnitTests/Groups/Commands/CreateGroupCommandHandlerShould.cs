using Campus.Application.Exceptions;
using Campus.Application.Groups.Commands.CreateGroup;
using Campus.Application.UnitTests.Common;
using Campus.Domain.Entities;
using NUnit.Framework;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.Groups.Commands
{
    [TestFixture]
    public class CreateGroupCommandHandlerShould : TestBase
    {
        [SetUp]
        protected override void LoadTestData()
        {
            InitDbContext();
            GroupsTestHelper.LoadGroupsTestData(Context);
        }

        [Test]
        public async Task CreateGroup()
        {
            var request = new CreateGroupCommand
            {
                Name = "Group 3",
                SpecialityId = 1,
                StudentsCount = 10,
                EducationalDegreeId = 1,
                Year = 1
            };

            var handler = new CreateGroupCommandHandler(Context);

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.IsTrue(Context.Groups.Where(x => x.Id == result).Count()==1);
        }

        [Test]
        public async Task ThrowDuplicateException_WhenGroupNameExists()
        {
            var request = new CreateGroupCommand
            {
                Name = "Group 1",
                SpecialityId = 1,
                StudentsCount = 10,
                EducationalDegreeId = 1,
                Year = 1
            };

            var handler = new CreateGroupCommandHandler(Context);

            var exception = Assert.ThrowsAsync<DuplicateException>(async () => await handler.Handle(request, CancellationToken.None));

            Assert.AreEqual(exception.Message, ExceptionMessagesBuilderHelper.GetDuplicateExceptionMessage(nameof(Group), "Name", request.Name));
        }
    }
}
 