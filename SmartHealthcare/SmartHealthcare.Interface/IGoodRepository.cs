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
    }
}
