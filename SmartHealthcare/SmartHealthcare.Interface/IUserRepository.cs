using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SmartHealthcare.Domain;

namespace SmartHealthcare.Interface
{
    /// <summary>
    /// 用户仓储接口
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        List<Tb_sys_UserInfo> GetUserLists();
    }
}
