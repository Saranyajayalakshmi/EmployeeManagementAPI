using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Data.Command.Create;
using EmployeeManagementAPI.ExceptionHandling;
using EmployeeManagementAPI.Model;
using EntityFrameworkCoreMock;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementUnitTest.UnitTest.Data.Command.Create
{
    public class CreateUserShould
    {
        //Create DbMock 
        DbContextMock<DataDbContext> dbContextMock;
        CreateEmployeeHandler handler;
        //Create Dummy Table for Validator
        List<EmployeeManagementApplication> EmployeeApplication = new List<EmployeeManagementApplication>();// dummy Table Creating
        DbContextOptions<DataDbContext> dbContextOptions { get; } = new DbContextOptionsBuilder<DataDbContext>().Options;
        public CreateUserShould()
        {
            dbContextMock = new DbContextMock<DataDbContext>(dbContextOptions);
            handler = new CreateEmployeeHandler(dbContextMock.Object);
            dbContextMock.CreateDbSetMock(x => x.managementApplications, EmployeeApplication);// For Creating Dummy Data
        }
        #region CreateUser Pass and Fail Validation
        [Fact]
        public void PassValidatorCreateUser()
        {
            var request = new CreateUser() { EmployeeName="sara",EmployeeEmailId="sara@gamil.com",EmployeeMobileNumber="987656789",EmployeeAddress="street",EmployeeMaritalStatus="Married",EmployeeDateOfJoining=DateTime.Today };
            dbContextMock.Setup(x => x.SaveChangesAsync(CancellationToken.None)).Returns(() => Task.Run(() => { return 1; })).Verifiable();
            var response = handler.Handle(request, CancellationToken.None);

            Assert.True(response.Result.ResponseValue!=0);
                     
        }
        [Fact]
        public void FailsValidatorCreateUser()
        {
            var request = new CreateUser() { EmployeeName="sara", EmployeeEmailId="sara@gamil.com", EmployeeMobileNumber="987656789", EmployeeAddress="street", EmployeeMaritalStatus="Married", EmployeeDateOfJoining=DateTime.Today };
            dbContextMock.Setup(x => x.SaveChangesAsync(CancellationToken.None)).Returns(() => Task.Run(() => { return 1; })).Verifiable();
            var response = handler.Handle(request, CancellationToken.None);
            Assert.False(response.Result.ResponseValue==0);

        }
        #endregion


        #region Exception Validation
        [Fact]
        public void ExceptionValidatorforCreateUser()
        {

            var request = new CreateUser() { EmployeeName="sara", EmployeeEmailId="sara@gamil.com", EmployeeMobileNumber="987656789", EmployeeAddress="street", EmployeeMaritalStatus="Married", EmployeeDateOfJoining=DateTime.Today };
            dbContextMock.Setup(c => c.SaveChangesAsync(CancellationToken.None)).Returns(() => Task.Run(() => { return 0; })).Verifiable();

            var response = Record.ExceptionAsync(async () => await handler.Handle(request, CancellationToken.None));
            Assert.IsType<ExceptionModel.EmployeeBadRequestException>(response.Result);

        }
        #endregion

    }
}
