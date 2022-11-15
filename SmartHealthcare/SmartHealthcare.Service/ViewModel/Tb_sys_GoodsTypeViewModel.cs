using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthcare.Service.ViewModel
{
    /// <summary>
    /// 商品类型视图模型
    /// </summary>
    public class Tb_sys_GoodsTypeViewModel
    {
        public int TypeId { get; set; } //类别id
        public string? TypeName { get; set; } //类别名称
        public int GoodsTypeNumber { get; set; } //类别商品剩余数量

        public DateTime CreationTime { get; set; } //创建时间
        public DateTime ModificationTime { get; set; } //修改时间
        public DateTime Deletetime { get; set; } //删除时间
        public string? CreationPerson { get; set; } //创建人
        public string? ModificationPerson { get; set; } //修改人
        public string? DeletePerson { get; set; } //删除人
    }
}
