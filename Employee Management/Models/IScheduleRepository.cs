using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management.Models
{
    public interface IScheduleRepository
    {
        Schedule GetSchedule(int id);
        IEnumerable<Schedule> GetAllSchedule();
        Schedule Add(Schedule schedule);
        Schedule Update(Schedule scheduleChange);
        Schedule Delete(int id);
    }
}
