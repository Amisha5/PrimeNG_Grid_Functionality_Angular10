using CRUDOperationWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDOperationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        IConfiguration _configuration;
        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            MySqlDataReader rd = null;
           
            List<Employee> dept = new List<Employee>();
            using (MySqlConnection conn = new MySqlConnection(this._configuration.GetConnectionString("DefaultConnection")))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from Employee", conn);
                    rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        Employee obj = new Employee();
                        obj.EmployeeId = Convert.ToInt32(rd.GetValue(0));
                        obj.EmployeeName = Convert.ToString(rd.GetValue(1));
                        obj.EmployeeSalary = Convert.ToInt32(rd.GetValue(2));
                        obj.EmployeeContactNumber = Convert.ToString(rd.GetValue(3));
                        dept.Add(obj);
                    }
                    return dept;                
            }
           
        }


    }
}
