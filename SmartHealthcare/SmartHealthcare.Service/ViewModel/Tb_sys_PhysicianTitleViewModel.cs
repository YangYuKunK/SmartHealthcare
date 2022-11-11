using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthcare.Service.ViewModel
{
    /// <summary>
    /// 医生职称视图模型
    /// </summary>
    public class Tb_sys_PhysicianTitleViewModel
    {
        public int PhysicianId { get; set; } //医生职称id
        public string? PhysicianName { get; set; } //医生职称名称
    }
}
