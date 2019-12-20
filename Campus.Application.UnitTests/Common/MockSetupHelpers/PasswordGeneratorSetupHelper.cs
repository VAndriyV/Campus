using Campus.Application.Helpers.Interfaces;
using Moq;

namespace Campus.Application.UnitTests.Common.MockSetupHelpers
{
    static class PasswordGeneratorSetupHelper
    {
        public static void Setup_GetRandomAlphanumericString_Returns_Eight_Character_String(this Mock<IPasswordGenerator> passwordGenerator)
        {
            passwordGenerator.Setup(x => x.GetRandomAlphanumericString(It.IsAny<int>()))
                           .Returns("abcdefgh");
        }

        public static void Verify_GetRandomAlphanumericString_Called_Once(this Mock<IPasswordGenerator> passwordGenerator)
        {
            passwordGenerator.Verify(x => x.GetRandomAlphanumericString(It.IsAny<int>()), Times.Once);
        }
    }
}
