using EmployeeManagementAPI.Data.Command.Create;
using EmployeeManagementAPI.Data.Command.Delete;
using EmployeeManagementAPI.Data.Command.Update;
using EmployeeManagementAPI.Data.Handlers;
using EmployeeManagementAPI.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Sockets;

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
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetIPAddress()
        {
            string ipAddress = string.Empty;
            IPAddress ip = Request.HttpContext.Connection.RemoteIpAddress;
            if (ip != null)
            {
                if (ip.AddressFamily==AddressFamily.InterNetwork)
                {
                    ip = Dns.GetHostEntry(ip).AddressList.First(x => x.AddressFamily == AddressFamily.InterNetwork);
                }
                ipAddress = ip.ToString();
            }
            return Ok(ipAddress);
        }

        #region Queries
        /// <summary>
        /// Get EmployeeList 
        /// </summary>
        /// <returns> Gives EmployeeManagement List Details</returns>
        // GET: api/<EmployeeManageController>
        [HttpGet("")]
        public async Task<List<EmployeeManagementApplication>> EmployeeManagementListDetails()
        {
            var employeelist = await _mediator.Send(new GetEmployeeList()); // Retrieving from Query
            return employeelist;
        }


        /// <summary>
        /// Get EmployeeDetails by EmployeeId
        /// </summary>
        /// <remarks>
        /// 
        ///     "id":"1"
        ///    
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>

        // GET api/<EmployeeManageController>/5
        [HttpGet("{id}")]
     
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<EmployeeManagementApplication> EmployeeManagementDetailsById([FromRoute]int id)
        {
            var employeeId = await _mediator.Send(new GetEmployeeDetail() { Id=id });//Retrieving from Query
            return employeeId;
        }
        #endregion
       
        #region Commands
        /// <summary>
        /// Create Users 
        /// </summary>
        /// <remarks>
        /// 
        /// Example Value
        /// ------- -----
        /// 
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

        public async Task<ResultResponse> AddEmployeeDetails(CreateUser addEmployee)
        {
            var result = await _mediator.Send(addEmployee);
            return result;


        }

        /// <summary>
        /// Updates Employee Details 
        /// </summary>
        /// <remarks>
        /// 
        /// Example Value
        /// ------- -----
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
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ResultResponse> UpdateEmployeeDetails(UpdateUser updateEmployee)
        {

            var ValueReturn = await _mediator.Send(updateEmployee);
            return ValueReturn;

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

        public Task<ResultResponse> DeleteEmployeeDetails([FromRoute]int id)
        {
            var result = _mediator.Send(new DeleteUser() { EmployeeId=id });//By EmployeeId from deleteuser
            return result;
        }
        #endregion
    }
}
