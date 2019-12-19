using Campus.Application.Exceptions;
using Campus.WebUI.Filters;
using NUnit.Framework;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Campus.WebUI.Tests.Filters
{
    [TestFixture]
    public class CustomExceptionFilterShould
    {
        protected CustomExceptionFilterAttribute CustomExceptionFilterAttribute;

        [SetUp]
        protected void Init()
        {
            CustomExceptionFilterAttribute = new CustomExceptionFilterAttribute();
        }

        [Test]
        public async Task Set_404_Response_StatusCode_When_NotFoundException_Occurs()
        {
            var notFoundException = new NotFoundException("Entity name");
            var exceptionContext = CustomExceptionFilterTestHelper.GetExceptionContext(notFoundException);

            CustomExceptionFilterAttribute.OnException(exceptionContext);

            Assert.AreEqual((int)HttpStatusCode.NotFound, exceptionContext.HttpContext.Response.StatusCode);
        }

        [Test]
        public async Task Set_400_Response_StatusCode_When_ValidationException_Occurs()
        {
            var validationException = new ValidationException();
            var exceptionContext = CustomExceptionFilterTestHelper.GetExceptionContext(validationException);

            CustomExceptionFilterAttribute.OnException(exceptionContext);

            Assert.AreEqual((int)HttpStatusCode.BadRequest, exceptionContext.HttpContext.Response.StatusCode);
        }

        [Test]
        public async Task Set_409_Response_StatusCode_When_DuplicateException_Occurs()
        {
            var duplicateException = new DuplicateException("Entity name");
            var exceptionContext = CustomExceptionFilterTestHelper.GetExceptionContext(duplicateException);

            CustomExceptionFilterAttribute.OnException(exceptionContext);

            Assert.AreEqual((int)HttpStatusCode.Conflict, exceptionContext.HttpContext.Response.StatusCode);
        }

        [Test]
        public async Task Set_409_Response_StatusCode_When_DeleteFailureException_Occurs()
        {
            var deleteFailureException = new DeleteFailureException("Entity name", "key", "message");
            var exceptionContext = CustomExceptionFilterTestHelper.GetExceptionContext(deleteFailureException);

            CustomExceptionFilterAttribute.OnException(exceptionContext);

            Assert.AreEqual((int)HttpStatusCode.Conflict, exceptionContext.HttpContext.Response.StatusCode);
        }

        [Test]
        public async Task Set_401_Response_StatusCode_When_InvalidPasswordException_Occurs()
        {
            var invalidPasswordException = new InvalidPasswordException();
            var exceptionContext = CustomExceptionFilterTestHelper.GetExceptionContext(invalidPasswordException);

            CustomExceptionFilterAttribute.OnException(exceptionContext);

            Assert.AreEqual((int)HttpStatusCode.Unauthorized, exceptionContext.HttpContext.Response.StatusCode);
        }

        [Test]
        public async Task Set_500_Response_StatusCode_When_Unexpected_Occurs()
        {
            var exception = new Exception();
            var exceptionContext = CustomExceptionFilterTestHelper.GetExceptionContext(exception);

            CustomExceptionFilterAttribute.OnException(exceptionContext);

            Assert.AreEqual((int)HttpStatusCode.InternalServerError, exceptionContext.HttpContext.Response.StatusCode);
        }

    }
}
