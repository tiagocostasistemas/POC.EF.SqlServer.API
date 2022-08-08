namespace POC.EF.SqlServer.API.Entities
{
    public class Company : Entity
    {
        public string? Name { get; set; }
        public string? Street { get; set; }
        public int Number { get; set; }
        public string? Complement { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int ZipCode { get; set; }
        public string? Phone { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
