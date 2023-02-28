using Dapper;
using EmployeeWeb.Models;
using EmployeeWeb.RepoLayers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Numerics;

namespace EmployeeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IConfiguration _config;
        public EmployeeController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        [Route("GetEmployee")]
        public async Task<ActionResult<List<Employees>>> GetEmployee()
        {
            BLLEmployee bll = new BLLEmployee();
            return bll.GetEmp( _config);


        }
        [HttpPost]
        [Route("SetEmployee")]

        public async Task<ActionResult<string>> SetEmployee(Employees employees)
        {
           BLLEmployee bll= new BLLEmployee();
           return   bll.saveEmployee(employees,_config);
            

        }
        [HttpPut]
        [Route("UpdateEmployees")]
        public async Task<ActionResult<string>> UpdateEmployees([FromBody] Employees employees)
        {
           BLLEmployee bll =   new BLLEmployee();
           return   bll.EditEmployee(employees,_config);

           

        }

        //New
        [HttpDelete]
        [Route("DeleteEmployees")]
        public async Task<ActionResult<string>> DeleteEmployees(int Id)
        {
            BLLEmployee bll = new BLLEmployee();
            return bll.DeleteEmp(Id, _config);

        }

    }
}
