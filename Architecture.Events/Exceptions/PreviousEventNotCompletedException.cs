using System;
using System.Runtime.Serialization;

namespace Architecture.Events.Exceptions
{
    [Serializable]
    public class PreviousEventNotCompletedException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public PreviousEventNotCompletedException()
        {
        }

        public PreviousEventNotCompletedException(string message) : base(message)
        {
        }

        public PreviousEventNotCompletedException(string message, Exception inner) : base(message, inner)
        {
        }

        protected PreviousEventNotCompletedException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
