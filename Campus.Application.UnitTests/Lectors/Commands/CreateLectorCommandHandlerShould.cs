using Campus.Application.Exceptions;
using Campus.Application.Lectors.Commands.CreateLector;
using Campus.Application.UnitTests.Common;
using Campus.Application.UnitTests.Common.MockSetupHelpers;
using Campus.Domain.Entities;
using Campus.Application.Helpers.Interfaces;
using Moq;
using NUnit.Framework;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Campus.Application.UnitTests.Lectors.Commands
{
    [TestFixture]
    public class CreateLectorCommandHandlerShould : TestBase
    {
        [SetUp]
        protected override void LoadTestData()
        {
            InitDbContext();
            LectorsTestHelper.LoadLectorsTestData(Context);
        }

        [Test]
        public async Task CreateUser()
        {
            var passwordHasherMock = new Mock<IPasswordHasher>();
            var passwordGeneratorMock = new Mock<IPasswordGenerator>();

            passwordHasherMock.Setup_HashPassword_Returns_Eight_Character_String();
            passwordGeneratorMock.Setup_GetRandomAlphanumericString_Returns_Eight_Character_String();

            var request = new CreateLectorCommand
            {
                Email = "email3@mail.com",
                AcademicDegreeId = 1,
                AcademicRankId = 1,
                FirstName = "Name 3",
                LastName = "LastName 3",
                Patronymic = "Patronymic 3",
                PhoneNumber = "+3333333333"
            };

            var handler = new CreateLectorCommandHandler(Context, passwordHasherMock.Object, passwordGeneratorMock.Object);

            await handler.Handle(request, CancellationToken.None);

            passwordGeneratorMock.Verify_GetRandomAlphanumericString_Called_Once();
            passwordHasherMock.Verify_HashPassword_Called_Once();

            Assert.IsTrue(Context.Users.Where(x => x.Email == request.Email).Count()==1);
        }

        [Test]
        public async Task CreateUserRole_With_Lector_Role()
        {
            var passwordHasherMock = new Mock<IPasswordHasher>();
            var passwordGeneratorMock = new Mock<IPasswordGenerator>();

            passwordHasherMock.Setup_HashPassword_Returns_Eight_Character_String();
            passwordGeneratorMock.Setup_GetRandomAlphanumericString_Returns_Eight_Character_String();

            var request = new CreateLectorCommand
            {
                Email = "email3@mail.com",
                AcademicDegreeId = 1,
                AcademicRankId = 1,
                FirstName = "Name 3",
                LastName = "LastName 3",
                Patronymic = "Patronymic 3",
                PhoneNumber = "+3333333333"
            };

            var handler = new CreateLectorCommandHandler(Context, passwordHasherMock.Object, passwordGeneratorMock.Object);

            var result = await handler.Handle(request, CancellationToken.None);

            passwordGeneratorMock.Verify_GetRandomAlphanumericString_Called_Once();
            passwordHasherMock.Verify_HashPassword_Called_Once();

            var user = Context.Users.SingleOrDefault(x => x.Email == request.Email);

            Assert.IsNotNull(user);
            Assert.IsTrue(Context.UserRoles.Where(x => x.RoleId == 1 && x.UserId == user.Id).Count() == 1);
        }

        [Test]
        public async Task CreateLector()
        {
            var passwordHasherMock = new Mock<IPasswordHasher>();
            var passwordGeneratorMock = new Mock<IPasswordGenerator>();

            passwordHasherMock.Setup_HashPassword_Returns_Eight_Character_String();
            passwordGeneratorMock.Setup_GetRandomAlphanumericString_Returns_Eight_Character_String();

            var request = new CreateLectorCommand
            {
                Email = "email3@mail.com",
                AcademicDegreeId = 1,
                AcademicRankId = 1,
                FirstName = "Name 3",
                LastName = "LastName 3",
                Patronymic = "Patronymic 3",
                PhoneNumber = "+3333333333"
            };

            var handler = new CreateLectorCommandHandler(Context, passwordHasherMock.Object, passwordGeneratorMock.Object);

            var (id,_) = await handler.Handle(request, CancellationToken.None);

            passwordGeneratorMock.Verify_GetRandomAlphanumericString_Called_Once();
            passwordHasherMock.Verify_HashPassword_Called_Once();

            Assert.IsTrue(Context.Lectors.Where(x => x.Id == id).Count() == 1);
        }

        [Test]
        public async Task CreateLector_And_User_With_Lector_Role()
        {
            var passwordHasherMock = new Mock<IPasswordHasher>();
            var passwordGeneratorMock = new Mock<IPasswordGenerator>();

            passwordHasherMock.Setup_HashPassword_Returns_Eight_Character_String();
            passwordGeneratorMock.Setup_GetRandomAlphanumericString_Returns_Eight_Character_String();

            var request = new CreateLectorCommand
            {
                Email = "email3@mail.com",
                AcademicDegreeId = 1,
                AcademicRankId = 1,
                FirstName = "Name 3",
                LastName = "LastName 3",
                Patronymic = "Patronymic 3",
                PhoneNumber = "+3333333333"
            };

            var handler = new CreateLectorCommandHandler(Context, passwordHasherMock.Object, passwordGeneratorMock.Object);

            var (id,_) = await handler.Handle(request, CancellationToken.None);

            passwordGeneratorMock.Verify_GetRandomAlphanumericString_Called_Once();
            passwordHasherMock.Verify_HashPassword_Called_Once();

            var user = Context.Users.SingleOrDefault(x => x.Email == request.Email);
            Assert.IsNotNull(user);

            Assert.IsTrue(Context.UserRoles.Where(x => x.RoleId == 1 && x.UserId == user.Id).Count() == 1);
            Assert.IsTrue(Context.Lectors.Where(x => x.Id == id && x.UserId == user.Id).Count() == 1);
        }

        [Test]
        public async Task ThrowDuplicateException_WhenEmailExists()
        {
            var passwordHasherMock = new Mock<IPasswordHasher>();
            var passwordGeneratorMock = new Mock<IPasswordGenerator>();          

            var request = new CreateLectorCommand
            {
                Email = "email1@mail.com",
                AcademicDegreeId = 1,
                AcademicRankId = 1,
                FirstName = "Name 3",
                LastName = "LastName 3",
                Patronymic = "Patronymic 3",
                PhoneNumber = "+3333333333"
            };

            var handler = new CreateLectorCommandHandler(Context, passwordHasherMock.Object, passwordGeneratorMock.Object);

            var exception = Assert.ThrowsAsync<DuplicateException>(async () => await handler.Handle(request, CancellationToken.None));

            Assert.AreEqual(exception.Message, ExceptionMessagesBuilderHelper.GetDuplicateExceptionMessage(nameof(Lector), "Email", request.Email));
        }      
       
    }
}
