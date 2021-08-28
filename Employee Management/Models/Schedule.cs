using System.Collections.Generic;

namespace Employee_Management.Models
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }

       public ICollection<Employee> Employees { get; set; }

    }
}
