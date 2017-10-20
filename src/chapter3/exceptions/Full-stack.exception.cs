using System;
using System.Runtime.Serialization;

namespace Chapter3.Exceptions
{
public class FullStackException : Exception, ISerializable
    {
        public FullStackException()
        {
        }

        public FullStackException(string message)
            : base(message)
        {
        }

        public FullStackException(string message, Exception inner)
            : base(message, inner)
        {
        }

         protected FullStackException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}