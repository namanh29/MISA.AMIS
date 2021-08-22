
using MISA.Core.Consts;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Infrastructure;
using MISA.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class EmployeeService: BaseService<Employee>, IEmployeeService
    {
               
        IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {          
            _employeeRepository = employeeRepository;
        }

        protected override bool ValidateCustom(Employee entity)
        {
            return true;
        }

        public async Task<object> GetEmployeesFilter(string specs, int pageSize, int pageIndex)
        {
            return await _employeeRepository.GetEmployeesFilter(specs, pageSize, pageIndex);
        }

        public async Task<string> GetNewEmployeeCode()
        {
            return await _employeeRepository.GetNewEmployeeCode();
        }
    }
}
