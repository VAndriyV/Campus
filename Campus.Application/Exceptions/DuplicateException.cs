using System;

namespace Campus.Application.Exceptions
{
    public class DuplicateException : Exception
    {
        public DuplicateException(string entity, string keyName, object keyValue)
            :base($"The \"{entity}\" with {keyName}:{keyValue} is already exist")
        {

        }

        public DuplicateException(string entity)
            :base($"The \"{entity}\" is already exist")
        {

        }
    }
}
