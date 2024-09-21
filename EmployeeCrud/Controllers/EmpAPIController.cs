using CrudOperationEmployee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace CrudOperationEmployee.Controllers
{
  
    public class EmpAPIController : System.Web.Http.ApiController
    {
        Employeehandle emph = new Employeehandle();
        List<EmployeeModel> li = new List<EmployeeModel>();

        [Route("api/EmpAPIController/GetEmp")]
        [HttpGet]
        public List<EmployeeModel> GetEmp()
        {
            li = emph.GetInfo();
            return li;
        
        }
    }
}
