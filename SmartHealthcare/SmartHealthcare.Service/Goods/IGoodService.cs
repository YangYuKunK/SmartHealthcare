﻿using SmartHealthcare.Domain;
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
        /// 新增商品信息
        /// </summary>
        /// <param name="good">商品数据模型</param>
        /// <returns></returns>
        int InsertGoodInfo(Tb_sys_GoodsInfoViewModel good);

        /// <summary>
        /// 变更商品状态
        /// </summary>
        /// <param name="goodid">商品id</param>
        /// <returns></returns>
        int UpdateDeleteGoodInfo(int goodid);

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
    }
}
