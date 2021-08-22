using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Infrastructure
{
    public interface IBaseRepository<TEntity>
    {
        /// <summary>
        /// Lấy toàn bộ danh sách đối tượng từ database
        /// </summary>
        /// <returns>Danh sácch đối tượng</returns>
        Task<IEnumerable<TEntity>> GetAll();

        /// <summary>
        /// Lấy đối tượng theo Id từ database
        /// </summary>
        /// <param name="entityId">Id đối tượng</param>
        /// <returns>đối tượng </returns>
        Task<TEntity> GetById(Guid entityId);

        /// <summary>
        /// Thêm đối tượng vào database
        /// </summary>
        /// <param name="entity">đối tượng</param>
        /// <returns></returns>
        Task<int> Add(TEntity entity);

        /// <summary>
        /// Sửa đối tượng vào database
        /// </summary>
        /// <param name="entity">đối tượng</param>
        /// <returns></returns>
        Task<int> Update(TEntity entity);

        /// <summary>
        /// Xóa đối tượng
        /// </summary>
        /// <param name="entityId">Id đối tượng</param>
        /// <returns></returns>
        Task<int> Delete(Guid entityId);

        /// <summary>
        /// Lấy danh sách theo tiêu chí từ database
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        Task<TEntity> GetByProperty(TEntity entity, PropertyInfo property);
    }
}
