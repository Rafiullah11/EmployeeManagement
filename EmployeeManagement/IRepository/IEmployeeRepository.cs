using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;

namespace EmployeeManagement.IRepository
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int Id);
        IEnumerable<Employee> GetAllEmployee();
        Employee Add(Employee employee);
        Employee Update(Employee employeeChanges);
        Employee Delete(int id);
    }
}
