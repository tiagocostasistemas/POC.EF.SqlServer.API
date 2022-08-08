namespace POC.EF.SqlServer.API.Entities
{
    public class Employee : Entity
    {
        public string? Name { get; set; }
        public string? Position { get; set; }
        public double Salary { get; set; }
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}
