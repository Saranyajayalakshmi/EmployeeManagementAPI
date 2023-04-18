namespace EmployeeManagementAPI.ExceptionHandling
{

    // Exception for updateuser Employee

    public class UpdateException
    {
        public class EmployeeBadRequestException : Exception
        {
            public EmployeeBadRequestException() : base(message:"BadRequest")
            { }

        }
        public class EmployeeNotFoundException : Exception
        {
            public EmployeeNotFoundException() : base(message:"Employee Record Not Found")
            { }
        }
        public class IdNotFoundException : Exception
        {
            public IdNotFoundException() : base(message:"EmployeeId NotFound")
            { }
        }



    }
}
