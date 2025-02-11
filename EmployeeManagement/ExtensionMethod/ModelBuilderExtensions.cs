using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.ExtensionMethod
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                     new Employee
                    {
                        Id = 1,
                        Name = "Mary",
                        Email = "Mary@Email.com",
                        Department = Dept.IT,
                        PhotoPath ="noimage.jpg",
                    },
                    new Employee
                    {
                        Id = 2,
                        Name = "John",
                        Email = "John@Email.com",
                        Department = Dept.HR,
                        PhotoPath ="noimage.jpg",

                    },
                    new Employee
                    {
                        Id = 3,
                        Name = "Mark",
                        Email = "Mark@Email.com",
                        Department = Dept.Payroll,
                        PhotoPath ="noimage.jpg",

                    }
            );
        }
    }
}