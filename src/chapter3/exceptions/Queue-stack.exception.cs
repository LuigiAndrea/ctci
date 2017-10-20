using System;
using System.Runtime.Serialization;

namespace Chapter3.Exceptions
{
    public class EmptyQueueException : Exception, ISerializable
    {
        public EmptyQueueException()
        {
        }

        public EmptyQueueException(string message)
            : base(message)
        {
        }

        public EmptyQueueException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected EmptyQueueException(SerializationInfo info, StreamingContext context)
            : base(info,context){

            }
    }
}