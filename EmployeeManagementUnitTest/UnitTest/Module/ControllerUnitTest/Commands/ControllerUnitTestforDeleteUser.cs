using EmployeeManagementAPI.Controllers;
using EmployeeManagementAPI.Data.Command.Delete;
using EmployeeManagementAPI.Model;
using MediatR;
using Moq;

namespace EmployeeManagementUnitTest.UnitTest.Module.ControllerUnitTest
{
    public class ControllerUnitTestforDeleteUser
    {

        Mock<IMediator> _mockMediator;
        EmployeeManageController _controller;

        public ControllerUnitTestforDeleteUser()
        {
            _mockMediator = new Mock<IMediator>();
            _controller = new EmployeeManageController(_mockMediator.Object);
        }
        [Theory]
        [MemberData(nameof(TestDataProvider.CreateObject), MemberType = typeof(TestDataProvider))]
        public async void ReturnsDeleteUserValueResponse(int id)
        {
            #region"Assign"
            var entity = new ResultResponse {ResponseValue=1};
            _mockMediator.Setup(x => x.Send(It.IsAny<DeleteUser>(), default)).ReturnsAsync(entity);
            #endregion 

            #region"Act"
            var response = await _controller.DeleteEmployeeDetails(id);
            #endregion

            #region"Assert"
            Assert.NotEqual(0, response.ResponseValue);
            #endregion
        }
        #region Test Data Provider
        public class TestDataProvider
        {
            public static IEnumerable<object[]> CreateObject()
            {

                yield return new object[] { new DeleteUser()
                {
                    EmployeeId = 1,
                } };
            }
        }
        #endregion
    }
}

