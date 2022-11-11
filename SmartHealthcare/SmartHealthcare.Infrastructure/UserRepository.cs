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
        /// <returns></returns>
        public List<Tb_sys_UserInfo> GetUserLists()
        {
            string str = "select userid,username,useradmin,userpass	,userage,usersex,useridcard,userphone,userdeletestate,usernumber,useravatar,userhobby,userbalance,useraddress,creationtime,modificationtime,deletetime,creationperson,modificationperson,deleteperson from tb_sys_userinfo";
            return Dapper<Tb_sys_UserInfo>.Query(str);
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
                createdate = user.CreationTime, //创建时间
                updatetime = user.ModificationTime, //修改时间
                deletetime = user.Deletetime, //删除时间
                createname = user.CreationPerson, //创建人
                updatename = user.ModificationPerson, //修改人
                deletename = user.DeletePerson //删除人
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
            return Dapper<Tb_sys_UserInfo>.QueryFirst(str, new {
                useradmin = admin,
                userpass = pass
            });

        }
    }
}
