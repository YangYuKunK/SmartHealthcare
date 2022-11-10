using SmartHealthcare.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthcare.Service.UserInfo
{
    /// <summary>
    /// 用户服务实践
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// 依赖注入
        /// </summary>
        IUserRepository _user;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="user">用户仓储接口</param>
        public UserService(IUserRepository user)
        {
            _user = user;
        }
    }
}
