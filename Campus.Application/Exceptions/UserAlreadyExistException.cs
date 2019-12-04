using System;

namespace Campus.Application.Exceptions
{
    public class UserAlreadyExistException : Exception
    {
        public UserAlreadyExistException(string email)
            :base($"User with email ${email} is already exist")
        {
                
        }
    }
}
