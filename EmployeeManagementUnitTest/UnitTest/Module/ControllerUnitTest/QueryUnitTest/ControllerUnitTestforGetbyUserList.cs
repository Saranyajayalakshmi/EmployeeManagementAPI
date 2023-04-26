using EmployeeManagementAPI.Controllers;
using EmployeeManagementAPI.Data.Handlers;
using EmployeeManagementAPI.Model;
using MediatR;
using Moq;

namespace EmployeeManagementUnitTest.UnitTest.Module.ControllerUnitTest.QueryUnitTest
{
    public class ControllerUnitTestforGetbyUserList
    {
        Mock<IMediator> _mockMediator;
        EmployeeManageController _controller;

        public ControllerUnitTestforGetbyUserList()
        {
            _mockMediator = new Mock<IMediator>();
            _controller = new EmployeeManageController(_mockMediator.Object);
        }
        [Fact] // GetByUserList for ControllerUnit Test
        public async void ReturnsValuesResponse()
        {
            #region"Assign"
            var data = new GetEmployeeList { };
            var entity = new List<EmployeeManagementApplication>(){ };
            _mockMediator.Setup(x => x.Send(It.IsAny<GetEmployeeList>(), default)).ReturnsAsync(entity);
            #endregion

            #region"Act"
            var response = await _controller.EmployeeManagementListDetails();
            #endregion

            #region"Assert"
            Assert.IsAssignableFrom <List<EmployeeManagementApplication>>(response);
            #endregion
        }
    }
}
