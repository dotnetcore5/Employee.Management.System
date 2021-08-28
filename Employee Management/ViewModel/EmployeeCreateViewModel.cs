using Employee_Management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management.ViewModel
{
    public class EmployeeCreateViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [Remote(action: "isEmailInUse", controller: "Account")]
        public string Email { get; set; }
        [Required]
        public int DepartmentID { get; set; }
        public IEnumerable<Department> DepartmentList { get; set; }
        
        public int ScheduleID { get; set; }
        public List<SelectListItem> ScheduleList { get; set; }
        [Required]
        public int PositionID { get; set; }
        public IEnumerable<Position> PositionList { get; set; }
        public IFormFile Photo { get; set; }
    }
}
