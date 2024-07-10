using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.ViewModels
{
    public class EmployeeCreateViewModel
    {
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "please try with correct email address")]
        [Remote(action:"IsEmailInUse", controller:"Account")]
        public string? Email { get; set; }
        [Required]
        public Dept Department { get; set; }
        public string? Address { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
