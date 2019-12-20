using Campus.Application.Helpers.Interfaces;
using Moq;

namespace Campus.Application.UnitTests.Common.MockSetupHelpers
{
    static class PasswordHasherSetupHelper
    {
        public static void Setup_HashPassword_Returns_Eight_Character_String(this Mock<IPasswordHasher> passwordHasher)
        {
            passwordHasher.Setup(x => x.HashPassword(It.IsAny<string>()))
                         .Returns("abcdefgh");
        }

        public static void Setup_VerifyHashedPassword_Returns_True(this Mock<IPasswordHasher> passwordHasher)
        {
            passwordHasher.Setup(x => x.VerifyHashedPassword(It.IsAny<string>(), It.IsAny<string>()))
                         .Returns(true);
        }

        public static void Setup_VerifyHashedPassword_Returns_False(this Mock<IPasswordHasher> passwordHasher)
        {
            passwordHasher.Setup(x => x.VerifyHashedPassword(It.IsAny<string>(), It.IsAny<string>()))
                         .Returns(false);
        }

        public static void Verify_VerifyHashedPassword_Called_Once(this Mock<IPasswordHasher> passwordHasher)
        {
            passwordHasher.Verify(x => x.VerifyHashedPassword(It.IsAny<string>(), It.IsAny<string>()), Times.Once);                        
        }

        public static void Verify_HashPassword_Called_Once(this Mock<IPasswordHasher> passwordHasher)
        {
            passwordHasher.Verify(x => x.HashPassword(It.IsAny<string>()), Times.Once);
        }
    }
}
