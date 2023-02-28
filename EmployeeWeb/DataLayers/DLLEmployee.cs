using Dapper;
using EmployeeWeb.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EmployeeWeb.DataLayers
{
    public class DLLEmployee
    {

        private  IConfiguration _config=null;
        public DLLEmployee(IConfiguration config) {
           _config=config;
        }
        public string saveEmployee(Employees employees)
        {
            using var conn = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            {
                var result = "";
                try
                {
                   
                    conn.Open();
                    var emp = conn.Query<Employees>("InsertEmployee",
                    new
                    {
                        EmployeeName = employees.EmployeeName,
                        EmailAddress = employees.EmailAddress,
                        Phone = employees.Phone,
                        Status = 'A'

                    },
                        commandType: CommandType.StoredProcedure).ToList();
                    if (emp != null && emp.FirstOrDefault().Response == "save successfully")
                    {
                        result = "save successfully";
                    }
                    conn.Close();
                    
                }
                catch (Exception e)
                {

                    result = e.Message;
                }
                return result;
            }
        }

        public string EditEmployee(Employees employees)
        {
            using var conn = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            {
                var result = "";
                try
                {
                    conn.Open();
                    var emp = conn.Query<Employees>("UpdateEmployee",
                        new
                        {
                            EmployeeName = employees.EmployeeName,
                            EmailAddress = employees.EmailAddress,
                            Phone = employees.Phone,
                            Status = 'E',
                            Id = employees.Id

                        },
                        commandType: CommandType.StoredProcedure).ToList();
                    if (emp != null && emp.FirstOrDefault().Response == "Updated Successfully")
                    {
                        result = "Updated Successfully";
                    }
                    conn.Close();
                   

                }catch(Exception e)
                {
                    result = e.Message;
                }
                return result;

            }


 

        }

        public string DeleteEmp(int Id)
        {
            using var conn = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            {
                var result = "";
                try
                {
                    conn.Open();
                    var std = conn.Query<Employees>("DeleteEmployee",
                            new
                            {
                                Id = Id
                            },
                        commandType: CommandType.StoredProcedure);
                    if (std != null && std.FirstOrDefault().Response == "Delete Succesfully")
                    {
                        result = "Delete Sucessfully";
                    }
                    conn.Close();
                   
                }
                catch (Exception e)
                {
                    result = e.Message;

                }
                return result;
            }

            }
        public List<Employees> GetEmp()
        {
            using var conn = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            {
                conn.Open();
                List<Employees> emp = conn.Query<Employees>("GetEmployeeList", commandType: CommandType.StoredProcedure).ToList();
                return emp;///Ok(emp);
                conn.Close();
            }

        }



    }
}
