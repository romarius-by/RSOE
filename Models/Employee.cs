using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSOE.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EmploymentDate { get; set; }
        public int PositionId { get; set; }
        public int CompanyId { get; set; }
    }
}
