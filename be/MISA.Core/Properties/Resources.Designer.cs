﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MISA.Core.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MISA.Core.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Thêm thành công.
        /// </summary>
        public static string Add_Success {
            get {
                return ResourceManager.GetString("Add_Success", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Xóa thành công.
        /// </summary>
        public static string Delete_Success {
            get {
                return ResourceManager.GetString("Delete_Success", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Có lỗi xảy ra, vui lòng liên hệ MISA.
        /// </summary>
        public static string ErrorException {
            get {
                return ResourceManager.GetString("ErrorException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Dữ liệu không hợp lệ.
        /// </summary>
        public static string Invalid {
            get {
                return ResourceManager.GetString("Invalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sửa thành công.
        /// </summary>
        public static string Update_Success {
            get {
                return ResourceManager.GetString("Update_Success", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} đã tồn tại trong hệ thống, vui lòng kiểm tra lại.
        /// </summary>
        public static string ValidateError_Dupliacate {
            get {
                return ResourceManager.GetString("ValidateError_Dupliacate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} không được phép để trống, vui lòng kiểm tra lại!.
        /// </summary>
        public static string ValidateError_Empty {
            get {
                return ResourceManager.GetString("ValidateError_Empty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} vượt quá {1} ký tự cho phép.
        /// </summary>
        public static string ValidateError_MaxLen {
            get {
                return ResourceManager.GetString("ValidateError_MaxLen", resourceCulture);
            }
        }
    }
}
