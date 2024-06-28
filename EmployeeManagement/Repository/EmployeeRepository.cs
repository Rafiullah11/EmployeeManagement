using EmployeeManagement.Data;
using EmployeeManagement.IRepository;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EmployeeManagement.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        //private readonly AppDbContext _appDbContext;

        private List<Employee> _employeeList;
        public EmployeeRepository()
        {
            //this._appDbContext = appDbContext;
            _employeeList = new List<Employee>()
            {
              new Employee { Id = 1, Name = "John", Email = "Johan@Email.com", Department=Dept.Developer, Address = "address 1" },
              new Employee { Id = 2, Name = "Mike", Email = "Mike@Email.com", Department=Dept.HR, Address = "address 2" },
              new Employee { Id = 3, Name = "Teddy", Email = "Teddy@Email.com",Department= Dept.IT, Address = "address 3" },
              new Employee { Id = 4, Name = "Jame", Email = "Jame@Email.com", Department=Dept.IT, Address = "address 4" }
            };

        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(x => x.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Delete(int id)
        {
            var deleteEmployee = _employeeList.FirstOrDefault(e => e.Id == id);
            if (deleteEmployee != null)
            {
                _employeeList.Remove(deleteEmployee);
                
            }
            return deleteEmployee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
        }

        public Employee GetEmployeeById(int id)
        {
            return _employeeList.FirstOrDefault(x => x.Id == id);
        }

        public Employee Update(Employee updateEmployee)
        {
            var employee = _employeeList.FirstOrDefault(e => e.Id == updateEmployee.Id);
            if (employee != null)
            {
                employee.Name = updateEmployee.Name;
                employee.Email = updateEmployee.Email;
                employee.Department = updateEmployee.Department;
                employee.Address = updateEmployee.Address;

            }
            return employee;
        }
       
    }
}
