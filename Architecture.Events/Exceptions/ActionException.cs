using System;
using System.Runtime.Serialization;

namespace Architecture.Events.Exceptions
{
    [Serializable]
    public class ActionException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public ActionException()
        {
        }

        public ActionException(string message) : base(message)
        {
        }

        public ActionException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ActionException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
