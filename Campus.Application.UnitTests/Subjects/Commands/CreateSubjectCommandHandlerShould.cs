using Campus.Application.Subjects.Commands.CreateSubject;
using NUnit.Framework;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.Subjects.Commands
{
    [TestFixture]
    public class CreateSubjectCommandHandlerShould : TestBase
    {
        [SetUp]
        protected override void LoadTestData()
        {
            InitDbContext();
            SubjectsTestHelper.LoadSubjectsTestData(Context);
        }

        [Test]
        public async Task CreateSubject()
        {
            var request = new CreateSubjectCommand
            {                
                Name = "Test Subject 3"
            };

            var handler = new CreateSubjectCommandHandler(Context);

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.IsTrue(Context.Subjects.Where(x => x.Id == result).Count() == 1);
        }       
    }
}
