using System;

namespace Chapter3.Exceptions
{
public class FullStackException : Exception
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
    }
}