using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Data.Command.Create;
using EmployeeManagementAPI.Data.Handlers;
using EmployeeManagementAPI.Model;
using EmployeeManagementAPI.Module.Query;
using EntityFrameworkCoreMock;
using FluentValidation.TestHelper;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementUnitTest.UnitTest.Module.GetById
{
    public class GetByIdValidatorShould
    {
        GetEmployeeIdValidator validator;


        public GetByIdValidatorShould()
        {
            validator= new GetEmployeeIdValidator();
        }
        [Fact]
        public void IsGetByIdNotNull()
        {
            var Result = new GetEmployeeDetail() {  };
            validator.ShouldNotHaveValidationErrorFor(x => x.Id, Result);
        }
        [Fact]
        public void IsGetByIdNotEmpty()
        {
            var Result = new GetEmployeeDetail() {Id=0 };
            validator.ShouldNotHaveValidationErrorFor(x=>x.Id,Result);
        }
        //[Fact]
        //public void IsGetByIdValidator() 
        //{
        //    var Result = new GetEmployeeDetail() {Id=2 };
        //    validator.ShouldHaveValidationErrorFor(x=>x.Id,Result); 
        //}

    }
}
