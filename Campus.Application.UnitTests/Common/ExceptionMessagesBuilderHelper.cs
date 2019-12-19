namespace Campus.Application.UnitTests.Common
{
    static class ExceptionMessagesBuilderHelper
    {
        public static string GetNotFoundExceptionMessage(string name, object key) => $"Entity \"{name}\" ({key}) was not found.";
        public static string GetNotFoundExceptionMessage(string name) => $"Entity \"{name}\" was not found.";
        public static string GetDuplicateExceptionMessage(string entity, string keyName, object keyValue) => $"The \"{entity}\" with {keyName}:{keyValue} is already exist";
        public static string GetDuplicateExceptionMessage(string entity) => $"The \"{entity}\" is already exist";
        public static string GetDeleteFailureExceptionMessage(string name, object key, string message) => $"Deletion of entity \"{name}\" ({key}) failed. {message}";
    }
}
