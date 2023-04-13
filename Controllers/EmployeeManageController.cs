using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Data.Command;
using EmployeeManagementAPI.Data.Command.Create;
using EmployeeManagementAPI.Data.Command.Delete;
using EmployeeManagementAPI.Data.Command.Update;
using EmployeeManagementAPI.Data.Handlers;
using EmployeeManagementAPI.Data.Query;
using EmployeeManagementAPI.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // Adding Mediator in Controller

    public class EmployeeManageController : ControllerBase
    {
        private IMediator _mediator;

        public EmployeeManageController(IMediator mediator)
        {
            _mediator=mediator;
        }
        /// <summary>
        /// Getting EmployeeManagementList by using Query & Request Handler
        /// </summary>
        /// <returns></returns>
        // GET: api/<EmployeeManageController>
        [HttpGet]

        public async Task<List<EmployeeManagementApplication>> EmployeeManagementListDetails()
        {
            var employeelist = await _mediator.Send(new GetEmployeeListQuery());
            return employeelist;
        }


        /// <summary>
        /// Getting EmployeeDetails with EmployeeId using RequestHandler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // GET api/<EmployeeManageController>/5
        [HttpGet("{id}")]
        public async Task<EmployeeManagementApplication> EmployeeManagementDetailsById(int id)
        {

            var employeeId = await _mediator.Send(new GetEmployeeByIdQuery() { Id=id });
            return employeeId;
        }

        /// <summary>
        /// Adding EmployeeDetails
        /// </summary>
        /// <param name="addEmployee"></param>
        /// <returns></returns>

        // POST api/<EmployeeManageController>
        [HttpPost]
        public async Task<IActionResult> AddEmployeeDetails(CreateUser addEmployee)
        {
            //EmployeeDetails is null throws StatusError
            if (addEmployee==null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, addEmployee);
            }
            else
            {
                var result = await _mediator.Send(new CreateUser(
                    addEmployee.EmployeeName,
                    addEmployee.EmployeeEmailId,
                    addEmployee.EmployeeMobileNumber,
                    addEmployee.EmployeeAddress,
                    addEmployee.EmployeeMaritalStatus,
                    addEmployee.EmployeeDateOfJoining
                    ));

                return Ok(result);
            }
        }

        /// <summary>
        /// Updating EmployeeManagementDetails Check with null values
        /// </summary>
        /// <param name="updateEmployee"></param>
        /// <returns></returns>

        // PUT api/<EmployeeManageController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeDetails(UpdateUser updateEmployee)
        {
            //EmployeeId is null throws StatusError
            if (updateEmployee==null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, updateEmployee);
            }
            else
            {
                var ValueReturn = await _mediator.Send(new UpdateUser
                (updateEmployee.EmployeeID,
                updateEmployee.EmployeeName,
                updateEmployee.EmployeeEmailId,
                updateEmployee.EmployeeMobileNumber,
                updateEmployee.EmployeeAddress,
                updateEmployee.EmployeeMaritalStatus,
                updateEmployee.EmployeeDateOfJoining));
                return Ok(ValueReturn);
            }

        }


        /// <summary>
        /// Delete EmployeeDetails by EmployeeId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // DELETE api/<EmployeeManageController>/5
        [HttpDelete("{id}")]

        public Task<ResultResponse> DeleteEmployeeDetails(int id)
        {

            var result = _mediator.Send(new DeleteUser() { EmployeeId=id });

            return result;
        }
    }
}
