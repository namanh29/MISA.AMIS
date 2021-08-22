using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Service
{
    public interface IBaseService<TEntity>
    {
        /// <summary>
        /// Lấy toàn bộ danh sách
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAll();

        /// <summary>
        /// Lấy đối tượng theo Id
        /// </summary>
        /// <param name="entityId">Id đối tượng</param>
        /// <returns></returns>
        Task<TEntity> GetById(Guid entityId);

        /// <summary>
        /// Xử lý nghiệp vụ thêm đối tượng
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<ServiceResult> Add(TEntity entity);

        /// <summary>
        /// Xử lý nghiệp vụ sửa đối tượng
        /// </summary>
        /// <param name="entity">đối tượng cần sửa</param>
        /// <returns></returns>
        Task<ServiceResult> Update(TEntity entity);

        /// <summary>
        /// Xử lý xóa đối tượng
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        Task<ServiceResult> Delete(Guid entityId);
    }
}
