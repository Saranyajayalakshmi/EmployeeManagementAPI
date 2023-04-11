using EmployeeManagementAPI.Model;
using MediatR;

namespace EmployeeManagementAPI.Data.Command
{
    public class CreateEmployee :IRequest<ResultResponse>
    {
        public CreateEmployee(string firstName, string eMail, string phone, string address, string marritalstatus, DateTime dOJ)
        {
            FirstName=firstName;
            EMail=eMail;
            Phone=phone;
            Address=address;
            Marritalstatus=marritalstatus;
            DOJ=dOJ;
        }

        public string FirstName { get; set; }
        public string EMail { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Marritalstatus { get; set; }
        public DateTime DOJ { get; set; }
    }
}
