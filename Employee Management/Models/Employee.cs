using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management.Models
{
    public class Employee
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }    
        public string PhotoPath { get; set; }

        public Department Department { get; set; }
        public Position Position { get; set; }
        public Schedule Schedule { get; set; }
    }
}
