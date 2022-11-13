using Org.BouncyCastle.Bcpg.Sig;
using SmartHealthcare.Domain;
using SmartHealthcare.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthcare.Infrastructure
{
    /// <summary>
    /// 角色仓储实践
    /// </summary>
    public class RoleRepository : IRoleRepository
    {
        /// <summary>
        /// 获取除管理员外的角色信息
        /// </summary>
        /// <returns></returns>
        public List<Tb_sys_RoleInfo> GetRoleList()
        {
            int roleid = 1;
            string str = "select roleid,rolename,creationtime,modificationtime,deletetime,creationperson,modificationperson,deleteperson from tb_sys_roleinfo where roleid != @id";
            return Dapper<Tb_sys_RoleInfo>.Query(str, new
            {
                id = roleid //角色id
            });
        }

        /// <summary>
        /// 新增角色信息
        /// 需要自动添加创建时间
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public int InsertRoleInfo(Tb_sys_RoleInfo role)
        {
            string str = "insert into tb_sys_roleinfo (roleid,rolename,creationtime,modificationtime,deletetime,creationperson,modificationperson,deleteperson) values (null,@name,@addtime,@upttime,@deltime,@addren,@uptren,@delren)";
            return Dapper<int>.RUD(str, new
            {
                name = role.RoleName, //角色名称
                addtime = DateTime.Now, //创建时间
                upttime = "", //修改时间
                deltime = "", //删除时间
                addren = "杨宇坤", //创建人
                uptren = "", //修改人
                delren = "" //删除人
            });
        }

        /// <summary>
        /// 删除角色信息
        /// 同时将该角色相关信息变为角色信息
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public int DeleteRole(int roleid)
        {
            string str = "delete from tb_sys_roleinfo where roleid = @id;";
            return Dapper<int>.RUD(str, new
            {
                id = roleid //角色id
            });
        }

        /// <summary>
        /// 编辑用户信息
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public int UpdateRoleInfo(Tb_sys_RoleInfo role)
        {
            string str = "update tb_sys_roleinfo set rolename = @name,creationtime = @addtime,modificationtime = @upttime,deletetime = @deltime,creationperson = @addren,modificationperson = @uptren,deleteperson = @delren where roleid = @id;";
            return Dapper<int>.RUD(str, new
            {
                id = role.RoleId, //角色id
                name = role.RoleName, //角色名称
                addtime = role.CreationTime, //创建时间
                upttime = DateTime.Now, //修改时间
                deltime = role.Deletetime, //删除时间
                addren = role.CreationPerson, //创建人
                uptren = "杨宇坤", //修改人
                delren = role.DeletePerson //删除人
            });
        }
    }
}
