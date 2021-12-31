using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDOperationWebAPI.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public int EmployeeSalary { get; set; }
        public string EmployeeContactNumber { get; set; }
    }
}
