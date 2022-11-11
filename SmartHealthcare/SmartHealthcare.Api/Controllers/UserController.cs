using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHealthcare.Domain;
using SmartHealthcare.Service.UserInfo;
using SmartHealthcare.Service.ViewModel;

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
        public IActionResult GetUserLists()
        {
            //捕获异常
            try
            {
                //从服务曾中用户信息
                List<Tb_sys_UserInfo> user = _user.GetUserLists();
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
                throw new Exception("获取用户信息异常", ex);
            }
        }

        /// <summary>
        /// 新增用户信息
        /// </summary>
        /// <param name="user">用户视图模型</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        [HttpPost]
        public IActionResult CreateUserInfo(Tb_sys_UserInfoViewModel user)
        {
            //捕获异常
            try
            {
                //进行新增
                int i = _user.CreateUserInfo(user);
                if (i >= 1)
                {
                    //返回数据
                    return Ok(new
                    {
                        code = 200,
                        msg = "新增成功",
                        data = i
                    });
                }
                else
                {
                    //返回数据
                    return Ok(new
                    {
                        code = 500,
                        msg = "新增失败",
                        data = i
                    });
                }

            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("新增用户异常", ex);
            }
        }

        /// <summary>
        /// 删除该用户信息
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        [HttpDelete]
        public IActionResult DeleteUser(int userid = 0)
        {
            //捕获异常
            try
            {
                //删除用户信息
                int i = _user.DeleteUser(userid);
                //判断是否删除成功
                if (i >= 1)
                {
                    return Ok(new
                    {
                        code = 200,
                        msg = "删除成功",
                        data = i
                    });
                }
                else
                {
                    return Ok(new
                    {
                        code = 500,
                        msg = "删除失败",
                        data = i
                    });
                }
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("删除用户信息异常", ex);
            }
        }
    }
}
