using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management.Models
{
    public class Position
    {
        public int PositionID { get; set; }
        
        public string PositionName { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
