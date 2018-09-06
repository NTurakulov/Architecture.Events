using System;
using System.Runtime.Serialization;

namespace Architecture.Events.Exceptions
{
    [Serializable]
    public class ResponseException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public ResponseException()
        {
        }

        public ResponseException(string message) : base(message)
        {
        }

        public ResponseException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ResponseException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
