using POC.EF.SqlServer.API.DTOs.Employee;
using POC.EF.SqlServer.API.Entities;

namespace POC.EF.SqlServer.API.Helpers.Mappers
{
    public class EmployeeMapper
    {
        public static List<EmployeeResponse> Map(List<Employee> employees)
        {
            var employeesResponse = GetEmployeesResponse(employees);
            return employeesResponse;
        }

        public static EmployeeResponse Map(Employee employee)
        {
            var employeeResponse = ConvertEmployeeToEmployeeResponse(employee);
            return employeeResponse;
        }

        private static List<EmployeeResponse> GetEmployeesResponse(List<Employee> employees)
        {
            var employeesResponse = new List<EmployeeResponse>();

            employees.ForEach(currentEmployee => {
                var employee = ConvertEmployeeToEmployeeResponse(currentEmployee);
                employeesResponse.Add(employee);
            });

            return employeesResponse;
        }

        private static EmployeeResponse ConvertEmployeeToEmployeeResponse(Employee employee)
        {
            return new EmployeeResponse()
            {
                Id = employee.Id,
                Name = employee.Name,
                Position = employee.Position,
                Salary = employee.Salary,
                CompanyId = employee.CompanyId,
                CompanyName = employee.Company!.Name
            };
        }
    }
}
