using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management.ViewModel
{
    public class EmployeeEditViewModel : EmployeeCreateViewModel
    {
        public int ID { get; set; }
        public string ExistingPhotoPath { get; set; }
    }
}
