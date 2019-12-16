using System;

namespace Campus.Application.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException():base($"The password is invalid")
        {
                
        }
    }
}
