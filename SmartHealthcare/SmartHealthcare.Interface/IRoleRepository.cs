using SmartHealthcare.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthcare.Interface
{
    /// <summary>
    /// 角色仓储接口
    /// </summary>
    public interface IRoleRepository
    {
        /*
         * 角色信息
         * 新增角色信息
         * 删除角色信息
         * 添加用户时新增用户角色信息
         * 编辑角色信息
         */

        /// <summary>
        /// 获取除管理员外的角色信息
        /// </summary>
        /// <returns></returns>
        List<Tb_sys_RoleInfo> GetRoleList();

        /// <summary>
        /// 新增角色信息
        /// 需要自动添加创建时间
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        int InsertRoleInfo(Tb_sys_RoleInfo role);

        /// <summary>
        /// 删除角色信息
        /// 同时将该角色相关信息变为角色信息
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        int DeleteRole(int roleid);

        /// <summary>
        /// 编辑用户信息
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        int UpdateRoleInfo(Tb_sys_RoleInfo role);
    }
}
