using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text.RegularExpressions;
using EmployeeManagementAPI.Model;
using EmployeeManagementAPI.Services;
using FluentValidation;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmployeeManagementAPI.Fluent_Validation
{
    public class EmailValidation : PropertyValidator
    {
        public EmailValidation() : base("Please enter Correct MailId")
        {

        }
        protected override bool IsValid(PropertyValidatorContext contect)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);
            if (contect.PropertyValue != null)
            {
                return regex.IsMatch((string)contect.PropertyValue);
            }
            else
            {
                return false;
            }


        }
    }


}
