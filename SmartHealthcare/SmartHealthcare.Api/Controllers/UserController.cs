using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHealthcare.Service.UserInfo;

namespace SmartHealthcare.Api.Controllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// 依赖注入
        /// </summary>
        IUserService _user;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="user">用户服务接口</param>
        public UserController(IUserService user)
        {
            _user = user;
        }
    }
}
