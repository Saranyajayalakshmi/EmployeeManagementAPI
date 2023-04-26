using EmployeeManagementAPI.Data.Command.Create;
using EmployeeManagementAPI.Data.Command.Update;
using FluentValidation.TestHelper;
using Microsoft.IdentityModel.Tokens;
using Xunit;

namespace EmployeeManagementAPI.UnitTest.Data.Command.Create
{ 
    public class CreateEmployeeValidatorShould
    {
        CreateUserValidation validator;


        public CreateEmployeeValidatorShould()
        {
            validator= new CreateUserValidation();
        }

        #region Unit Testing for Createuser Name
        [Fact]
        public void IsUserNameValidforNotNull()
        {
            var Result = new CreateUser() { EmployeeName=null, EmployeeEmailId="sa@gmail.om", EmployeeMobileNumber="987654345", EmployeeAddress="street", EmployeeMaritalStatus="Married", EmployeeDateOfJoining=DateTime.Today };
            validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeName, Result);
        }
        [Fact]
        public void IsUserNamevalidNotEmpty()
        {
            var Result = new CreateUser() { EmployeeName="saara", EmployeeEmailId="sa@gmail.om", EmployeeMobileNumber="987654345", EmployeeAddress="street", EmployeeMaritalStatus="Married", EmployeeDateOfJoining=DateTime.Today };
            validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeName, Result);
        }
        [Fact]
        public void IsUserNameforSetValidator()
        {
            var Result = new CreateUser() { EmployeeName="@#$", EmployeeEmailId="sa@gmail.om", EmployeeMobileNumber="987654345", EmployeeAddress="street", EmployeeMaritalStatus="Married", EmployeeDateOfJoining=DateTime.Today };
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeName, Result);
        }
        #endregion

        #region User EmailId Testing
        
        [Fact]
        public void IsEmailIdFailsforNotEmpty()
        {
            var Result = new CreateUser() { EmployeeName="saara", EmployeeEmailId="", EmployeeMobileNumber="987654345", EmployeeAddress="street", EmployeeMaritalStatus="Married", EmployeeDateOfJoining=DateTime.Today };
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeEmailId, Result);
        }
        [Fact]
        public void IsEmailIdforSetValidator()
        {
            var Result = new CreateUser() { EmployeeName="saara", EmployeeEmailId="sara@gamial.xom", EmployeeMobileNumber="987654345", EmployeeAddress="street", EmployeeMaritalStatus="Married", EmployeeDateOfJoining=DateTime.Today };
            validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeEmailId, Result);
        }

        #endregion

        #region User PhoneNumber Testing
        [Fact]
        public void IsPhoneNumberNotNull()
        {
            var Result = new CreateUser() { EmployeeName="saara", EmployeeEmailId="sat@gmsi.nom", EmployeeMobileNumber=null, EmployeeAddress="street", EmployeeMaritalStatus="Married", EmployeeDateOfJoining=DateTime.Today };
            validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeMobileNumber, Result);
        }
        [Fact]
        public void IsPhoneNumberNotEmpty()
        {
            var Result = new CreateUser() { EmployeeName="saara", EmployeeEmailId=" sara@gmai.vom ", EmployeeMobileNumber="989 ", EmployeeAddress="street", EmployeeMaritalStatus="Married", EmployeeDateOfJoining=DateTime.Today };
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeMobileNumber, Result);
        }
        [Fact]
        public void IsPhoneNumberSetValidator()
        {
            var Result = new CreateUser() { EmployeeName="saara", EmployeeEmailId=" sara@gmai.vom ", EmployeeMobileNumber="987654323", EmployeeAddress="street", EmployeeMaritalStatus="Married", EmployeeDateOfJoining=DateTime.Today };
            validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeMobileNumber, Result);
        }

        #endregion

        #region User Address Testing
        [Fact]
        public void IsAddressNotEmpty()
        {
            var Result = new CreateUser() { EmployeeName="saara", EmployeeEmailId=" sara@gmai.vom ", EmployeeMobileNumber="989898989", EmployeeAddress=" ", EmployeeMaritalStatus="Married", EmployeeDateOfJoining=DateTime.Today };
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeAddress, Result);
        }
        [Fact]
        public void IsAddressNotNull()
        {
            var Result = new CreateUser() { EmployeeName="saara", EmployeeEmailId=" sara@gmai.vom ", EmployeeMobileNumber="88787878", EmployeeAddress=null, EmployeeMaritalStatus="Married", EmployeeDateOfJoining=DateTime.Today };
            validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeAddress, Result);
        }
        [Fact]
        public void IsAddressNotSetValidator()
        {
            var Result = new CreateUser() { EmployeeName="saara", EmployeeEmailId=" sara@gmai.vom ", EmployeeMobileNumber="88787878", EmployeeAddress="14th street ekk che-600032", EmployeeMaritalStatus="Married", EmployeeDateOfJoining=DateTime.Today };
            validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeAddress, Result);
        }
        #endregion

        #region  User MaritalStatus Testing 

        [Fact]
        public void IsMaritalStatusNotNull()
        {
            var Result = new CreateUser() { EmployeeName="saara", EmployeeEmailId=" sara@gmai.vom ", EmployeeMobileNumber="987898878", EmployeeAddress=" street", EmployeeMaritalStatus=null, EmployeeDateOfJoining=DateTime.Today };
            validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeMaritalStatus, Result);
        }
        [Fact]
        public void IsMaritalStatusNotEmpty()
        {
            var Result = new CreateUser() { EmployeeName="saara", EmployeeEmailId=" sara@gmai.vom ", EmployeeMobileNumber="987898878", EmployeeAddress=" ", EmployeeMaritalStatus="Married", EmployeeDateOfJoining=DateTime.Today };
            validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeMaritalStatus, Result);
        }
        [Fact]
        public void IsMaritalStatusNotValid()
        {
            var Result = new CreateUser() { EmployeeName="saara", EmployeeEmailId=" sara@gmai.vom ", EmployeeMobileNumber="987898878", EmployeeAddress="stty", EmployeeMaritalStatus="age", EmployeeDateOfJoining=DateTime.Today };
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeMaritalStatus, Result);
        }
        #endregion

        #region  User DateofJoining Testing
        [Fact]
        public void IsDateofJoiningNotNull()
        {
            var Result = new CreateUser() { EmployeeName="saara", EmployeeEmailId=" sara@gmai.vom ", EmployeeMobileNumber="987898878", EmployeeAddress="street", EmployeeMaritalStatus="single", EmployeeDateOfJoining=DateTime.MinValue };
            validator.ShouldHaveValidationErrorFor(x => x.EmployeeDateOfJoining, Result);
        }
        [Fact]
        public void IsDateofJoiningsetValidator()
        {
            var Result = new CreateUser() { EmployeeName="saara", EmployeeEmailId=" sara@gmai.vom ", EmployeeMobileNumber="987898878", EmployeeAddress="street", EmployeeMaritalStatus="single", EmployeeDateOfJoining=DateTime.Today };
            validator.ShouldNotHaveValidationErrorFor(x => x.EmployeeDateOfJoining, Result);
        }
        #endregion

    }
}

