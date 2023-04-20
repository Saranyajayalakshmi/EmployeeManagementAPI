using EmployeeManagementAPI.Data.Command.Create;
using EmployeeManagementAPI.Data.Command.Delete;
using EmployeeManagementAPI.Data.Command.Update;
using EmployeeManagementAPI.Data.Query;
using EmployeeManagementAPI.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    

    public class EmployeeManageController : ControllerBase
    {
        // Adding Mediator in Controller
        private IMediator _mediator;
       
        /// <summary>
        /// Creating Mediator for EmployeeManagement Controller 
        /// </summary>
        /// <param name="mediator"></param>
        
      

        public EmployeeManageController(IMediator mediator)
        {
            _mediator=mediator;
            
        }
        #region Queries
        /// <summary>
        /// Get EmployeeList 
        /// </summary>
        /// <returns> Gives EmployeeManagement List Details</returns>
        // GET: api/<EmployeeManageController>
        [HttpGet]

        public async Task<List<EmployeeManagementApplication>> EmployeeManagementListDetails()
        {
            var employeelist = await _mediator.Send(new GetEmployeeListQuery()); // Retrieving from Query
            return employeelist;
        }


        /// <summary>
        /// Getting EmployeeDetails by EmployeeId
        /// </summary>
        /// <remarks>
        /// {
        /// 
        ///     "EmployeeId":"1"
        ///     
        ///  }
        ///     
        /// </remarks>
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
        #endregion


        #region Commands
        /// <summary>
        /// Create List of Users 
        /// </summary>
        /// <remarks>
        /// {
        /// 
        ///            "EmployeeName" ="sara",
        ///            
        ///            "EmployeeEmailId"="sara@gmail.com",
        ///            
        ///            "EmployeeMobileNumber"="987678898",
        ///            
        ///            "EmployeeAddress"="Chennai-2000461",
        ///            
        ///            "EmployeeMaritalStatus"="Married",
        ///            
        ///            "EmployeeDateOfJoining"="2023/19/20"
        ///            
        ///       }     
        ///  </remarks>
        /// <param name="addEmployee"></param>
        /// <returns> returns affected rows and additional info </returns>

        // POST api/<EmployeeManageController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

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
                return Ok(result);
              
            }
        }

        /// <summary>
        /// Updates Employee Details 
        /// </summary>
        /// <remarks>
        /// {
        /// 
        ///            "EmployeeId" = "1",
        ///            
        ///            "EmployeeName" ="sara",
        ///            
        ///            "EmployeeEmailId"="sara@gmail.com",
        ///            
        ///            "EmployeeMobileNumber"="987678898",
        ///            
        ///            "EmployeeAddress"="Chennai-2000461",
        ///            
        ///            "EmployeeMaritalStatus"="Married",
        ///            
        ///            "EmployeeDateOfJoining"="2023/19/20"
        ///            
        ///            }
        /// </remarks>
        /// <param name="updateEmployee"></param>
        /// <returns>returns EmployeeId and Additional info </returns>

        // PUT api/<EmployeeManageController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateEmployeeDetails(UpdateUser updateEmployee)
        {
            //UpdateEmployee if null throws StatusError
            if (updateEmployee==null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, updateEmployee);
            }
            else
            {
                var ValueReturn = await _mediator.Send(updateEmployee);
                return Ok(ValueReturn);
            }
        }

        /// <summary>
        /// Delete Employee by EmployeeId
        /// </summary>
        /// <remarks>
        /// {
        /// 
        ///      "EmployeeId" = "1"
        ///      
        /// }
        /// </remarks>
        /// <param name="deleteUser"></param>
        /// <returns> returns affected rows and Additional info </returns>

        // DELETE api/<EmployeeManageController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public Task<ResultValue> DeleteEmployeeDetails(DeleteUser deleteUser)
        {
            var result = _mediator.Send(new DeleteUser() { EmployeeId=deleteUser.EmployeeId });//By EmployeeId from deleteuser
            return result;
        }
        #endregion
    }
}
