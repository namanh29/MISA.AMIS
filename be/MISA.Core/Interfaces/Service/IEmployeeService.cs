
using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Service
{
    public interface IEmployeeService: IBaseService<Employee>
    {
        /// <summary>
        /// Xử lý lọc, phân trang
        /// </summary>
        /// <param name="specs">tiêu chí tìm kiếm</param>
        /// <param name="pageSize">số bản ghi mỗi trang</param>
        /// <param name="pageIndex">số thứ tự trang</param>
        /// <returns></returns>
        Task<object> GetEmployeesFilter(string specs, int pageSize, int pageIndex);

        /// <summary>
        /// Xử lý sinh mới mã nhân viên
        /// </summary>
        /// <returns></returns>
        Task<string> GetNewEmployeeCode();
    }
}
