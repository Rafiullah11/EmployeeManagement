using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.IRepository
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeById(int id);
        IEnumerable<Employee> GetAllEmployee();
        Employee Add(Employee employee);
        Employee Update(Employee updateEmployee);
        Employee Delete(int id);
    }
}
