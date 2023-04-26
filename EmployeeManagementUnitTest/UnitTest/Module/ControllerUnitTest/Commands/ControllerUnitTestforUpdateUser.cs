using EmployeeManagementAPI.Controllers;
using EmployeeManagementAPI.Data.Command.Update;
using EmployeeManagementAPI.Model;
using MediatR;
using Moq;

namespace EmployeeManagementUnitTest.UnitTest.Module.ControllerUnitTest.Commands
{
    public class ControllerUnitTestforUpdateUser
    {
        Mock<IMediator> _mockMediator;
        EmployeeManageController _controller;

        public ControllerUnitTestforUpdateUser()
        {
            _mockMediator = new Mock<IMediator>();
            _controller = new EmployeeManageController(_mockMediator.Object);
        }
        
        [Theory]
        [MemberData(nameof(TestDataProvider.CreateObject), MemberType = typeof(TestDataProvider))]
        public async void ReturnsUpdateUserValueResponse(UpdateUser data)
        {
            #region Assign
            var entity = new ResultResponse {ResponseValue=1 };
            _mockMediator.Setup(x => x.Send(It.IsAny<UpdateUser>(), default)).ReturnsAsync(entity);

            #endregion

            #region"Act"
            var response = await _controller.UpdateEmployeeDetails(data);
            #endregion

            #region"Assert"
            Assert.NotEqual(2, response.ResponseValue);
            #endregion
        }
        #region Test Data Provider
        public class TestDataProvider
        {
            public static IEnumerable<object[]> CreateObject()
            {

                yield return new object[] { new UpdateUser()
                {
                    EmployeeID = 1,
                    EmployeeName="sara",
                    EmployeeEmailId="sa@gmail.com",
                    EmployeeMobileNumber="987656789",
                    EmployeeAddress="60002",
                    EmployeeMaritalStatus="Married",
                    EmployeeDateOfJoining=DateTime.Today
                } };
            }

        }
        #endregion
    }
}

