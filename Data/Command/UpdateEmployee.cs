using EmployeeManagementAPI.Model;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.Data.Command
{
    public class UpdateEmployee : IRequest<int>
    {
        public UpdateEmployee(int id, string firstName, string eMail, string phone, string address, string marritalstatus, DateTime dOJ)
        {
            Id=id;
            FirstName=firstName;
            EMail=eMail;
            Phone=phone;
            Address=address;
            Marritalstatus=marritalstatus;
            DOJ=dOJ;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        [EmailAddress]
        public string EMail { get; set; }
        public string Phone { get; set; }

        public string Address { get; set; }
        public string Marritalstatus { get; set; }
        public DateTime DOJ { get; set; }
    }
}
