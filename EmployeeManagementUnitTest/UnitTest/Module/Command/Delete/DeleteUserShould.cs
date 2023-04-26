using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Data.Command.Delete;
using EmployeeManagementAPI.ExceptionHandling;
using EmployeeManagementAPI.Model;
using EntityFrameworkCoreMock;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementUnitTest.UnitTest.Module.Command.Delete
{
    public class DeleteUserShould
    {
        //Create DbMock
        DbContextMock<DataDbContext> dbContextMock;
        DeleteEmployeeHandler handler;
        //Create Dummy Table for DbMock
        List<EmployeeManagementApplication> EmployeeApp = new List<EmployeeManagementApplication>() { new EmployeeManagementApplication() { EmployeeID=1, EmployeeName="sara", EmployeeEmailId="sara@gamil.com", EmployeeAddress="street", EmployeeMobileNumber="987654357", EmployeeMaritalStatus="Single", EmployeeDateOfJoining=DateTime.Today } };

        DbContextOptions<DataDbContext> dbContextOptions { get; } = new DbContextOptionsBuilder<DataDbContext>().Options;
        public DeleteUserShould()
        {
            dbContextMock = new DbContextMock<DataDbContext>(dbContextOptions);
            handler = new DeleteEmployeeHandler(dbContextMock.Object);
            dbContextMock.CreateDbSetMock(x => x.managementApplications, EmployeeApp);
        }
        #region Deleteuser PassValidator
        [Fact]
        public void DeletePassValidator()
        {
            var request = new DeleteUser() { EmployeeId=1, };
            dbContextMock.Setup(x => x.SaveChangesAsync(CancellationToken.None)).Returns(() => Task.Run(() => { return 1; })).Verifiable();
            var response = handler.Handle(request, CancellationToken.None);
            Assert.True(response.Result.ResponseValue!=0);
        }
        #endregion
        #region Exception Validator
        [Fact]
        public void ExceptionvalidatorForDelete()
        {
            var request = new DeleteUser() { };
            var response = Record.ExceptionAsync(async () => await handler.Handle(request, CancellationToken.None));
            dbContextMock.Setup(x => x.SaveChangesAsync(CancellationToken.None)).Returns(() => Task.Run(() => { return 0; })).Verifiable();

            Assert.IsType<ExceptionModel.EmployeeBadRequestException>(response.Result);
        }
        #endregion
    }
}