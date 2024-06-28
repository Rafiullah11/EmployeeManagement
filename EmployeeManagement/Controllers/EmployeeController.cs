using Microsoft.AspNetCore.Hosting;
using EmployeeManagement.IRepository;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("Employee")]
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
            EmployeeDetailsViewModel viewModel = new EmployeeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployeeById(id),
                PageTitle = "Employee Details"
            };
         
            return View(viewModel);
        }

        [HttpGet("Create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
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

        [HttpPost("Update")]
        public ActionResult UpdateEmployee(Employee employee)
        {
            return View();
        }

       



    }
}
