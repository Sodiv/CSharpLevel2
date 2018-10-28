using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Server.Models;

namespace Server.Controllers
{
    public class EmployeeController : ApiController
    {
        DataEmployee data = new DataEmployee();

        [Route("getemployee")]
        public List<Employee> GetEmployee()
        {
            return data.GetEmployees();
        }
        
        [Route("addemployee")]
        public void Post([FromBody]Employee value)
        {
            data.AddEmployee(value);
        }

        [Route("editemployee/{id}")]
        public HttpResponseMessage Post([FromBody]Employee value, int id)
        {
            if (data.EditEmployee(value, id))
                return Request.CreateResponse(HttpStatusCode.Created);
            else return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpGet]
        [Route("deleteemployee/{id}")]
        public void DeleteEmployee(int id)
        {
            data.DeleteEmployee(id);
        }

        [Route("getdepartment")]
        public List<Department> GetDepartment()
        {
            return data.GetDepartments();
        }

        [Route("adddepartment")]
        public void Post([FromBody]Department value)
        {
            data.AddDepartment(value);
        }

        [Route("editdepartment/{id}")]
        public HttpResponseMessage Post([FromBody]Department value, int id)
        {
            if (data.EditDepartment(value, id))
                return Request.CreateResponse(HttpStatusCode.Created);
            else return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpGet]
        [Route("deletedepartment/{id}")]
        public void DeleteDepartment(int id)
        {
            data.DeleteDepartment(id);
        }
    }
}
