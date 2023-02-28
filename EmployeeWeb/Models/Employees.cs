using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Numerics;

namespace EmployeeWeb.Models
{
    public class Employees
    {
        [Key]
        public int Id { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmailAddress { get; set; }
        public string? Phone { get; set; }
        public string? Status { get; set; }
        public string? Response { get; set; }
    }
}
