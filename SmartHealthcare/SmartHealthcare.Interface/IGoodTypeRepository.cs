using SmartHealthcare.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthcare.Interface
{
    /// <summary>
    /// 商品分类仓储接口
    /// </summary>
    public interface IGoodTypeRepository
    {
        /// <summary>
        /// 获取商品分类信息
        /// </summary>
        /// <returns></returns>
        List<Tb_sys_GoodsType> GetGoodTypeList();

        /// <summary>
        /// 新增商品分类
        /// </summary>
        /// <param name="type">商品分类数据模型</param>
        /// <returns></returns>
        int InsertGoodTypeInfo(Tb_sys_GoodsType type);

        /// <summary>
        /// 删除商品分类
        /// </summary>
        /// <param name="typeid">分类id</param>
        /// <returns></returns>
        int DeleteGoodTypeInfo(int typeid);

        /// <summary>
        /// 编辑商品分类
        /// </summary>
        /// <param name="type">商品分类数据模型</param>
        /// <returns></returns>
        int UpdateGoodTypeInfo(Tb_sys_GoodsType type);
    }
}
