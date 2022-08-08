using System.ComponentModel.DataAnnotations;

namespace POC.EF.SqlServer.API.DTOs.Company
{
    public class CompanyRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int Number { get; set; }
        public string? Complement { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public int ZipCode { get; set; }
        public string? Phone { get; set; }
    }
}
