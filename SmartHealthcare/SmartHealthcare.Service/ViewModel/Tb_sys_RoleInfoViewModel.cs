using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthcare.Service.ViewModel
{
    /// <summary>
    /// 角色视图模型
    /// </summary>
    public class Tb_sys_RoleInfoViewModel
    {
        public int RoleId { get; set; } //角色id
        public string? RoleName { get; set; } //角色名称

        public DateTime CreationTime { get; set; } //创建日期
        public DateTime ModificationTime { get; set; } //修改日期
        public DateTime Deletetime { get; set; } //删除日期
        public string? CreationPerson { get; set; } //创建人
        public string? ModificationPerson { get; set; } //修改人
        public string? DeletePerson { get; set; } //删除人
    }
}
