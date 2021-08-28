using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext context;

        public DepartmentRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Department Add(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
            return department;
        }

        public Department Delete(int id)
        {
            Department department = context.Departments.Find(id);
            if (department != null)
            {
                context.Departments.Remove(department);
                context.SaveChanges();
            }
            return department;
        }

        public IEnumerable<Department> GetAllDepartment()
        {
            return context.Departments;
        }

        public Department GetDepartment(int id)
        {
            return context.Departments.Find(id);
        }

        public Department Update(Department departmentChange)
        {
            var department = context.Departments.Attach(departmentChange);
            department.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return departmentChange;
        }
    }
}
