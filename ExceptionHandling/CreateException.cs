using System.Runtime.Serialization;

namespace EmployeeManagementAPI.ExceptionHandling
{
    public class CreateException : Exception
    {
        public CreateException(string? message) : base(message)
        {
        }

        protected CreateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
