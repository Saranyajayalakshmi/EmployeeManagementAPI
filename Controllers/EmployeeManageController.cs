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
    public class EmployeeManageController : ControllerBase
    {
        private IMediator _mediator;

        public EmployeeManageController(IMediator mediator)
        {
            _mediator=mediator;
        }

        // GET: api/<EmployeeManageController>
        [HttpGet]
        // [Route("api/[EmployeeList]")]
        public async Task<List<EmployeeManage>> EmployeeList()
        {
            var employeelist = await _mediator.Send(new GetEmployeeListQuery());
            return employeelist;
        }

        // GET api/<EmployeeManageController>/5
        [HttpGet("{id}")]
        public async Task<EmployeeManage> EmployeeById(int id)
        {
           
            var employeeId = await _mediator.Send(new GetEmployeeByIdQuery() { Id=id });
            return employeeId;
        }

        // POST api/<EmployeeManageController>
        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeManage addEmployee)
        {
            if (addEmployee==null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, addEmployee);
            }
            else
            {
                var result = await _mediator.Send(new CreateEmployee(
                    addEmployee.FirstName,
                    addEmployee.Email,
                    addEmployee.Phone,
                    addEmployee.Address,
                    addEmployee.MarritalStatus,
                    addEmployee.DOJ
                    ));

                return Ok(result);
            }
        }


        // PUT api/<EmployeeManageController>/5
        [HttpPut("{id}")]
        public async Task<int> UpdateEmployee(EmployeeManage updateEmployee)
        {
            var ValueReturn = await _mediator.Send(new UpdateEmployee
                (updateEmployee.Id,
                updateEmployee.FirstName,
                updateEmployee.Email,
                updateEmployee.Phone,
                updateEmployee.Address,
                updateEmployee.MarritalStatus,
                updateEmployee.DOJ));
            return ValueReturn;
        }

        // DELETE api/<EmployeeManageController>/5
        [HttpDelete("{id}")]

        public async Task<int> DeleteEmployee(int id)
        {
            return await _mediator.Send(new DeleteEmployee() { Id=id });
        }
    }
}
