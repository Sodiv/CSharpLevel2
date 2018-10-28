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
        public HttpResponseMessage Post([FromBody]Employee value)
        {
            if (data.AddEmployee(value))
                return Request.CreateResponse(HttpStatusCode.Created);
            else return Request.CreateResponse(HttpStatusCode.BadRequest);
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
    }
}
