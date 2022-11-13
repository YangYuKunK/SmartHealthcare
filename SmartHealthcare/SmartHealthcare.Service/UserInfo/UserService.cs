using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SmartHealthcare.Domain;
using SmartHealthcare.Interface;
using SmartHealthcare.Service.ViewModel;

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
        readonly IMapper _mapper;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="user">用户仓储接口</param>
        /// <param name="mapper">automapper</param>
        public UserService(IUserRepository user, IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <returns></returns>
        public List<Tb_sys_UserInfo> GetUserLists(int userid)
        {
            //获取用户信息
            List<Tb_sys_UserInfo> user = _user.GetUserLists(userid);
            //返回数据
            return user;
        }

        /// <summary>
        /// 新增用户信息
        /// </summary>
        /// <param name="user">用户试图模型</param>
        /// <returns></returns>
        public int CreateUserInfo(Tb_sys_UserInfoViewModel user)
        {
            //捕获异常
            try
            {
                int i = 0;
                if (user.UserSex == 0 || user.UserSex == 1)
                {
                    //当前时间
                    user.creationTime = DateTime.Now;
                    //创建人
                    user.creationPerson = user.UserName;
                    //其余时间为空
                    user.modificationTime = Convert.ToDateTime(null);
                    user.deletetime = Convert.ToDateTime(null);
                    //映射模型
                    Tb_sys_UserInfo users = _mapper.Map<Tb_sys_UserInfo>(user);
                    //新增用户信息
                    i = _user.CreateUserInfo(users);
                    //返回数据
                    return i;
                }
                else
                {
                    //返回数据
                    return i;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("新增用户信息异常", ex);
            }
        }

        /// <summary>
        /// 删除该用户信息(真删)
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        public int DeleteUser(int userid)
        {
            //判断用户id是否为0
            if (userid != 0)
            {
                //捕获异常
                try
                {
                    //删除该用户信息
                    int i = _user.DeleteUser(userid);
                    //返回数据
                    return i;
                }
                catch (Exception ex)
                {
                    //抛出异常
                    throw new Exception("删除该用户信息异常", ex);
                }
            }
            else
            {
                //返回数据
                return 0;
            }
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="admin">账号</param>
        /// <param name="pass">密码</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        public Tb_sys_UserInfo SelectUserInfo(string admin, string pass)
        {
            //捕获异常
            try
            {
                //获取token
                //登录
                Tb_sys_UserInfo user = _user.SelectUserInfo(admin, pass);
                //返回数据
                return user;
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("用户登录异常", ex);
            }
        }

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        public int DeleteStateUser(int userid)
        {
            //捕获异常
            try
            {
                //判断用户id是否为0
                if (userid != 0)
                {
                    //逻辑删除
                    //获取该条用户信息
                    List<Tb_sys_UserInfo> userlist = _user.GetUserLists(userid);
                    Tb_sys_UserInfo user = userlist[0];
                    //给予删除审计信息
                    user.Deletetime = DateTime.Now;
                    user.DeletePerson = user.UserName;
                    //编辑用户信息
                    int i = _user.UpdateDeleteUser(user);
                    return i;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("逻辑删除异常", ex);
            }
        }

        /// <summary>
        /// 条件查询用户信息
        /// </summary>
        /// <param name="userphone">用户手机号</param>
        /// <param name="username">用户姓名</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        public List<Tb_sys_UserInfo> GetUserListPhoneAndName(string? userphone, string? username)
        {
            //捕获异常
            try
            {
                List<Tb_sys_UserInfo> user = new();
                //判断用户手机号和姓名是否为空
                if (!string.IsNullOrEmpty(userphone) || !string.IsNullOrEmpty(username))
                {
                    //获取用户信息
                    user = _user.GetUserListPhoneAndName(userphone, username);
                    //返回数据
                    return user;
                }
                else
                {
                    //返回数据
                    return user;
                }
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("条件查询用户信息异常", ex);
            }
        }

        /// <summary>
        /// /// 编辑用户信息
        /// </summary>
        /// <param name="users">用户视图模型</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        public int UpdateUserInfo(Tb_sys_UserInfoViewModel users)
        {
            //捕获异常
            try
            {
                //映射模型
                Tb_sys_UserInfo user = _mapper.Map<Tb_sys_UserInfo>(users);
                //编辑用户信息
                int i = _user.UpdateDeleteUser(user);
                //返回数据
                return i;
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("编辑用户信息异常", ex);
            }
        }
    }
}
