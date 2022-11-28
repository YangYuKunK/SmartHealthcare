using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MrHuo.OAuth.Wechat;
using Org.BouncyCastle.Ocsp;
using SmartHealthcare.Api.log4net;
using SmartHealthcare.Domain;
using SmartHealthcare.Service.Doctor;
using SmartHealthcare.Service.Upoad;
using SmartHealthcare.Service.UserInfo;
using SmartHealthcare.Service.ViewModel;

using System;
using System.Threading.Tasks;
using TencentCloud.Common;
using TencentCloud.Common.Profile;
using TencentCloud.Sms.V20210111;
using TencentCloud.Sms.V20210111.Models;
using TencentCloud.Tcss.V20201101.Models;

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
        IUpoadService _upoad;
        IDoctorService _doctor;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="user">用户服务接口</param>
        /// <param name="upoad">文件上传服务接口</param>
        /// <param name="doctor">医生服务接口</param>
        public UserController(IUserService user, IUpoadService upoad, IDoctorService doctor)
        {
            _user = user;
            _upoad = upoad;
            _doctor = doctor;
        }

        #region 获取用户信息

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        //[Authorize]
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
        /// <summary>
        /// /// 条件查询用户信息(未加入回收站)
        /// </summary>
        /// <param name="userphone">用户手机号</param>
        /// <param name="username">用户姓名</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        [HttpGet]
        public IActionResult GetUserListPhoneAndName(string? userphone, string? username)
        {
            //捕获异常
            try
            {
                //获取用户信息
                List<Tb_sys_UserInfo> user = _user.GetUserListPhoneAndName(userphone, username);
                //返回数据
                return Ok(new
                {
                    code = 200,
                    msg = "查询成功",
                    data = user
                });
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("查询条件异常", ex);
            }
        }
        /// <summary>
        /// /// 条件查询用户信息(已加入回收站)
        /// </summary>
        /// <param name="userphone">用户手机号</param>
        /// <param name="username">用户姓名</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        [HttpGet]
        public IActionResult GetDeleteUserListPhoneAndName(string? userphone, string? username)
        {
            //捕获异常
            try
            {
                //获取用户信息
                List<Tb_sys_UserInfo> user = _user.GetDeleteUserListPhoneAndName(userphone, username);
                //返回数据
                return Ok(new
                {
                    code = 200,
                    msg = "查询成功",
                    data = user
                });
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("查询条件异常", ex);
            }
        }

        /// <summary>
        /// 获取回收站用户
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        [HttpGet]
        public IActionResult GetDeleteUserList()
        {
            //捕获异常
            try
            {
                //获取回收站用户
                List<Tb_sys_UserInfo> user = _user.GetDeleteUserList(0);
                //返回数据
                return Ok(new
                {
                    code = 200,
                    msg = "查询成功",
                    data = user
                });
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("获取回收站用户异常", ex);
            }
        }

        #endregion

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

        /// <summary>
        /// 医生注册
        /// </summary>
        /// <param name="doctor">医生视图模型</param>
        /// <param name="capt">验证码</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        [HttpPost]
        public IActionResult CreateDoctorInfo(Tb_sys_DoctorInfoViewModel doctor)
        {
            //捕获异常
            try
            {
                //医生注册
                int i = _doctor.CreateDoctorInfo(doctor);
                //判断医生是否注册成功
                if (i > 0)
                {
                    //返回数据
                    return Ok(new
                    {
                        code = 200,
                        msg = "医生注册成功",
                        data = i
                    });
                }
                else
                {
                    //返回数据
                    return Ok(new
                    {
                        code = 400,
                        msg = "医生注册失败",
                        data = i
                    });
                }

            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("医生注册异常", ex);
            }
        }

        #endregion

        #region 文件流

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="file">图片路径</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpLoad(IFormFile file)
        {
            //捕获异常
            try
            {
                //获取文件名并赋值
                string? fname = _upoad.UpLoads(file);
                //返回数据
                return Ok(new
                {
                    newFileName = "http://rlh19p0mg.hn-bkt.clouddn.com/" + fname
                });
            }
            catch (Exception)
            {
                //抛出异常
                throw new Exception("文件上传异常");
            }
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除该用户信息(真删)
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

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        [HttpPut]
        public IActionResult UpdateDeleteUser(int userid = 0)
        {
            //捕获异常
            try
            {
                //删除用户
                int i = _user.DeleteStateUser(userid);
                if (i >= 1)
                {
                    //返回数据
                    return Ok(new
                    {
                        code = 200,
                        msg = "删除成功",
                        data = i
                    });
                }
                else
                {
                    //返回数据
                    return Ok(new
                    {
                        code = 400,
                        msg = "删除失败",
                        data = i
                    });
                }
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("逻辑删除异常", ex);
            }
        }


        #endregion

        #region 登录

        /// <summary>
        /// 患者登录
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
                    Tb_sys_UserInfo user = _user.SelectUserInfo(admin, pass);
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

        /// <summary>
        /// 医生登录
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="capt"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet]
        public IActionResult SelectDoctorLogin(string phone, string capt)
        {
            //捕获异常
            try
            {
                //登录
                int i = _doctor.SelectDoctorLogin(phone);
                //判断验证码是否正确
                if (i > 0)
                {
                    //返回数据
                    return Ok(new
                    {
                        code = 200,
                        msg = "医生登录成功",
                        data = i
                    });
                }
                else
                {
                    //返回数据
                    return Ok(new
                    {
                        msg = "医生登录失败",
                        code = 400,
                        data = i
                    });
                }
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("抛出异常", ex);
            }
        }

        ///// <summary>
        ///// 第三方登录 QQ、微信
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //public IActionResult ThirdPartyLogin()
        //{
        //    var claims = HttpContext.User.Claims.ToList();
        //    return Ok(new
        //    {
        //        claims
        //    });
        //}

        [HttpGet]
        public IActionResult Index(string type,[FromServices] WechatOAuth wechatOAuth)
        {
            var redirectUrl = "";
            switch (type.ToLower())
            {
                case "wechat":
                    {
                        redirectUrl = wechatOAuth.GetAuthorizeUrl();
                        break;
                    }
                default:
                    return Ok($"没有实现【{type}】登录方式！");
            }
            return Redirect(redirectUrl);
        }

        [HttpGet]
        public async Task<IActionResult> LoginCallback(string type,[FromServices] WechatOAuth wechatOAuth,[FromQuery] string code,[FromQuery] string state)
        {
            try
            {
                switch (type.ToLower())
                {
                    case "wechat":
                        {
                            var authorizeResult = await wechatOAuth.AuthorizeCallback(code, state);
                            if (!authorizeResult.IsSccess)
                            {
                                throw new Exception(authorizeResult.ErrorMessage);
                            }
                            return Ok(authorizeResult);
                        }
                    default:
                        throw new Exception($"没有实现【{type}】登录回调！");
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        #endregion

        #region 验证用户输入验证码是否正确
        /// <summary>
        /// 验证码是否正确
        /// </summary>
        /// <param name="capt"></param>
        /// <returns></returns>
        [HttpGet]
        public int VerifyCaptcha(string capt)
        {
            int i = 0;
            //验证通过赋值为1

            //失败正常返回
            return 1;
        }
        #endregion

        #region 短信验证
        /// <summary>
        /// 注册短信
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        [HttpPost]
        public IActionResult SMS(string? phone, int state)
        {
            //捕获异常
            try
            {
                // 实例化一个认证对象，入参需要传入腾讯云账户secretId，secretKey,此处还需注意密钥对的保密
                Credential cred = new Credential
                {
                    SecretId = "AKIDTjkV4NPAeqlLjriKgkX3JHyPZS4PTHo4",
                    SecretKey = "1lNtIboqc7LIzQcXBYfU2JJ2UfaEbgU1"
                };
                // 实例化一个client选项，可选的，没有特殊需求可以跳过
                ClientProfile clientProfile = new ClientProfile();
                // 实例化一个http选项，可选的，没有特殊需求可以跳过
                HttpProfile httpProfile = new HttpProfile();
                httpProfile.Endpoint = ("sms.tencentcloudapi.com");
                clientProfile.HttpProfile = httpProfile;

                // 实例化要请求产品的client对象,clientProfile是可选的
                SmsClient client = new SmsClient(cred, "ap-guangzhou", clientProfile);

                //生成验证码
                string capt = Captcha();
                // 实例化一个请求对象,每个接口都会对应一个request对象
                SendSmsRequest req = new();
                //判断验证码是否为空
                if (!string.IsNullOrEmpty(capt))
                {
                    req.PhoneNumberSet = new string[] { "+86" + phone }; //手机
                    req.SmsSdkAppId = "1400614525"; //短信控制台 在添加应用后 smsSdk默认的
                    if (state == 1)
                    {
                        req.TemplateId = "1252439"; //注册短信模板id
                        req.TemplateParamSet = new string[] { capt, "2" };
                    }
                    else if (state == 2)
                    {
                        req.TemplateId = "1252443"; //登录短信模板id
                        req.TemplateParamSet = new string[] { capt };
                    }
                    req.SignName = "竹帆";
                    // 返回的resp是一个SendSmsResponse的实例，与请求对象对应
                    SendSmsResponse resp = client.SendSmsSync(req);
                    return Ok(new
                    {
                        resp
                    });
                }
                else
                {
                    // 返回的resp是一个SendSmsResponse的实例，与请求对象对应
                    SendSmsResponse resp = client.SendSmsSync(req);
                    return Ok(new
                    {
                        resp
                    });
                }
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("短信异常", ex);
            }
        }
        #endregion

        #region 生成验证码
        /// <summary>
        /// 生成随机六位数
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Captcha()
        {
            Random rd = new Random();
            //随机生成六位数
            string capt = rd.Next(100000, 999999).ToString();
            //将生成后的验证码存入rides中并设置失效时间

            //将验证码返回至短信接口
            return capt;
        }
        #endregion

        #region 编辑

        /// <summary>
        /// 编辑用户信息
        /// </summary>
        /// <param name="user">用户视图模型</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        [HttpPut]
        public IActionResult UpdateUserInfo(Tb_sys_UserInfoViewModel user)
        {
            //捕获异常
            try
            {
                //编辑用户信息
                int i = _user.UpdateUserInfo(user);
                if (i >= 1)
                {
                    //返回数据
                    return Ok(new
                    {
                        code = 200,
                        msg = "编辑成功",
                        data = i
                    });
                }
                else
                {
                    //返回数据
                    return Ok(new
                    {
                        code = 400,
                        msg = "编辑失败",
                        data = i
                    });
                }
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("编辑用户信息异常", ex);
            }
        }

        #endregion
    }
}
