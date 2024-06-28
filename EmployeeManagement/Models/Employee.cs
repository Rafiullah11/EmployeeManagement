using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="please try with correct email address")]
        public string? Email { get; set; }
        [Required]
        public Dept Department { get; set; }
        public string? Address { get; set; }
        public string? PhotoPath { get; set; }
    }
}
