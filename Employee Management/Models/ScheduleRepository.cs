using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management.Models
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly AppDbContext context;

        public ScheduleRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Schedule Add(Schedule schedule)
        {
            context.Schedules.Add(schedule);
            context.SaveChanges();
            return schedule;
        }

        public Schedule Delete(int id)
        {
            Schedule schedule = context.Schedules.Find(id);
            if (schedule != null)
            {
                context.Schedules.Remove(schedule);
                context.SaveChanges();
            }
            return schedule;
        }

        public IEnumerable<Schedule> GetAllSchedule()
        {
            return context.Schedules;
        }

        public Schedule GetSchedule(int id)
        {
            return context.Schedules.Find(id);
        }

        public Schedule Update(Schedule scheduleChange)
        {
            var schedule = context.Schedules.Attach(scheduleChange);
            schedule.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return scheduleChange;
        }
    }
}
