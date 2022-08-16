using AutoMapper;
using POC.EF.SqlServer.API.DTOs.Company;
using POC.EF.SqlServer.API.DTOs.Employee;
using POC.EF.SqlServer.API.Entities;

namespace POC.EF.SqlServer.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyResponse>();
            CreateMap<CompanyRequest, Company>();
            CreateMap<Employee, EmployeeResponse>();
            CreateMap<EmployeeRequest, Employee>();
        }
    }
}
