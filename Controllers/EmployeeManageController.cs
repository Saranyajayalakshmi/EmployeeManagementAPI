using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Data.Command;
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
        public async Task<List<EmployeeManage>> EmployeeList()
        {
            try
            {
                var employe = await _mediator.Send(new GetEmployeeListQuery());
                return employe;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<EmployeeManageController>/5
        [HttpGet("{id}")]
        public async Task<EmployeeManage>EmployeeById(int id)
        {
           var emp = await _mediator.Send(new GetEmployeeByIdQuery() { Id=id});  
            return emp;
        }

        // POST api/<EmployeeManageController>
        [HttpPost]
        public async Task<ResultResponse> AddEmployee(EmployeeManage employe) 
        {
            var res = await _mediator.Send(new CreateEmployee(
                employe.FirstName,
                employe.Email,
                employe.Phone,
                employe.Address,
                employe.Maritalstatus,
                employe.DOJ
                ));
            return res;
        }
        

        // PUT api/<EmployeeManageController>/5
        [HttpPut("{id}")]
        public async Task<int>UpdateEmployee([FromBody]EmployeeManage employeeManage)
        {
            var empReturn = await _mediator.Send(new UpdateEmployee
                (employeeManage.Id,
                employeeManage.FirstName,
                employeeManage.Email,
                employeeManage.Phone,
                employeeManage.Address,
                employeeManage.Maritalstatus,
                employeeManage.DOJ));
            return empReturn;
        }


        // DELETE api/<EmployeeManageController>/5
        [HttpDelete("{id}")]
       
        public async Task<int>Delete([FromBody]int id)
        {
            return await _mediator.Send(new DeleteEmployee() { Id=id});
        }
    }
}
