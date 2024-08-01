using Microsoft.AspNetCore.Identity;

namespace EmployeeManagement.ViewModels
{
    public class ApplicationUser :IdentityUser
    {
        public string City { get; set; }
    }
}
