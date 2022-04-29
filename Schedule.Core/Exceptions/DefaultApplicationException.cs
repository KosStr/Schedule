using Schedule.Core.Enums;
using System;
using System.Runtime.Serialization;

namespace Schedule.Core.Exceptions
{
    [Serializable]
    public class DefaultApplicationException : Exception
    {
        public int StatusCode { get; set; }

        public Severity Severity { get; set; }

        public DefaultApplicationException(string message)
            : base(message)
        {
        }
    }
}
