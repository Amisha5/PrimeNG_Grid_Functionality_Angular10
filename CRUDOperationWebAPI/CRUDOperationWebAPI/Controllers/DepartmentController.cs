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
    public class DepartmentController : ControllerBase
    {
        IConfiguration _configuration;
        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            MySqlDataReader rd = null;
            List<Department> dept = new List<Department>();
            using (MySqlConnection conn = new MySqlConnection(this._configuration.GetConnectionString("DefaultConnection")))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from Departments", conn);
                    rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        Department obj = new Department();
                        obj.DepartmentId = Convert.ToInt32(rd.GetValue(0));
                        obj.DepartmentName = Convert.ToString(rd.GetValue(1));
                        dept.Add(obj);
                    }
                return dept;
            }
            
        }
        [HttpPost]
        public ActionResult Post(Department emp)
        {
            using (MySqlConnection con = new MySqlConnection(this._configuration.GetConnectionString("DefaultConnection")))
            {
                MySqlCommand cmd = new MySqlCommand("Insert into Departments(DepartmentId,DepartmentName) values(@DepartmentId,@DepartmentName);", con);
                cmd.Parameters.AddWithValue("@DepartmentId", emp.DepartmentId);
                cmd.Parameters.AddWithValue("@DepartmentName", emp.DepartmentName);
               
                con.Open();
                cmd.ExecuteNonQuery();

            }
            return new JsonResult("Added Successfully!");
        }

        [HttpPut]
        public ActionResult Put(Department emp)
        {
            using (MySqlConnection con = new MySqlConnection(this._configuration.GetConnectionString("DefaultConnection")))
            {
                MySqlCommand cmd = new MySqlCommand("update Departments set DepartmentName=@DepartmentName where DepartmentId=@DepartmentId", con);
                cmd.Parameters.AddWithValue("@DepartmentId", emp.DepartmentId);
                cmd.Parameters.AddWithValue("@DepartmentName", emp.DepartmentName);
               

                con.Open();
                cmd.ExecuteNonQuery();

            }
            return new JsonResult("Updated Successfully!");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            using (MySqlConnection con = new MySqlConnection(this._configuration.GetConnectionString("DefaultConnection")))
            {
                MySqlCommand cmd = new MySqlCommand("Delete from Departments where DepartmentId=@DepartmentId", con);
                cmd.Parameters.AddWithValue("@DepartmentId", id);

                con.Open();
                cmd.ExecuteNonQuery();

            }
            return new JsonResult("Deleted Successfully!");
        }
    }
}
