using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.ViewModels
{
    public class RoleCreateViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
