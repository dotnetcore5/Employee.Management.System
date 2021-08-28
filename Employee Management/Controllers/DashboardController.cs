using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee_Management.Models;
using Employee_Management.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IPositionRepository positionRepository;
        private readonly IScheduleRepository scheduleRepository;
        private readonly IDepartmentRepository departmentRepository;

        public DashboardController(IEmployeeRepository employeeRepository,
                                IPositionRepository positionRepository, IScheduleRepository scheduleRepository,
                                IDepartmentRepository departmentRepository)
        {
            this.employeeRepository = employeeRepository;
            this.positionRepository = positionRepository;
            this.scheduleRepository = scheduleRepository;
            this.departmentRepository = departmentRepository;
        }

        public IActionResult Index()
        {
            dashboardClass model = new dashboardClass
            {
                DepartmentList = departmentRepository.GetAllDepartment(),
                EmployeeList = employeeRepository.GetAllEmployee(),
                PositionList = positionRepository.GetAllPosition(),
                ScheduleList = scheduleRepository.GetAllSchedule()
            };

            return View(model);
        }
    }
}