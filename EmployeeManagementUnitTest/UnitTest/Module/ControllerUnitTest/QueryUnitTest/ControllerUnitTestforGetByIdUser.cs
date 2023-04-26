using EmployeeManagementAPI.Controllers;
using EmployeeManagementAPI.Data.Handlers;
using EmployeeManagementAPI.Model;
using MediatR;
using Moq;

namespace EmployeeManagementUnitTest.UnitTest.Module.ControllerUnitTest.QueryUnitTest
{
    public class ControllerUnitTestforGetByIdUser
    {
        Mock<IMediator> _mockMediator;
        EmployeeManageController _controller;

        public ControllerUnitTestforGetByIdUser()
        {
            _mockMediator = new Mock<IMediator>();
            _controller = new EmployeeManageController(_mockMediator.Object);
        }
        [Fact] //GetByIdController Test
        public async void ReturnsUserIdResponse()
        {
            #region"Assign"
            var data = new GetEmployeeDetail { Id=1};
            var entity = new EmployeeManagementApplication() { };
            _mockMediator.Setup(x => x.Send(It.IsAny<GetEmployeeDetail>(), default)).ReturnsAsync(entity);
            #endregion

            #region"Act"
            var response = await _controller.EmployeeManagementDetailsById(data.Id);
            #endregion

            #region"Assert"
            Assert.IsAssignableFrom<EmployeeManagementApplication>(response);
            #endregion
        }
    }
}
