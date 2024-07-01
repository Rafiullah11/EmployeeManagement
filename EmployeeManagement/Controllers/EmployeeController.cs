using Microsoft.AspNetCore.Hosting;
using EmployeeManagement.IRepository;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Net;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public EmployeeController(IEmployeeRepository employeeRepository, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            this.hostingEnvironment = hostingEnvironment;
        }
        public ActionResult Index()
        {
            var list = _employeeRepository.GetAllEmployee();
            return View(list);
        }

        [HttpGet("Details/{id}")]
        public IActionResult Details(int id)
        {
            Employee employee = _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound",id);
            }
            EmployeeDetailsViewModel viewModel = new EmployeeDetailsViewModel()
            {
                Employee = employee,
                PageTitle = "Employee Details"
            };
         
            return View(viewModel);
        }

        [HttpGet("Create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                if (model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;

                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        model.Photo.CopyTo(fileStream);
                    }
                }

                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    Address = model.Address,
                    PhotoPath = uniqueFileName
                };

                _employeeRepository.Add(newEmployee);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet("Edit")]
        public ActionResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployeeById(id);
            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                Address = employee.Address,
                ExistingPhotoPah = employee.PhotoPath
            };

            return View(employeeEditViewModel);
        }

        [HttpPost("Edit")]
        public ActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeeRepository.GetEmployeeById(model.Id);

                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Department = model.Department;
                employee.Address = model.Address;
                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPah != null)
                    {
                      string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images",model.ExistingPhotoPah);
                        System.IO.File.Delete(filePath);
                    }
                    employee.PhotoPath = PhotoUploadMethod(model);
                }

                _employeeRepository.Update(employee);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        private string PhotoUploadMethod(EmployeeEditViewModel model)
        {
            string uniqueFileName = null;

            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");

                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;

                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }




    }
}
