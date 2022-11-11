using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthcare.Service.ViewModel
{
    /// <summary>
    /// 医院视图模型
    /// </summary>
    public class Tb_sys_HospitalViewModel
    {
        public int HospitalId { get; set; } //医院id
        public int HospitalName { get; set; } //医院名称
        public int HospitalCode { get; set; } //医院编码
        public int HospitalPId { get; set; } //医院父级id

        public DateTime creationTime { get; set; }//创建日期
        public DateTime modificationTime { get; set; } //修改日期
        public DateTime deletetime { get; set; } //删除日期
        public string? creationPerson { get; set; } //创建人
        public string? modificationPerson { get; set; } //修改人
        public string? deletePerson { get; set; } //删除人
    }
}
