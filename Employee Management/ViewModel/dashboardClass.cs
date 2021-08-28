using Employee_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management.ViewModel
{
    public class dashboardClass
    {
        public IEnumerable<Department> DepartmentList { get; set; }
        public IEnumerable<Employee> EmployeeList { get; set; }
        public IEnumerable<Position> PositionList { get; set; }
        public IEnumerable<Schedule> ScheduleList { get; set; }
    }
}
