using Campus.Infrastructure.Helpers;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace Campus.Infrastructure.Tests
{
    [TestFixture]
    public class PasswordGeneratorTests
    {
        protected PasswordGenerator PasswordGenerator;

        [SetUp]
        protected void Init()
        {
            PasswordGenerator = new PasswordGenerator();
        }

        [Test]
        public void GetRandomAlphanumericString_Return_String_With_Correct_Length()
        {
            var expectedStringLength = 100;

            var generatedString = PasswordGenerator.GetRandomAlphanumericString(expectedStringLength);

            Assert.AreEqual(expectedStringLength, generatedString.Length);
        }

        [Test]
        public void GetRandomAlphanumericString_Return_That_Contains_Only_From_Latin_Characters_And_Numbers()
        {   
            var generatedString = PasswordGenerator.GetRandomAlphanumericString(100);
            var pattern = @"^[a-zA-Z0-9]+$";

            Assert.IsTrue(Regex.IsMatch(generatedString, pattern));
        }
    }
}
