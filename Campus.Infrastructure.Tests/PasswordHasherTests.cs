using Campus.Infrastructure.Helpers;
using NUnit.Framework;
using System;

namespace Campus.Infrastructure.Tests
{
    [TestFixture]
    public class PasswordHasherTests
    {
        protected PasswordHasher PasswordHasher;

        [SetUp]
        protected void Init()
        {
            PasswordHasher = new PasswordHasher();
        }

        [Test]
        public void HashPassword_Throws_ArgumentNullException_When_Password_Argument_Is_Null()
        {
            string password = null;

            Assert.Throws<ArgumentNullException>(() => PasswordHasher.HashPassword(password));
        }

        [Test]
        public void HashPassword_Return_Base64_String()
        {
            var password = "testPasswordString";

            var hash = PasswordHasher.HashPassword(password);

            Span<byte> buffer = new Span<byte>(new byte[hash.Length]);
            Assert.IsTrue(Convert.TryFromBase64String(hash, buffer, out int bytesParsed));
        }

        [Test]
        public void VerifyHashedPassword_Throws_ArgumentNullException_When_Password_Armument_Is_Null()
        {
            string password = null;
            string hashedPassword = "any string";

            Assert.Throws<ArgumentNullException>(() => PasswordHasher.VerifyHashedPassword(hashedPassword, password));
        }

        [Test]
        public void VerifyHashedPassword_Throws_ArgumentNullException_When_HashedPassword_Armument_Is_Null()
        {
            string password = "any string";
            string hashedPassword = null;

            Assert.Throws<ArgumentNullException>(() => PasswordHasher.VerifyHashedPassword(hashedPassword, password));
        }


        [Test]
        public void VerifyHashedPassword_Returns_True_When_Arguments_Are_Valid()
        {
            string password = "testString123";
            string hashedPassword = PasswordHasher.HashPassword(password);

            Assert.IsTrue(PasswordHasher.VerifyHashedPassword(hashedPassword, password));           
        }

    }
}
