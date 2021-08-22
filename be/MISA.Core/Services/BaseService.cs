using MISA.Core.Consts;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Infrastructure;
using MISA.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity:BaseEntity
    {
        IBaseRepository<TEntity> _baseRepository;
        ServiceResult _serviceResult;
        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult();
        }
        public virtual async Task<ServiceResult> Add(TEntity entity)
        {
            entity.EntityState = Enums.EntityState.Add;
            // Validate
            var isValid = Validate(entity).Result;
            
            if (isValid == true)
            {
                _serviceResult.Success = true;
                _serviceResult.Data = await _baseRepository.Add(entity);
                _serviceResult.MISACode = MISAConst.MISACodeIsValid;
                return _serviceResult;
            }
            else
            {            
                return _serviceResult;
            }
        }

        public async Task<ServiceResult> Delete(Guid entityId)
        {
            _serviceResult.Data = await _baseRepository.Delete(entityId);
            return _serviceResult;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _baseRepository.GetAll();
        }

        public async Task<TEntity> GetById(Guid entityId)
        {
            return await _baseRepository.GetById(entityId);
        }

        public async Task<ServiceResult> Update(TEntity entity)
        {
            entity.EntityState = Enums.EntityState.Update;
            var isValid = Validate(entity).Result;
            if (isValid == true)
            {
                _serviceResult.Success = true;
                _serviceResult.Data = await _baseRepository.Update(entity);
                _serviceResult.MISACode = MISAConst.MISACodeIsValid;
                return _serviceResult;
            }
            else
            {
                return _serviceResult;
            }
        }

        /// <summary>
        /// Hàm validate dữ liệu
        /// </summary>
        /// <param name="entity">đối tượng được validate</param>
        /// <returns>true-hợp lệ, false-không hợp lệ</returns>
        private async Task<bool> Validate(TEntity entity)
        {
            var isValidate = true;
            //var messageError = new List<string>();
            // Đọc các property
            var properties = entity.GetType().GetProperties();
            foreach(var property in properties)
            {
                var propertyValue = property.GetValue(entity);
                var displayNameAttr = property.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                var displayName = string.Empty;
                if(displayNameAttr.Length > 0)
                {
                    displayName = (displayNameAttr[0] as DisplayNameAttribute).DisplayName;
                }
                // Kiểm tra xem có attribute cần phải validate không
                if (property.IsDefined(typeof(Required), false))
                {
                    // Check bắt buộc nhập                                                    
                    if(string.IsNullOrEmpty((string)propertyValue))
                    {
                        isValidate = false;
                        _serviceResult.Success = false;
                        _serviceResult.MISACode = MISAConst.MISACodeErrorEmpty;
                        _serviceResult.UserMsg = string.Format(Properties.Resources.ValidateError_Empty, $"{displayName}");
                        //messageError.Add(string.Format(Properties.Resources.ValidateError_Empty, $"{displayName}"));
                        return isValidate;
                    }
                }
                if(property.IsDefined(typeof(CheckDuplicate), false))
                {                  
                    // Check trùng dữ liệu                    
                    var entityDuplicate = await _baseRepository.GetByProperty(entity, property);
                    if(entityDuplicate != null)
                    {
                        isValidate = false;
                        _serviceResult.Success = false;
                        _serviceResult.MISACode = MISAConst.MISACodeErrorDuplicate;
                        _serviceResult.UserMsg = string.Format(Properties.Resources.ValidateError_Dupliacate, $"{displayName} <{propertyValue}>");
                        return isValidate;

                    }
                }
                if (property.IsDefined(typeof(MaxLength), false))
                {
                    var attrMaxLength = property.GetCustomAttributes(typeof(MaxLength), true)[0];                 
                    var maxLength = (attrMaxLength as MaxLength).Value;                  
                    if (propertyValue.ToString().Trim().Length > maxLength)
                    {
                        isValidate = false;
                        _serviceResult.Success = false;
                        _serviceResult.MISACode = MISAConst.MISACodeErrorDuplicate;
                        _serviceResult.UserMsg = string.Format(Properties.Resources.ValidateError_MaxLen, $"{displayName}", $"{maxLength}");
                        //messageError.Add(string.Format(Properties.Resources.ValidateError_MaxLen, $"{displayName}", $"{maxLength}"));
                        return isValidate;
                    }
                }
            }
            //_serviceResult.Data = messageError;
            if (isValidate == true)
            {
                isValidate = ValidateCustom(entity);
            }
            return isValidate;
        }

        /// <summary>
        /// Hàm thực hiện kiểm tra dữ liệu / nghiệp vụ tùy chỉnh 
        /// </summary>
        /// <param name="entity">đối tượng được validate</param>
        /// <returns></returns>
        protected virtual bool ValidateCustom(TEntity entity)
        {
            return true;
        } 
    }
}
