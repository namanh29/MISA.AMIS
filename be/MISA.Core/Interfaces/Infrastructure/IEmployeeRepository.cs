using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Infrastructure
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<Employee> GetEmployeeByCode(string employeeCode);
        /// <summary>
        /// Lấy dữ liệu theo các tiêu chí
        /// </summary>
        /// <param name="specs">Theo mã, tên hoặc số điện thoại nhân viên</param>
        /// <returns>Danh sách nhân viên theo tiêu chí</returns>
        /// CreatedBy: PNANH (3/8/2021)
        Task<Object> GetEmployeesFilter(string specs, int pageSize, int pageIndex);

        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <returns>mã nhân viên mới</returns>
        Task<string> GetNewEmployeeCode();
    }
}
