using SmartHealthcare.Domain;
using SmartHealthcare.Infrastructure;
using SmartHealthcare.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthcare.Service.Goods
{
    /// <summary>
    /// 商品服务接口
    /// </summary>
    public interface IGoodService
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
        /// 查看上下架商品信息
        /// </summary>
        /// <param name="goodid">商品id</param>
        /// <param name="state">上下架状态</param>
        /// <returns></returns>
        List<Tb_sys_GoodsInfo> GetShelGoodList(int goodid, int state);

        /// <summary>
        /// 新增商品信息
        /// </summary>
        /// <param name="good">商品数据模型</param>
        /// <returns></returns>
        int InsertGoodInfo(Tb_sys_GoodsInfoViewModel good);

        /// <summary>
        /// 变更商品删除状态
        /// </summary>
        /// <param name="goodid">商品id</param>
        /// <param name="state">判断商品状态</param>
        /// <returns></returns>
        int UpdateDeleteGoodInfo(int goodid, int state);

        /// <summary>
        /// 编辑商品信息
        /// </summary>
        /// <param name="good">商品视图模型</param>
        /// <returns></returns>
        int UpdateGoodInfo(Tb_sys_GoodsInfoViewModel good);

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
        List<Tb_sys_GoodsInfo> SelectGoodList(string? goodname, int? typeid, int delstate);

        /// <summary>
        /// 变更商品上下架状态
        /// </summary>
        /// <param name="goodid">商品id</param>
        /// <param name="state">判断商品状态</param>
        /// <returns></returns>
        int UpdateShelStateGoodInfo(int goodid, int state);
    }
}
