using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSOE.Models.ViewModels
{
    public class EmployeePageViewModel
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EmploymentDate { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
    }
}
