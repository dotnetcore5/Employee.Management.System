using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee_Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management.Controllers
{
    public class PositionController : Controller
    {
        private readonly IPositionRepository positionRepository;

        public PositionController(IPositionRepository positionRepository)
        {
            this.positionRepository = positionRepository;
        }

        public IActionResult Index()
        {
            var model = positionRepository.GetAllPosition();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Position po = new Position();
            return PartialView("Create", po);
            //return View();
        }

        [HttpPost]
        public IActionResult Create(Position position)
        {
            if (ModelState.IsValid)
            {
                positionRepository.Add(position);
                //return PartialView("Create", position);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var position = positionRepository.GetPosition(id);
            return PartialView("Edit", position);
        }

        [HttpPost]
        public IActionResult Edit(Position po)
        {
            positionRepository.Update(po);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            positionRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}