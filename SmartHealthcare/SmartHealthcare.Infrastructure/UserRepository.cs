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
            string str = "select userid,username,useradmin,userpass,userage,usersex,useridcard,userphone,userdeletestate,usernumber,useravatar,userhobby," +
                "userbalance,useraddress,creationtime,modicationtime,deletetime,creationperson,modificationperson,deleteperson from tb_sys_userinfo";
            return Dapper<Tb_sys_UserInfo>.Query(str);
        }
    }
}
