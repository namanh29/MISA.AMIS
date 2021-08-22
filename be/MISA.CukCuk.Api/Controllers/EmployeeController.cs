using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    public class EmployeeController : EntityController<Employee>
    {
        IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService):base(employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Filter, phân trang 
        /// </summary>
        /// <param name="specs">tiêu chí tìm kiếm</param>
        /// <param name="pageSize">số bản ghi mỗi trang</param>
        /// <param name="pageIndex">số thứ tự trang</param>
        /// <returns></returns>
        [HttpGet("filter")]
        public async Task<IActionResult> GetEmployeeFilter([FromQuery] string specs, [FromQuery]int pageSize, [FromQuery]int pageIndex)
        {
            var result = await _employeeService.GetEmployeesFilter(specs, pageSize, pageIndex);
            return Ok(result);
        }
        [HttpGet("newcode")]
        public async Task<IActionResult> GetNewEmployeeCode()
        {
            var newEmployeeCode = await _employeeService.GetNewEmployeeCode();
            return Ok(newEmployeeCode);
        }
    }
}
