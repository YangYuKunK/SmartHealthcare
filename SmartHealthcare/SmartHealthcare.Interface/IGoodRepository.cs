using SmartHealthcare.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthcare.Interface
{
    /// <summary>
    /// 商品仓储接口
    /// </summary>
    public interface IGoodRepository
    {
        /// <summary>
        /// 获取商品信息(未加入回收站)
        /// </summary>
        /// <param name="goodid">商品id</param>
        /// <returns></returns>
        List<Tb_sys_GoodsInfo> GetGoodsList(int goodid);

        /// <summary>
        /// 获取商品信息(已加入回收站)
        /// </summary>
        /// <param name="goodid">商品id</param>
        /// <returns></returns>
        List<Tb_sys_GoodsInfo> GetDeleteGoodsList(int goodid);

        /// <summary>
        /// 新增商品信息
        /// </summary>
        /// <param name="good">商品数据模型</param>
        /// <returns></returns>
        int InsertGoodInfo(Tb_sys_GoodsInfo good);

        /// <summary>
        /// 编辑商品信息
        /// </summary>
        /// <param name="good"></param>
        /// <returns></returns>
        int UpdateGoodInfo(Tb_sys_GoodsInfo good);

        /// <summary>
        /// 删除商品信息(真删)
        /// </summary>
        /// <param name="goodid">商品id</param>
        /// <returns></returns>
        int DeleteGoodInfo(int goodid);

        /// <summary>
        /// 条件查询商品信息
        /// </summary>
        /// <param name="goodname">商品名称</param>
        /// <param name="typeid">商品类别id</param>
        /// <param name="delstate">删除状态</param>
        /// <returns></returns>
        List<Tb_sys_GoodsInfo> SelectGoodList(string? goodname,int? typeid,int delstate);
    }
}
