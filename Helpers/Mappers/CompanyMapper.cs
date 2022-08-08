using POC.EF.SqlServer.API.DTOs.Company;
using POC.EF.SqlServer.API.Entities;

namespace POC.EF.SqlServer.API.Helpers.Mappers
{
    public static class CompanyMapper
    {
        public static List<CompanyResponse> Map(List<Company> companies)
        {
            var companiesResponse = GetCompaniesResponse(companies);
            return companiesResponse;
        }

        public static CompanyResponse Map(Company company)
        {
            var companyDTO = ConvertCompanyToCompanyResponse(company);
            return companyDTO;
        }

        private static List<CompanyResponse> GetCompaniesResponse(List<Company> companies)
        {
            var companiesDTO = new List<CompanyResponse>();

            companies.ForEach(currentCompany => {
                var companye = ConvertCompanyToCompanyResponse(currentCompany);
                companiesDTO.Add(companye);
            });

            return companiesDTO;
        }

        private static CompanyResponse ConvertCompanyToCompanyResponse(Company company)
        {
            return new CompanyResponse()
            {
                Id = company.Id,
                Name = company.Name,
                Street = company.Street,
                Number = company.Number,
                Complement = company.Complement,
                District = company.District,
                City = company.City,
                State = company.State,
                Phone = company.Phone,
                Employees = EmployeeMapper.Map(company.Employees)
            };
        }
    }
}
