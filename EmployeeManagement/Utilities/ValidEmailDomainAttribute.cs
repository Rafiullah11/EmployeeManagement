using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Utilities
{
    public class ValidEmailDomainAttribute :ValidationAttribute
    {
        private readonly string allowedDomain;

        public ValidEmailDomainAttribute(string allowedDomain)
        {
            this.allowedDomain = allowedDomain;
        }
        public override bool IsValid(object? value)
        {
           string[] str = value.ToString().Split('@');
           return str[1].ToUpper() == allowedDomain.ToUpper();

        }
    }
}
