using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IConfiguration configuration):base(configuration)
        {

        }

        public async Task<Employee> GetEmployeeByCode(string employeeCode)
        {
            var sqlCommand = $"SELECT * FROM Employee WHERE EmployeeCode = '{employeeCode}'";
            var employeeDuplicate = await _dbConnection.QueryFirstOrDefaultAsync<Employee>(sqlCommand);
            return employeeDuplicate;
        }

        public async Task<object> GetEmployeesFilter(string specs, int pageSize, int pageIndex)
        {
            var totalRecord = 0;
            var totalPage = 0;
            var input = specs != null ? specs : string.Empty;
            var parameters = new DynamicParameters();
            parameters.Add("@EmployeeFilter", input, DbType.String);
            //parameters.Add("@FullName", input, DbType.String);
            //parameters.Add("@PhoneNumber", input, DbType.String);
     
            parameters.Add("@PageIndex", pageIndex);
            parameters.Add("@PageSize", pageSize);
            parameters.Add("@TotalRecord", DbType.Int32, direction:ParameterDirection.Output);
            parameters.Add("@TotalPage", DbType.Int32, direction: ParameterDirection.Output);
            
            var employees = await _dbConnection.QueryAsync<Employee>("Proc_GetEmployeesFilterPaging", parameters, commandType:CommandType.StoredProcedure);
            totalRecord = parameters.Get<int>("@TotalRecord");
            totalPage = parameters.Get<int>("@TotalPage");
            var obj = new
            {
                Data = employees,
                TotalRecord = totalRecord,
                TotalPage = totalPage
            };
            return obj;
        }

        public async Task<string> GetNewEmployeeCode()
        {
            var newEmployeeCode = await _dbConnection.QueryFirstOrDefaultAsync<string>("Proc_GetNewEmployeeCode", commandType: CommandType.StoredProcedure);
            return newEmployeeCode;
        }
    }
}
