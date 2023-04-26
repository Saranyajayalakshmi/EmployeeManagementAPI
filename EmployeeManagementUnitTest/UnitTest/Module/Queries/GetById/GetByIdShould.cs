using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Data.Handlers;
using EmployeeManagementAPI.ExceptionHandling;
using EmployeeManagementAPI.Model;
using EntityFrameworkCoreMock;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementUnitTest.UnitTest.Module.GetById
{
    public class GetByIdShould
    {
        DbContextMock<DataDbContext> dbContextMock;
        GetEmployeeById handler;
        List<EmployeeManagementApplication> EmployeeApplication = new List<EmployeeManagementApplication>() { new EmployeeManagementApplication() { EmployeeID = 1, EmployeeName = "sara", EmployeeEmailId = "sara@gamil.com", EmployeeAddress = "street", EmployeeMobileNumber = "987654357", EmployeeMaritalStatus = "Single", EmployeeDateOfJoining = DateTime.Today } };

        DbContextOptions<DataDbContext> dbContextOptions { get; } = new DbContextOptionsBuilder<DataDbContext>().Options;
        public GetByIdShould()
        {
            dbContextMock = new DbContextMock<DataDbContext>(dbContextOptions);
            handler = new GetEmployeeById(dbContextMock.Object);
            dbContextMock.CreateDbSetMock(x => x.managementApplications, EmployeeApplication);
        }
        [Fact]

        #region Validator for GetEmployeeId
        public void PassValidatorforGetEmployeeId()
        {
            var request = new GetEmployeeDetail() { Id = 1 };
            var response = handler.Handle(request, CancellationToken.None);
            Assert.False(response.Result.Equals(EmployeeApplication));
        }
        #endregion
        [Fact]
        public void ExceptionvalidatorforGetById()
        {
            var request = new GetEmployeeDetail() { Id = 3 };
            var response = Record.ExceptionAsync(async () => await handler.Handle(request, CancellationToken.None));

            Assert.IsType<ExceptionModel.IdNotFoundException>(response.Result);
        }
    }
}
