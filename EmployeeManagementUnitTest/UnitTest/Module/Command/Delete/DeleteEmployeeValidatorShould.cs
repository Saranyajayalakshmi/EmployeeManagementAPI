using EmployeeManagementAPI.Data.Command.Delete;
using EmployeeManagementAPI.Data.Command.Update;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementUnitTest.UnitTest.Data.Command.Delete
{
    // DeleteUser Validator
    public class DeleteEmployeeValidatorShould
    {
        DeleteUserValidation validator;
        public DeleteEmployeeValidatorShould()
        {
            validator = new DeleteUserValidation();
        }
        #region DeleteUser Validator byId
        [Fact]
        public void IsGetUserIdValidationNotNull()
        {
            var Result = new DeleteUser() {EmployeeId=0};
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeId, Result);
        }
        #endregion
    }
}
