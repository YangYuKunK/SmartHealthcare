using AutoMapper;
using SmartHealthcare.Domain;
using SmartHealthcare.Infrastructure;
using SmartHealthcare.Interface;
using SmartHealthcare.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthcare.Service.Goods
{
    /// <summary>
    /// 商品服务实践
    /// </summary>
    public class GoodService : IGoodService
    {
        /// <summary>
        /// 依赖注入
        /// </summary>
        IGoodRepository _good;
        IMapper _mapper;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="good">商品仓储接口</param>
        /// <param name="mapper">automapper</param>
        public GoodService(IGoodRepository good, IMapper mapper)
        {
            _mapper = mapper;
            _good = good;
        }

        /// <summary>
        /// 获取商品信息(未加入回收站)
        /// </summary>
        /// <param name="goodid">商品id</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        public List<Tb_sys_GoodsInfo> GetGoodsList(int goodid)
        {
            //捕获异常
            try
            {
                //获取商品信息
                List<Tb_sys_GoodsInfo> good = _good.GetGoodsList(goodid);
                //返回数据
                return good;
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("获取商品信息异常", ex);
            }
        }

        /// <summary>
        /// 获取商品信息(已加入回收站)
        /// </summary>
        /// <param name="goodid">商品id</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        public List<Tb_sys_GoodsInfo> GetDeleteGoodsList(int goodid)
        {
            //捕获异常
            try
            {
                //获取商品信息
                List<Tb_sys_GoodsInfo> good = _good.GetDeleteGoodsList(goodid);
                //返回数据
                return good;
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("获取商品信息异常", ex);
            }
        }

        /// <summary>
        /// 新增商品信息
        /// </summary>
        /// <param name="good">商品数据模型</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        public int InsertGoodInfo(Tb_sys_GoodsInfoViewModel good)
        {
            //捕获异常
            try
            {
                //进行模型映射
                Tb_sys_GoodsInfo goods = _mapper.Map<Tb_sys_GoodsInfo>(good);
                //新增用户信息
                int i = _good.InsertGoodInfo(goods);
                //返回数据
                return i;
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("新增商品信息异常", ex);
            }
        }

        /// <summary>
        /// 变更商品状态
        /// </summary>
        /// <param name="goodid">商品id</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        public int UpdateDeleteGoodInfo(int goodid)
        {
            //捕获异常
            try
            {
                //判断商品id是否为0
                if (goodid != 0)
                {
                    //获取商品状态
                    List<Tb_sys_GoodsInfo> good = _good.GetGoodsList(goodid);
                    if (good[0].GoodsDeleteState == 0)
                    {
                        good[0].GoodsDeleteState = 1;
                    }
                    else if (good[0].GoodsDeleteState == 1)
                    {
                        good[0].GoodsDeleteState = 0;
                    }
                    //变更商品状态
                    int i = _good.UpdateGoodInfo(good[0]);
                    //返回数据
                    return i;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("变更商品状态异常", ex);
            }
        }

        /// <summary>
        /// 编辑商品信息
        /// </summary>
        /// <param name="good"></param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        public int UpdateGoodInfo(Tb_sys_GoodsInfoViewModel good)
        {
            //捕获异常
            try
            {
                //映射数据模型
                Tb_sys_GoodsInfo goods = _mapper.Map<Tb_sys_GoodsInfo>(good);
                //编辑商品信息
                int i = _good.UpdateGoodInfo(goods);
                //返回数据
                return i;
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("编辑商品信息异常", ex);
            }
        }

        /// <summary>
        /// 删除商品信息(真删)
        /// </summary>
        /// <param name="goodid">商品id</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        public int DeleteGoodInfo(int goodid)
        {
            //捕获异常
            try
            {
                //判断商品id是否未0
                if (goodid != 0)
                {
                    //删除商品信息
                    int i = _good.DeleteGoodInfo(goodid);
                    //返回数据
                    return i;
                }
                else
                {
                    //返回数据
                    return 0;
                }
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("删除商品信息异常", ex);
            }
        }
    }
}
