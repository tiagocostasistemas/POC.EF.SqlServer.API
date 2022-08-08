using POC.EF.SqlServer.API.DTOs.Employee;

namespace POC.EF.SqlServer.API.DTOs.Company
{
    public class CompanyResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Street { get; set; }
        public int Number { get; set; }
        public string? Complement { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int ZipCode { get; set; }
        public string? Phone { get; set; }
        public ICollection<EmployeeResponse> Employees { get; set; } = new List<EmployeeResponse>();
    }
}
