using AutoMapper;
using SmartHealthcare.Domain;
using SmartHealthcare.Interface;
using SmartHealthcare.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthcare.Service.RoleInfo
{
    /// <summary>
    /// 角色服务实践
    /// </summary>
    public class RoleService : IRoleService
    {
        /// <summary>
        /// 依赖注入
        /// </summary>
        IRoleRepository _role;
        IMapper _mapper;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="role">角色仓储接口</param>
        /// <param name="mapper">automapper</param>
        public RoleService(IRoleRepository role, IMapper mapper)
        {
            _role = role;
            _mapper = mapper;
        }

        /// <summary>
        /// 获取除管理员外的角色信息
        /// </summary>
        /// <returns></returns>

        public List<Tb_sys_RoleInfo> GetRoleList()
        {
            //获取角色信息
            List<Tb_sys_RoleInfo> role = _role.GetRoleList();
            //返回数据
            return role;
        }

        /// <summary>
        /// 新增角色信息
        /// 需要自动添加创建时间
        /// </summary>
        /// <param name="roles">角色视图模型</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        public int InsertRoleInfo(Tb_sys_RoleInfoViewModel roles)
        {
            //捕获异常
            try
            {
                //映射模型
                Tb_sys_RoleInfo role = _mapper.Map<Tb_sys_RoleInfo>(roles);
                //新增角色信息
                int i = _role.InsertRoleInfo(role);
                //返回数据
                return i;
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("新增角色信息异常", ex);
            }
        }

        /// <summary>
        /// 编辑用户信息
        /// </summary>
        /// <param name="roles">角色视图模型</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        public int UpdateRoleInfo(Tb_sys_RoleInfoViewModel roles)
        {
            //捕获异常
            try
            {
                //映射模型
                Tb_sys_RoleInfo role = _mapper.Map<Tb_sys_RoleInfo>(roles);
                //编辑角色信息
                int i = _role.InsertRoleInfo(role);
                //返回数据
                return i;
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("编辑角色信息异常", ex);
            }
        }

        /// <summary>
        /// 删除角色信息
        /// </summary>
        /// <param name="roleid">角色id</param>
        /// <returns></returns>
        public int DeleteRole(int roleid)
        {
            //判断角色id是否为0
            if (roleid != 0)
            {
                //删除角色信息
                int i = _role.DeleteRole(roleid);
                //返回数据
                return i;
            }
            else
            {
                //返回数据
                return 0;
            }
        }
    }
}
