using System;

namespace Kreta.FileService.ParameterHandler.Library.Exceptions
{
    public class ParameterHandlerCommandNotFoundException : Exception
    {
        public string QueryName { get; }

        public string QueryValue { get; set; }

        public ParameterHandlerCommandNotFoundException(string message, string queryName, string queryValue) : base(message)
        {
            QueryName = queryName;
            QueryValue = queryValue;
        }
    }
}
