using EmployeeManagement.Data;
using EmployeeManagement.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmployeeManagement.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;

        public SQLEmployeeRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public Employee Add(Employee employee)
        {
           _dbContext.Employees.Add(employee);
           _dbContext.SaveChanges();
            return employee;
        }

        public Employee Delete(int id)
        {
           var deleteEmployee = _dbContext.Employees.Find(id);
            if (deleteEmployee != null)
            {
                _dbContext.Employees.Remove(deleteEmployee);
                _dbContext.SaveChanges();
            }
            return deleteEmployee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _dbContext.Employees;
        }

        public Employee GetEmployeeById(int id)
        {
            return _dbContext.Employees.Find(id);
           
        }

        public Employee Update(Employee updateEmployee)
        {
           var employee = _dbContext.Employees.Attach(updateEmployee);
           employee.State = EntityState.Modified;
           _dbContext.SaveChanges();
           return updateEmployee;
        }
        //public Employee Update(Employee updateEmployee)
        //{
        //    var employee = _dbContext.Employees.FirstOrDefault(e =>e.Id == updateEmployee.Id);
        //    if (employee != null)
        //    {
        //        employee.Name = updateEmployee.Name;
        //        employee.Email = updateEmployee.Email;
        //        employee.Department = updateEmployee.Department;
        //        employee.Address = updateEmployee.Address;


        //    }
        //    return employee;
        //}
    }
}
