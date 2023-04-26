using EmployeeManagementAPI.Data.Command.Create;
using EmployeeManagementAPI.Data.Command.Update;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementUnitTest.UnitTest.Modules.Command.Update
{
    public class UpdateEmployeeValidatorShould
    {
        UpdateUserValidation validator;

        public UpdateEmployeeValidatorShould()
        {
            validator = new UpdateUserValidation();
        }
        [Fact]
        #region User Id Testing
        public void IsUserIdNotNull() 
        {
            var Result = new UpdateUser() { EmployeeID=0, EmployeeName="", EmployeeEmailId="sa@gmail.om", EmployeeMobileNumber="987654345", EmployeeAddress="street", EmployeeMaritalStatus="Married", EmployeeDateOfJoining=DateTime.Today };
            validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeID, Result);
        }
        #endregion

        #region Unit Testing for Createuser Name
        [Fact]
        public void IsNameFailsforNull()
        {
            var Result = new UpdateUser() { EmployeeName=null, EmployeeEmailId="sa@gmail.om", EmployeeMobileNumber="987654345", EmployeeAddress="street", EmployeeMaritalStatus="Married", EmployeeDateOfJoining=DateTime.Today };
            validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeName, Result);
        }
        [Fact]
        public void IsNameFailsforEmpty()
        {
            var Result = new UpdateUser() { EmployeeName="saara", EmployeeEmailId="sa@gmail.om", EmployeeMobileNumber="987654345", EmployeeAddress="street", EmployeeMaritalStatus="Married", EmployeeDateOfJoining=DateTime.Today };
            validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeName, Result);
        }
        [Fact]
        public void IsNameforSetValidator()
        {
            var Result = new UpdateUser() { EmployeeName="@#$", EmployeeEmailId="sa@gmail.om", EmployeeMobileNumber="987654345", EmployeeAddress="street", EmployeeMaritalStatus="Married", EmployeeDateOfJoining=DateTime.Today };
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeName, Result);
        }
        #endregion

        #region User EmailId Testing
        [Fact]
        public void IsEmailFailsforNull()
        {
            var Result = new UpdateUser() { EmployeeName="saara", EmployeeEmailId=null, EmployeeMobileNumber="987654345", EmployeeAddress="street", EmployeeMaritalStatus="Married", EmployeeDateOfJoining=DateTime.Today };
            validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeEmailId, Result);
        }
        [Fact]
        public void IsEmailFailsforEmpty()
        {
            var Result = new UpdateUser() { EmployeeName="saara", EmployeeEmailId="", EmployeeMobileNumber="987654345", EmployeeAddress="street", EmployeeMaritalStatus="Married", EmployeeDateOfJoining=DateTime.Today };
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeEmailId, Result);
        }
        [Fact]
        public void IsEmailSetValidator()
        {
            var Result = new UpdateUser() { EmployeeName="saara", EmployeeEmailId="sara@gamial.xom  ", EmployeeMobileNumber="987654345", EmployeeAddress="street", EmployeeMaritalStatus="Married", EmployeeDateOfJoining=DateTime.Today };
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeEmailId, Result);
        }

        #endregion

        #region User PhoneNumber Testing
        [Fact]
        public void IsPhoneNumberNotNull()
        {
            var Result = new UpdateUser() { EmployeeName="saara", EmployeeEmailId="sat@gmsi.nom", EmployeeMobileNumber=null, EmployeeAddress="street", EmployeeMaritalStatus="Married", EmployeeDateOfJoining=DateTime.Today };
            validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeMobileNumber, Result);
        }
        [Fact]
        public void IsPhoneNumberNotEmpty()
        {
            var Result = new UpdateUser() { EmployeeName="saara", EmployeeEmailId=" sara@gmai.vom ", EmployeeMobileNumber="", EmployeeAddress="street", EmployeeMaritalStatus="Married", EmployeeDateOfJoining=DateTime.Today };
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeMobileNumber, Result);
        }
        [Fact]
        public void IsPhoneNumberSetValidator()
        {
            var Result = new UpdateUser() { EmployeeName="saara", EmployeeEmailId=" sara@gmai.vom ", EmployeeMobileNumber="980987678", EmployeeAddress="street", EmployeeMaritalStatus="Married", EmployeeDateOfJoining=DateTime.Today };
            validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeMobileNumber.Length>9, Result);
        }

        #endregion

        #region User Address testing
        [Fact]
        public void IsAddressNotNull()
        {
            var Result = new UpdateUser() { EmployeeName="saara", EmployeeEmailId=" sara@gmai.vom ", EmployeeMobileNumber="89898989", EmployeeAddress=null, EmployeeMaritalStatus="Married", EmployeeDateOfJoining=DateTime.Today };
            validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeAddress, Result);
        }
        [Fact]
        public void IsAddressNotEmpty()
        {
            var Result = new UpdateUser() { EmployeeName="saara", EmployeeEmailId=" sara@gmai.vom ", EmployeeMobileNumber="989898989", EmployeeAddress="str ", EmployeeMaritalStatus="Married", EmployeeDateOfJoining=DateTime.Today };
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeAddress, Result);
        }
        [Fact]
        public void IsAddressNotSetValidator()
        {
            var Result = new UpdateUser() { EmployeeName="saara", EmployeeEmailId=" sara@gmai.vom ", EmployeeMobileNumber="88787878", EmployeeAddress="14th street ekk che-600032", EmployeeMaritalStatus="Married", EmployeeDateOfJoining=DateTime.Today };
            validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeAddress, Result);
        }
        #endregion

        #region User MaritalStatus Testing 

        [Fact]
        public void IsMaritalStatusNotNull()
        {
            var Result = new UpdateUser() { EmployeeName="saara", EmployeeEmailId=" sara@gmai.vom ", EmployeeMobileNumber="987898878", EmployeeAddress=" ", EmployeeMaritalStatus=null, EmployeeDateOfJoining=DateTime.Today };
            validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeMaritalStatus, Result);
        }
        [Fact]
        public void IsMaritalStatusNotEmpty()
        {
            var Result = new UpdateUser() { EmployeeName="saara", EmployeeEmailId=" sara@gmai.vom ", EmployeeMobileNumber="987898878", EmployeeAddress=" ", EmployeeMaritalStatus="Married", EmployeeDateOfJoining=DateTime.Today };
            validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeMaritalStatus, Result);
        }
        [Fact]
        public void IsMaritalStatusNotValid()
        {
            var Result = new UpdateUser() { EmployeeName="saara", EmployeeEmailId=" sara@gmai.vom ", EmployeeMobileNumber="987898878", EmployeeAddress="stty", EmployeeMaritalStatus="age", EmployeeDateOfJoining=DateTime.Today };
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeMaritalStatus, Result);
        }
        #endregion

        #region  User DateofJoining Testing
        [Fact]
        public void IsDateofJoiningNotNull()
        {
            var Result = new UpdateUser() { EmployeeName="saara", EmployeeEmailId=" sara@gmai.vom ", EmployeeMobileNumber="987898878", EmployeeAddress="street", EmployeeMaritalStatus="single", EmployeeDateOfJoining=DateTime.MinValue };
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeDateOfJoining, Result);
        }
        [Fact]
        public void IsDateofJoiningsetValidator()
        {
            var Result = new UpdateUser() { EmployeeName="saara", EmployeeEmailId=" sara@gmai.vom ", EmployeeMobileNumber="987898878", EmployeeAddress="street", EmployeeMaritalStatus="single", EmployeeDateOfJoining=DateTime.Today };
            validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeDateOfJoining, Result);
        }
        #endregion
    }
}
