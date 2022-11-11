using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHealthcare.Api.log4net;
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
        /// <param name="userid">用户id</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        [HttpGet]
        public IActionResult GetUserLists(int userid = 0)
        {
            //捕获异常
            try
            {
                //从服务曾中用户信息
                List<Tb_sys_UserInfo> user = _user.GetUserLists(userid);
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

        #region 注册
        /// <summary>
        /// 新增用户信息(患者注册)
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


        #endregion

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
        #region 登录

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="admin">账号</param>
        /// <param name="pass">密码</param>
        /// <returns></returns>
        /// <exception cref="Exception">//捕获异常</exception>
        [HttpGet]
        public IActionResult SelectUserInfo(string admin = "", string pass = "")
        {
            //捕获异常
            try
            {
                //判断账号或密码是否为空
                if (!string.IsNullOrEmpty(admin) || !string.IsNullOrEmpty(pass))
                {
                    Tb_sys_UserInfo user = _user.SelectUserInfo(admin,pass);
                    if (user.UserId != 0)
                    {
                        //记录日志
                        Log4net.Log4netHelper.Error("登陆成功");
                        //返回数据
                        return Ok(new
                        {
                            code = 200,
                            token = "",
                            msg = "登录成功",
                            data = user
                        });
                    }
                    else
                    {
                        //返回数据
                        return Ok(new
                        {
                            code = 500,
                            msg = "登录失败"
                        });
                    }
                }
                else
                {
                    //记录日志
                    Log4net.Log4netHelper.Error("用户名或密码为空");
                    //返回数据
                    return Ok(new
                    {
                        code = 400,
                        msg = "用户名或密码为空"
                    });
                }
            }
            catch (Exception ex)
            {
                //记录日志
                Log4net.Log4netHelper.Error("用户登录失败");
                //抛出异常
                throw new Exception("用户登录异常", ex);
            }
        }

        #endregion

        
    }
}
