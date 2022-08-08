using System.ComponentModel.DataAnnotations;

namespace POC.EF.SqlServer.API.DTOs.Employee
{
    public class EmployeeRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public double Salary { get; set; }
        [Required]
        public int CompanyId { get; set; }

        public string? CompanyName { get; set; }
    }
}
