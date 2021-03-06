using System.Runtime.Serialization;

namespace CaesarShift
{
    [Serializable]
    public class UnknownCharacterException : Exception
    {
        public UnknownCharacterException()
        {
        }

        public UnknownCharacterException(string? message) : base(message)
        {
        }

        public UnknownCharacterException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UnknownCharacterException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}