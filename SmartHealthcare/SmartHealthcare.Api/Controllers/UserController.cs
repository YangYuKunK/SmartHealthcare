using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHealthcare.Domain;
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

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        [HttpGet]
        public ActionResult GetUserLists()
        {
            //捕获异常
            try
            {
                //从服务曾中用户信息
                List<Tb_sys_UserInfo> user= _user.GetUserLists();
                return Ok(new
                {
                    code = 200,
                    msg = "成功",
                    data = user,
                });
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("获取用户信息异常",ex);
            }
        }
    }
}
