using System;
using System.IO;
using System.Linq;
using Employee_Management.Models;
using Employee_Management.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Employee_Management.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IPositionRepository positionRepository;
        private readonly IScheduleRepository scheduleRepository;
        private readonly IDepartmentRepository departmentRepository;

        public HomeController(IEmployeeRepository employeeRepository, IWebHostEnvironment hostingEnvironment,
                                IPositionRepository positionRepository, IScheduleRepository scheduleRepository,
                                IDepartmentRepository departmentRepository)
        {
            _employeeRepository = employeeRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.positionRepository = positionRepository;
            this.scheduleRepository = scheduleRepository;
            this.departmentRepository = departmentRepository;
        }


        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployee();
            return View(model);
        }

        public IActionResult Delete(int id)
        {

            Employee model = _employeeRepository.Delete(id);
            if (model == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id);
            }
            return RedirectToAction("Index");
        }
        public ViewResult Details(int? id)
        {

            Employee model = _employeeRepository.GetEmployee(id.Value);
            if (model == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id.Value);
            }
            return View(model);
        }
        [HttpGet]
        public ViewResult Create()
        {
            EmployeeCreateViewModel model = new EmployeeCreateViewModel
            {
                PositionList = positionRepository.GetAllPosition(),
                ScheduleList = scheduleRepository.GetAllSchedule().Select(a => new SelectListItem()
                {
                    Value = a.ScheduleId.ToString(),
                    Text = a.TimeIn + '-' + a.TimeOut
                }).ToList(),
                DepartmentList = departmentRepository.GetAllDepartment()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessFile(model);
                Department department = departmentRepository.GetDepartment(model.DepartmentID);
                Position position = positionRepository.GetPosition(model.PositionID);
                Schedule schedule = scheduleRepository.GetSchedule(model.ScheduleID);

                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = department,
                    Position = position,
                    Schedule = schedule,
                    PhotoPath = uniqueFileName
                };


                _employeeRepository.Add(newEmployee);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel
            {
                ID = employee.ID,
                Name = employee.Name,
                Email = employee.Email,
                DepartmentID = employee.Department.DpartmentID,
                DepartmentList = departmentRepository.GetAllDepartment(),
                PositionID = employee.Position.PositionID,
                PositionList = positionRepository.GetAllPosition(),
                ScheduleID=employee.Schedule.ScheduleId,
                ScheduleList = scheduleRepository.GetAllSchedule().Select(a => new SelectListItem()
                {
                    Value = a.ScheduleId.ToString(),
                    Text = a.TimeIn + '-' + a.TimeOut
                }).ToList(),
                ExistingPhotoPath = employee.PhotoPath
            };

            return View(employeeEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeeRepository.GetEmployee(model.ID);
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Department = departmentRepository.GetDepartment(model.DepartmentID);
                employee.Position = positionRepository.GetPosition(model.PositionID);
                employee.Schedule = scheduleRepository.GetSchedule(model.ScheduleID);
                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }

                    employee.PhotoPath = ProcessFile(model);
                }

                _employeeRepository.Update(employee);
                return RedirectToAction("Index");
            }
            return View();
        }
        private string ProcessFile(EmployeeCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                model.Photo.CopyTo(fileStream);
            }

            return uniqueFileName;
        }
    }
}