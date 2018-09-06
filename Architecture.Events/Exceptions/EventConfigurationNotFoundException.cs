using System;
using System.Runtime.Serialization;

namespace Architecture.Events.Exceptions
{
    [Serializable]
    public class EventConfigurationNotFoundException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public EventConfigurationNotFoundException()
        {
        }

        public EventConfigurationNotFoundException(string message) : base(message)
        {
        }

        public EventConfigurationNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }

        protected EventConfigurationNotFoundException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
