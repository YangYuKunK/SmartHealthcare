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

        /// <summary>
        /// 新增用户信息
        /// </summary>
        /// <param name="user">用户数据模型</param>
        /// <returns></returns>
        int CreateUserInfo(Tb_sys_UserInfo user);

        /// <summary>
        /// 删除该用户信息
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        int DeleteUser(int userid);
    }
}
