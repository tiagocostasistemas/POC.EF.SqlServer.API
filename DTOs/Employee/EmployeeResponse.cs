namespace POC.EF.SqlServer.API.DTOs.Employee
{
    public class EmployeeResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; }
        public double Salary { get; set; }
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }
    }
}
