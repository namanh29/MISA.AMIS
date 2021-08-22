using Microsoft.AspNetCore.Mvc;
using MISA.Core.Consts;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EntityController<TEntity> : ControllerBase
    {
        ResponseError _responseError = new ResponseError();
        IBaseService<TEntity> _baseService;
        public EntityController(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }
        #region Methods
        /// <summary>
        /// Lấy toàn bộ danh sách
        /// </summary>
        /// <returns>Danh sách đối tượng</returns>
        /// CreatedBy: PNANH (25/7/2021)
        [HttpGet]
        public async Task <IActionResult> GetAll()
        {

            // Lay du lieu
            var entity = await _baseService.GetAll();
            //var employees = _dbConnection.Query<Employee>("Proc_GetEmployees", commandType: CommandType.StoredProcedure);

            if (entity.Count() > 0)
            {
                return Ok(entity); // StatusCode (200, "MISA")
            }
            else
            {
                return NoContent();
            }


        }

        /// <summary>
        /// Lấy đối tượng theo Id
        /// </summary>
        /// <param name="entityId">id của đối tượng</param>
        /// <returns>đối tượng</returns>
        /// CreatedBy: PNANH (25/7/2021)
        [HttpGet("{entityId}")]
        public async Task<IActionResult> Get(Guid entityId)
        {

            // Lay du lieu
            var entity = await _baseService.GetById(entityId);

            if (entity != null)
            {
                return Ok(entity); // StatusCode (200, "MISA")
            }
            else
            {
                return NoContent();
            }

        }

        /// <summary>
        /// Thêm mới đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng sẽ thêm mới</param>
        /// <returns>
        /// 200 - thành công
        /// 201 - thêm mới thành công
        /// 400 - dữ liệu đầu vào không hợp lệ
        /// 500 - exception
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TEntity entity)
        {

            var serviceResult = await _baseService.Add(entity);
            // Validate dữ liệu:                           
            if (serviceResult.Success == false)
            {
                return Ok(serviceResult);
            }

            var rowAffects = (int)serviceResult.Data;

            if (rowAffects > 0)
            {
                return Created(Core.Properties.Resources.Add_Success, entity);
            }
            else
            {
                return NoContent();
            }

        }


        /// <summary>
        /// Sửa thông tin đối tượng
        /// </summary>
        /// <param name="employee">Đối tượng employee cần sửa</param>
        /// <param name="employeeId">Mã nhân viên cần sửa</param>
        /// <returns>
        /// 
        /// </returns>
        [HttpPut("{entityId}")]
        public async Task<IActionResult> Put([FromBody] TEntity entity, [FromRoute] Guid entityId)
        {

            // Gan Id cho entity
            var keyProperty = entity.GetType().GetProperty($"{typeof(TEntity).Name}Id");
            keyProperty.SetValue(entity, entityId);

            var serviceResult = await _baseService.Update(entity);

            // Validate dữ liệu:
            if (serviceResult.Success == false)
            {
                return Ok(serviceResult);
            }

            // Lay du lieu
            int rowAffects = (int)serviceResult.Data;

            if (rowAffects > 0)
            {
                return Ok(serviceResult);
            }
            else
            {
                return NoContent();
            }

        }

        /// <summary>
        /// Xóa đối tượng
        /// </summary>
        /// <param name="entityId">Id đối tượng cần xóa</param>
        /// <returns></returns>
        [HttpDelete("{entityId}")]
        public async Task<IActionResult> Delete(Guid entityId)
        {

            var serviceResult = await _baseService.Delete(entityId);
            int rowAffects = (int)serviceResult.Data;

            if ((int)rowAffects > 0)
            {
                return Ok(Core.Properties.Resources.Delete_Success); // StatusCode (200, "MISA")
            }
            else
            {
                return NoContent();
            }

        }

        #endregion
    }
}
