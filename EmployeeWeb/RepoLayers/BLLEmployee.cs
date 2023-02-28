using EmployeeWeb.DataLayers;
using EmployeeWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWeb.RepoLayers
{
    public class BLLEmployee
    {
        public string saveEmployee(Employees employees,IConfiguration config)
        {
            DLLEmployee dll = new DLLEmployee(config);
           string result= dll.saveEmployee(employees);    
            return result;
        }

        public string EditEmployee(Employees employees, IConfiguration config)
        {
            DLLEmployee dll = new DLLEmployee(config);
            string result = dll.EditEmployee(employees);
            return result;
        }





      public string DeleteEmp(int Id, IConfiguration config)
        {
            DLLEmployee dll = new DLLEmployee(config);
            string result = dll.DeleteEmp(Id);
            return result;
        }

          public List<Employees> GetEmp(IConfiguration config)
        {
            DLLEmployee dll = new DLLEmployee(config);
            return dll.GetEmp();
            // return result;

        }
    }


    
}
