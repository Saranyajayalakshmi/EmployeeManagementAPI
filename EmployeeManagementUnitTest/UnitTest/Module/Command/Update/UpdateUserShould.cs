using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Data.Command.Update;
using EmployeeManagementAPI.ExceptionHandling;
using EmployeeManagementAPI.Model;
using EntityFrameworkCoreMock;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementUnitTest.UnitTest.Module.Command.Update
{
    public class UpdateUserShould
    {
        //Create DbMock 
        DbContextMock<DataDbContext> dbContextMock;
        UpdateEmployeeHandler handler;
        //Create Dummy Table for Validator
        List<EmployeeManagementApplication> EmployeeApp = new List<EmployeeManagementApplication>() { new EmployeeManagementApplication() { EmployeeID=1,EmployeeName="sara",EmployeeEmailId="sara@gamil.com",EmployeeAddress="street",EmployeeMobileNumber="987654357",EmployeeMaritalStatus="Single",EmployeeDateOfJoining=DateTime.Today} };

        DbContextOptions<DataDbContext> dbContextOptions { get; } = new DbContextOptionsBuilder<DataDbContext>().Options;
        public UpdateUserShould()
        {
            dbContextMock = new DbContextMock<DataDbContext>(dbContextOptions);
            handler = new UpdateEmployeeHandler(dbContextMock.Object);
            dbContextMock.CreateDbSetMock(x => x.managementApplications, EmployeeApp);
        }
        #region UpdateUser Pass Validator
        [Fact]
        
        public void PassValidationforUpdateUser()
        {
            var request = new UpdateUser() { EmployeeID=1,EmployeeName="sara", EmployeeEmailId="sa@gmail.com", EmployeeMobileNumber="565767687", EmployeeAddress="chennai", EmployeeMaritalStatus="Married",EmployeeDateOfJoining=DateTime.Today };
            dbContextMock.Setup(x => x.SaveChangesAsync(CancellationToken.None)).Returns(() => Task.Run(() => { return 1; })).Verifiable();
            var response = handler.Handle(request, CancellationToken.None);
            Assert.True(response.Result.ResponseValue!=0);
        }
        #endregion

        #region Exception validator for UpdateUser
        [Fact]
        public void ExceptionvalidatorforUpdateUser()
        {
            var request = new UpdateUser() { };
            var response = Record.ExceptionAsync(async () => await handler.Handle(request, CancellationToken.None));
            dbContextMock.Setup(x => x.SaveChangesAsync(CancellationToken.None)).Returns(() => Task.Run(() => { return 0; })).Verifiable();
           
            Assert.IsType<ExceptionModel.EmployeeNotFoundException>(response.Result);
        }
        #endregion
    }
}
