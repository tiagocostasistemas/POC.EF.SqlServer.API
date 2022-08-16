using AutoMapper;
using POC.EF.SqlServer.API.DTOs.Company;
using POC.EF.SqlServer.API.Entities;
using POC.EF.SqlServer.API.Repositories.Interfaces;
using POC.EF.SqlServer.API.Services.Interfaces;

namespace POC.EF.SqlServer.API.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompanyResponse>> GetAll()
        {
            var companies = await _repository.GetAll();
            return _mapper.Map<IEnumerable<CompanyResponse>>(companies);
        }

        public async Task<CompanyResponse> GetById(int id)
        {
            var company = await _repository.GetById(id);
            return _mapper.Map<CompanyResponse>(company);
        }

        public async Task<CompanyResponse> Insert(CompanyRequest request)
        {
            var company = _mapper.Map<Company>(request);
            company = await _repository.Insert(company);
            return _mapper.Map<CompanyResponse>(company);

        }

        public async Task<CompanyResponse> Update(CompanyRequest request)
        {
            var company = _mapper.Map<Company>(request);
            company = await _repository.Update(company);
            return _mapper.Map<CompanyResponse>(company);
        }

        public async Task<CompanyResponse> Delete(int id)
        {
            var company = await _repository.GetById(id);
            company = await _repository.Delete(company);
            return _mapper.Map<CompanyResponse>(company);
        }
    }
}
