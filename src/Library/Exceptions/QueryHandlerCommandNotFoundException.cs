using System;
using System.Runtime.Serialization;

namespace Kreta.FileService.ParameterHandler.Library.Exceptions
{
    public class QueryHandlerCommandNotFoundException : Exception
    {
        public string QueryName { get; }

        public string QueryValue { get; set; }

        public QueryHandlerCommandNotFoundException(string message, string queryName, string queryValue) : base(message)
        {
            QueryName = queryName;
            QueryValue = queryValue;
        }
    }
}
