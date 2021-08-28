using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee_Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        public IActionResult Index()
        {
            var model = departmentRepository.GetAllDepartment();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Department department = new Department();
            return PartialView("Create", department);
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                departmentRepository.Add(department);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var department = departmentRepository.GetDepartment(id);
            return PartialView("Edit", department);
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            departmentRepository.Update(department);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            departmentRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}