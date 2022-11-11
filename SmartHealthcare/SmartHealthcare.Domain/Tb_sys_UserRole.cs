using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthcare.Domain
{
    /// <summary>
    /// 用户角色数据模型
    /// </summary>
    public class Tb_sys_UserRole
    {
        private int userId; //用户id
        private int roleId; //角色id

        #region 用户id
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        #endregion
        #region 角色id
        /// <summary>
        /// 角色id
        /// </summary>
        public int RoleId
        {
            get { return roleId; }
            set { roleId = value; }
        }
        #endregion
    }
}
