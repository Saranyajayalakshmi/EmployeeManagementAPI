using EmployeeManagementAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Runtime.Serialization;

namespace EmployeeManagementAPI.ExceptionHandling
{
    /// <summary>
    /// Exception for updateuser Employee
    /// </summary>
    public class UpdateException
    {
        public class EmployeeBadRequestException : Exception
        {
            public EmployeeBadRequestException() : base(message:"BadRequest")
            { }
        }
        public class EmployeeNotFoundException : Exception
        {
            public EmployeeNotFoundException() : base(message:"NotFound")
            { }
        }



    }
}
