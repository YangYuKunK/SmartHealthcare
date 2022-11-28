using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHealthcare.Domain;
using SmartHealthcare.Interface;

namespace SmartHealthcare.Infrastructure
{
    /// <summary>
    /// 用户仓储实践
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <returns></returns>
        public List<Tb_sys_UserInfo> GetUserLists(int userid)
        {
            string str = "select userid,username,useradmin,userpass	,userage,usersex,useridcard,userphone,userdeletestate,usernumber,useravatar,userhobby,userbalance,useraddress,creationtime,modificationtime,deletetime,creationperson,modificationperson,deleteperson from tb_sys_userinfo where userdeletestate = @deletestate";
            //判断用户id是否为0
            if (userid > 0)
            {
                str += " and userid = @id";
                return Dapper<Tb_sys_UserInfo>.Query(str, new
                {
                    id = userid, //用户id
                    deletestate = 0 //删除状态
                });
            }
            else
            {
                return Dapper<Tb_sys_UserInfo>.Query(str, new
                {
                    deletestate = 0 //删除状态
                });
            }
        }

        /// <summary>
        /// 新增用户信息
        /// </summary>
        /// <param name="user">用户数据模型</param>
        /// <returns></returns>
        public int CreateUserInfo(Tb_sys_UserInfo user)
        {
            string str = "insert into tb_sys_userinfo  (userid,username,useradmin,userpass,userage,usersex,useridcard,userphone,userdeletestate,usernumber,useravatar,userhobby,userbalance,useraddress,creationtime,modificationtime,deletetime,creationperson,modificationperson,deleteperson) values (null,@username,@admin,@pass,@age,@sex,@idcard,@phone,@state,@number,@img,@hobby,@money,@dress,@createdate,@updatetime,@deletetime,@createname,@updatename,@deletename)";
            return Dapper<int>.RUD(str, new
            {
                username = user.UserName, //用户姓名
                admin = user.UserAdmin, //用户登录账号
                pass = user.UserPass, //用户登录密码
                age = user.UserAge, //用户年龄
                sex = user.UserSex, //用户性别
                idcard = user.UserIDCard, //用户身份证号
                phone = user.UserPhone, //用户手机号
                state = user.UserDeleteState, //逻辑删除
                number = user.UserNumber, //用户编号
                img = user.UserAvatar, //用户头像
                hobby = user.UserHobby, //用户爱好
                money = user.UserBalance, //用户余额
                dress = user.UserAddress, //用户地址
                createdate = DateTime.Now, //创建时间
                updatetime = user.ModificationTime, //修改时间
                deletetime = user.Deletetime, //删除时间
                createname = user.UserName, //创建人
                updatename = "", //修改人
                deletename = "" //删除人
            });
        }

        /// <summary>
        /// 删除该用户信息
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <returns></returns>
        public int DeleteUser(int userid)
        {
            string str = "delete from tb_sys_userinfo where userid = @id";
            return Dapper<int>.RUD(str, new
            {
                id = userid //用户id
            });
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="admin">账号</param>
        /// <param name="pass">密码</param>
        /// <returns></returns>
        public Tb_sys_UserInfo SelectUserInfo(string admin, string pass)
        {
            string str = "select userid,username,useradmin,userpass,userage,usersex,useridcard,userphone,userdeletestate,usernumber,useravatar,userhobby,userbalance,useraddress,creationtime,modificationtime,deletetime,creationperson,modificationperson,deleteperson from tb_sys_userinfo where useradmin = @useradmin and userpass = @userpass";
            return Dapper<Tb_sys_UserInfo>.QueryFirst(str, new
            {
                useradmin = admin,
                userpass = pass
            });

        }

        /// <summary>
        /// 编辑用户信息
        /// </summary>
        /// <param name="user">用户数据模型</param>
        /// <returns></returns>
        public int UpdateUser(Tb_sys_UserInfo user)
        {
            string str = "update tb_sys_userinfo set username = @name,useradmin = @admin,userpass = @pass,userage = @age,usersex = @sex,useridcard = @idcard,userphone = @phone,userdeletestate = @deletestate,usernumber = @number,useravatar = @avatar,userhobby = @hobby,userbalance = @balance,useraddress = @dress,creationtime = @addtime,modificationtime = @upttime,deletetime = @deltime,creationperson = @addren,modificationperson = @uptren,deleteperson = @delren where userid = @uid";
            return Dapper<int>.RUD(str, new
            {
                uid = user.UserId, //用户id
                name = user.UserName, //用户姓名
                admin = user.UserAdmin, //用户登录账号
                pass = user.UserPass, //用户登录密码
                age = user.UserAge, //用户年龄
                sex = user.UserSex, //用户性别
                idcard = user.UserIDCard, //用户身份证号
                phone = user.UserPhone, //用户手机号
                deletestate = user.UserDeleteState, //逻辑删除
                number = user.UserNumber, //用户编号
                avatar = user.UserAvatar, //用户头像
                hobby = user.UserHobby, //用户爱好
                balance = user.UserBalance, //用户余额
                dress = user.UserAddress, //用户地址
                addtime = user.CreationTime, //创建时间
                upttime = user.ModificationTime, //修改时间
                deltime = user.Deletetime, //删除时间
                addren = user.CreationPerson, //创建人
                uptren = user.ModificationPerson, //修改人
                delren = user.DeletePerson //删除人
            });
        }

        /// <summary>
        /// 条件查询用户信息(未加入回收站)
        /// </summary>
        /// <param name="userphone">用户手机号</param>
        /// <param name="username">用户姓名</param>
        /// <returns></returns>
        public List<Tb_sys_UserInfo> GetUserListPhoneAndName(string? userphone, string? username)
        {
            string str = "select userid,username,useradmin,userpass,userage,usersex,useridcard,userphone,userdeletestate,usernumber,useravatar,userhobby,userbalance,useraddress,creationtime,modificationtime,deletetime,creationperson,modificationperson,deleteperson from tb_sys_userinfo where userphone = @phone or username = @name and userdeletestate = @deletestate";
            return Dapper<Tb_sys_UserInfo>.Query(str, new
            {
                phone = userphone, //用户手机号
                name = username, //用户姓名
                deletestate = 0 //删除状态
            });
        }

        /// <summary>
        /// 条件查询用户信息(已加入回收站)
        /// </summary>
        /// <param name="userphone">用户手机号</param>
        /// <param name="username">用户姓名</param>
        /// <returns></returns>
        public List<Tb_sys_UserInfo> GetDeleteUserListPhoneAndName(string? userphone, string? username)
        {
            string str = "select userid,username,useradmin,userpass,userage,usersex,useridcard,userphone,userdeletestate,usernumber,useravatar,userhobby,userbalance,useraddress,creationtime,modificationtime,deletetime,creationperson,modificationperson,deleteperson from tb_sys_userinfo where userphone = @phone or username = @name and userdeletestate = @deletestate";
            return Dapper<Tb_sys_UserInfo>.Query(str, new
            {
                phone = userphone, //用户手机号
                name = username, //用户姓名
                deletestate = 1 //删除状态
            });
        }

        /// <summary>
        /// 查看回收站用户
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <returns></returns>
        public List<Tb_sys_UserInfo> GetDeleteUserList(int userid)
        {
            string str = "select userid,username,useradmin,userpass,userage,usersex,useridcard,userphone,userdeletestate,usernumber,useravatar,userhobby,userbalance,useraddress,creationtime,modificationtime,deletetime,creationperson,modificationperson,deleteperson from tb_sys_userinfo where userdeletestate = @deletestate";
            //判断用户id是否为0
            if (userid > 0)
            {
                str += " and userid = @id";
                return Dapper<Tb_sys_UserInfo>.Query(str, new
                {
                    id = userid, //用户id
                    deletestate = 1 //删除状态
                });
            }
            else
            {
                return Dapper<Tb_sys_UserInfo>.Query(str, new
                {
                    deletestate = 1 //删除状态
                });
            }
        }
    }
}
