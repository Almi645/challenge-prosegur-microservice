using System;

namespace Challenge.Application.Base
{
    public class CommonBaseException : Exception
    {
        public CommonBaseException()
        { }

        public CommonBaseException(string message)
            : base(message)
        { }

        public CommonBaseException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }

    public class JsonErrorResponse
    {
        public string[] Messages { get; set; }
        public string MessageType { get; set; }
        public object DeveloperMessage { get; set; }
        public object StackTrace { get; set; }
    }
}
