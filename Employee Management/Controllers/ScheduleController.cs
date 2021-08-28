using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee_Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IScheduleRepository scheduleRepository;

        public ScheduleController(IScheduleRepository scheduleRepository)
        {
            this.scheduleRepository = scheduleRepository;
        }

        public IActionResult Index()
        {
            var model = scheduleRepository.GetAllSchedule();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Schedule sch = new Schedule();
            return PartialView("Create", sch);
        }

        [HttpPost]
        public IActionResult Create(Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                scheduleRepository.Add(schedule);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var schedule = scheduleRepository.GetSchedule(id);
            return PartialView("Edit", schedule);
        }

        [HttpPost]
        public IActionResult Edit(Schedule schedule)
        {
            scheduleRepository.Update(schedule);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            scheduleRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}