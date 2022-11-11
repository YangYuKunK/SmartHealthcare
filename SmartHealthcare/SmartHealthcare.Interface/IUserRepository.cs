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
        /// <param name="userid">用户id</param>
        /// <returns></returns>
        List<Tb_sys_UserInfo> GetUserLists(int userid);

        /// <summary>
        /// 新增用户信息
        /// </summary>
        /// <param name="user">用户数据模型</param>
        /// <returns></returns>
        int CreateUserInfo(Tb_sys_UserInfo user);

        /// <summary>
        /// 删除该用户信息
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <returns></returns>
        int DeleteUser(int userid);

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="admin">账号</param>
        /// <param name="pass">密码</param>
        /// <returns></returns>
        Tb_sys_UserInfo SelectUserInfo(string admin, string pass);
    }
}
