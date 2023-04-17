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
        /// <summary>
        /// Creating Mediator for EmployeeManagement Controller 
        /// </summary>
        /// <param name="mediator"></param>
        /// 
        //private ILogger _logger;
        //public EmployeeManageController(ILogger logger)
        //{
        //    _logger = logger;
        //}

        public EmployeeManageController(IMediator mediator)
        {
            _mediator=mediator;
        }
        /// <summary>
        /// Getting EmployeeManagementList by using Query & Request Handler
        /// </summary>
        /// <returns> Gives EmployeeManagement List Details</returns>
        // GET: api/<EmployeeManageController>
        [HttpGet]

        public async Task<List<EmployeeManagementApplication>> EmployeeManagementListDetails()
        {
            var employeelist = await _mediator.Send(new GetEmployeeListQuery()); // getting from Query
            return employeelist;
        }


        /// <summary>
        /// Getting EmployeeDetails with EmployeeId using RequestHandler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // GET api/<EmployeeManageController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<EmployeeManagementApplication> EmployeeManagementDetailsById(int id)
        {

            var employeeId = await _mediator.Send(new GetEmployeeByIdQuery() { Id=id });
            return employeeId;
        }

        /// <summary>
        /// Adding EmployeeDetails
        /// </summary>
        /// <param name="addEmployee"></param>
        /// <returns> Add the Employee Details and save in database Table  </returns>

        // POST api/<EmployeeManageController>
        [HttpPost]
   
        public async Task<IActionResult> AddEmployeeDetails(CreateUser addEmployee)
        {
            //EmployeeDetails is 0 or null throws StatusError
            if (addEmployee==null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, addEmployee);
            }
            else
            {
                var result = await _mediator.Send(addEmployee);
                //addEmployee.EmployeeName,
                //addEmployee.EmployeeEmailId,
                //addEmployee.EmployeeMobileNumber,
                //addEmployee.EmployeeAddress,
                //addEmployee.EmployeeMaritalStatus,
                //addEmployee.EmployeeDateOfJoining
                //));

                return Ok(result);
            }
        }

        /// <summary>
        /// Updating EmployeeManagementDetails Check with null values
        /// </summary>
        /// <param name="updateEmployee"></param>
        /// <returns> Check with EmployeeId and Update the Details in table</returns>

        // PUT api/<EmployeeManageController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateEmployeeDetails(UpdateUser updateEmployee)
        {
            //EmployeeId is 0 or null throws StatusError
            if (updateEmployee==null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, updateEmployee);
            }
            else
            {
                var ValueReturn = await _mediator.Send(updateEmployee);
                //(updateEmployee.EmployeeID,
                //updateEmployee.EmployeeName,
                //updateEmployee.EmployeeEmailId,
                //updateEmployee.EmployeeMobileNumber,
                //updateEmployee.EmployeeAddress,
                //updateEmployee.EmployeeMaritalStatus,
                //updateEmployee.EmployeeDateOfJoining));
                return Ok(ValueReturn);
            }

        }


        /// <summary>
        /// Delete EmployeeDetails by EmployeeId
        /// </summary>
        /// <param name="deleteUser"></param>
        /// <returns> Check with EmployeeId and Delete the Details or throws error </returns>

        // DELETE api/<EmployeeManageController>/5
        [HttpDelete("{id}")]

        public Task<ResultResponse> DeleteEmployeeDetails(DeleteUser deleteUser)
        {

            var result = _mediator.Send(new DeleteUser() { EmployeeId=deleteUser.EmployeeId });//By EmployeeId from deleteuser
            return result;
        }
    }
}
