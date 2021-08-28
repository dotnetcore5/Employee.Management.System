using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management.Models
{
    public class Department
    {
        [Key]
        public int DpartmentID { get; set; }
        public string DepartmentName { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
