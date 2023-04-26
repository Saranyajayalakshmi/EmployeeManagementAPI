using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Data.Handlers;
using EmployeeManagementAPI.Model;
using EntityFrameworkCoreMock;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementUnitTest.UnitTest.Module.Queries.GetByUserList
{
    public class GetByUserListShould
    {
        //Create DbMock
        DbContextMock<DataDbContext> dbContextMock;
        GetEmployeeByList handler;
        //Create dummyTable for Dbmock
        List<EmployeeManagementApplication> EmployeeApplication = new List<EmployeeManagementApplication>() { new EmployeeManagementApplication() { EmployeeID = 1, EmployeeName = "sara", EmployeeEmailId = "sara@gamil.com", EmployeeAddress = "street", EmployeeMobileNumber = "987654357", EmployeeMaritalStatus = "Single", EmployeeDateOfJoining = DateTime.Today } };

        DbContextOptions<DataDbContext> dbContextOptions { get; } = new DbContextOptionsBuilder<DataDbContext>().Options;
        public GetByUserListShould()
        {
            dbContextMock = new DbContextMock<DataDbContext>(dbContextOptions);
            handler = new GetEmployeeByList(dbContextMock.Object);
            dbContextMock.CreateDbSetMock(x => x.managementApplications, EmployeeApplication);
        }
        #region Validator for GetEmployeeAll
        [Fact]
        public void ValidationforGetEmployeeList()
        {
            var request = new GetEmployeeList { };
            var response = handler.Handle(request, CancellationToken.None);
            Assert.False(response.Result.Count > 2);
        }
        #endregion
    }
}
