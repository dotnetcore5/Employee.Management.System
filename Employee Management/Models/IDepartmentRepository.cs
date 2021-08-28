using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management.Models
{
    public interface IDepartmentRepository
    {
        Department GetDepartment(int id);
        IEnumerable<Department> GetAllDepartment();
        Department Add(Department department);
        Department Update(Department departmentChange);
        Department Delete(int id);
    }
}
