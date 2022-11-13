using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHealthcare.Domain;
using SmartHealthcare.Service.RoleInfo;
using SmartHealthcare.Service.ViewModel;

namespace SmartHealthcare.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        /// <summary>
        /// 依赖注入
        /// </summary>
        IRoleService _role;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="role">角色服务接口</param>
        public RoleController(IRoleService role)
        {
            _role = role;
        }

        /// <summary>
        /// 获取除管理员外所有角色信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetRoleList()
        {
            //获取角色信息
            List<Tb_sys_RoleInfo> role = _role.GetRoleList();
            //返回数据
            return Ok(new
            {
                code = 200,
                msg = "成功",
                data = role
            });
        }

        /// <summary>
        /// 新增角色信息
        /// </summary>
        /// <param name="role">角色视图模型</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        [HttpPost]
        public IActionResult InsertRoleInfo(Tb_sys_RoleInfoViewModel role)
        {
            //捕获异常
            try
            {
                //新增角色信息
                int i = _role.InsertRoleInfo(role);
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
                        code = 400,
                        msg = "新增失败",
                        data = i
                    });
                }
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("新增角色信息异常", ex);
            }
        }

        /// <summary>
        /// 编辑角色信息
        /// </summary>
        /// <param name="role">角色视图模型</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        [HttpPut]
        public IActionResult UpdateRoleInfo(Tb_sys_RoleInfoViewModel role)
        {
            //捕获异常
            try
            {
                //编辑角色信息
                int i = _role.UpdateRoleInfo(role);
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
                throw new Exception("编辑角色信息异常", ex);
            }
        }

        /// <summary>
        /// 删除角色信息
        /// </summary>
        /// <param name="roleid">角色id</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        [HttpDelete]
        public IActionResult DeleteRoleInfo(int roleid = 0)
        {
            //捕获异常
            try
            {
                //删除选中角色信息
                int i = _role.DeleteRole(roleid);
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
                throw new Exception("删除角色信息异常", ex);
            }
        }
    }
}
