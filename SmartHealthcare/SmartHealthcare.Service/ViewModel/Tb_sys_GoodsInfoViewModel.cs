using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthcare.Service.ViewModel
{
    /// <summary>
    /// 商品视图模型
    /// </summary>
    public class Tb_sys_GoodsInfoViewModel
    {
        public int GoodsId { get; set; } //商品id
        public string? GoodsName { get; set; } //商品名称
        public decimal GoodsPrice { get; set; } //商品价格
        public int GoodsIsState { get; set; } //是否有货
        public int GoodsShelfState { get; set; } //上下架
        public int GoodsDeleteState { get; set; } //是否删除
        public int GoodsNumber { get; set; } //存货数量
        public string? GoodsImg { get; set; } //商品图片
        public string? ProductID { get; set; } //商品编码
        public string? GoodsDescription { get; set; } //商品简介
        public string? GoodsSpecification { get; set; } //商品规格
        public string? GoodsServe { get; set; } //售后服务
        public int TypeId { get; set; } //类别id
        public string? TypeName { get; set; } //类别名称

        public DateTime CreationTime { get; set; } //创建时间
        public DateTime ModificationTime { get; set; } //修改时间
        public DateTime Deletetime { get; set; } //删除时间
        public string? CreationPerson { get; set; } //创建人
        public string? ModificationPerson { get; set; } //修改人
        public string? DeletePerson { get; set; } //删除人
    }
}