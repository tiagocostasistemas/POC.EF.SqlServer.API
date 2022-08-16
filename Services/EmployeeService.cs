using AutoMapper;
using POC.EF.SqlServer.API.DTOs.Employee;
using POC.EF.SqlServer.API.Entities;
using POC.EF.SqlServer.API.Repositories.Interfaces;
using POC.EF.SqlServer.API.Services.Interfaces;

namespace POC.EF.SqlServer.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeResponse>> GetAll()
        {
            var employees = await _repository.GetAll();
            return _mapper.Map<IEnumerable<EmployeeResponse>>(employees);
        }

        public async Task<EmployeeResponse> GetById(int id)
        {
            var employee = await _repository.GetById(id);
            return _mapper.Map<EmployeeResponse>(employee);
        }

        public async Task<EmployeeResponse> Insert(EmployeeRequest request)
        {
            var employee = _mapper.Map<Employee>(request);
            employee = await _repository.Insert(employee);
            return _mapper.Map<EmployeeResponse>(employee);
        }

        public async Task<EmployeeResponse> Update(EmployeeRequest request)
        {
            var employee = _mapper.Map<Employee>(request);
            employee = await _repository.Update(employee);
            return _mapper.Map<EmployeeResponse>(employee); ;
        }

        public async Task<EmployeeResponse> Delete(int id)
        {
            var employee = await _repository.GetById(id);
            employee = await _repository.Delete(employee);
            return _mapper.Map<EmployeeResponse>(employee);
        }
    }
}
