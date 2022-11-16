using SmartHealthcare.Domain;
using SmartHealthcare.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;
using System.Xml.Linq;

namespace SmartHealthcare.Infrastructure
{
    /// <summary>
    /// 商品仓储实践
    /// </summary>
    public class GoodRepository : IGoodRepository
    {
        /// <summary>
        /// 获取商品信息(未加入回收站)
        /// </summary>
        /// <param name="goodid">商品id</param>
        /// <returns></returns>
        public List<Tb_sys_GoodsInfo> GetGoodsList(int goodid)
        {
            string str = "select a.GoodsId,a.GoodsName,a.GoodsPrice,a.GoodsIsState,a.GoodsShelfState,a.GoodsDeleteState,a.GoodsNumber,a.GoodsImg,a.ProductID,a.GoodsDescription,a.GoodsSpecification,a.GoodsServe,a.TypeId,a.CreationTime,a.ModificationTime,a.Deletetime,a.CreationPerson,a.ModificationPerson,a.DeletePerson,b.TypeName from Tb_sys_GoodsInfo a join tb_sys_GoodsType b on a.TypeId = b.TypeId where a.GoodsDeleteState = @deletestate";
            //判断用户id是否为0
            if (goodid > 0)
            {
                str += " and a.goodsid = @id";
                return Dapper<Tb_sys_GoodsInfo>.Query(str, new
                {
                    id = goodid, //商品id
                    deletestate = 0 //删除状态
                });
            }
            else
            {
                return Dapper<Tb_sys_GoodsInfo>.Query(str, new
                {
                    deletestate = 0 //删除状态
                });
            }
        }

        /// <summary>
        /// 获取商品信息(已加入回收站)
        /// </summary>
        /// <param name="goodid">商品id</param>
        /// <returns></returns>
        public List<Tb_sys_GoodsInfo> GetDeleteGoodsList(int goodid)
        {
            string str = "select a.GoodsId,a.GoodsName,a.GoodsPrice,a.GoodsIsState,a.GoodsShelfState,a.GoodsDeleteState,a.GoodsNumber,a.GoodsImg,a.ProductID,a.GoodsDescription,a.GoodsSpecification,a.GoodsServe,a.TypeId,a.CreationTime,a.ModificationTime,a.Deletetime,a.CreationPerson,a.ModificationPerson,a.DeletePerson,b.TypeName from Tb_sys_GoodsInfo a join tb_sys_GoodsType b on a.TypeId = b.TypeId where a.GoodsDeleteState = @deletestate";
            //判断用户id是否为0
            if (goodid > 0)
            {
                str += " and a.goodsid = @id";
                return Dapper<Tb_sys_GoodsInfo>.Query(str, new
                {
                    id = goodid, //商品id
                    deletestate = 1 //删除状态
                });
            }
            else
            {
                return Dapper<Tb_sys_GoodsInfo>.Query(str, new
                {
                    deletestate = 1 //删除状态
                });
            }
        }

        /// <summary>
        /// 新增商品信息
        /// </summary>
        /// <param name="good">商品数据模型</param>
        /// <returns></returns>
        public int InsertGoodInfo(Tb_sys_GoodsInfo good)
        {
            string str = "insert into tb_sys_goodsinfo (GoodsId,GoodsName,GoodsPrice,GoodsIsState,GoodsShelfState,GoodsDeleteState,GoodsNumber,GoodsImg,ProductID,GoodsDescription,GoodsSpecification,GoodsServe,TypeId,CreationTime,ModificationTime,Deletetime,CreationPerson,ModificationPerson,DeletePerson) values (null,@name,@price,@isstate,@shelfstate,@delstate,@number,@img,@ductid,@iption,@fication,@serve,@tid,@addtime,@upttime,@deltime,@addren,@uptren,@delren)";
            return Dapper<int>.RUD(str, new
            {
                name = good.GoodsName, //商品名称
                price = good.GoodsPrice, //商品价格
                isstate = good.GoodsIsState, //是否有货
                shelfstate = good.GoodsShelfState, //上下架
                delstate = good.GoodsDeleteState, //是否删除
                number = good.GoodsNumber, //存货数量
                img = good.GoodsImg, //商品图片
                ductid = good.GroductID, //商品编码
                iption = good.GoodsDescription, //商品简介
                fication = good.GoodsSpecification, //商品规格
                serve = good.GoodsServe, //售后服务
                tid = good.TypeId, //类别id
                addtime = good.CreationTime, //创建时间
                upttime = good.ModificationTime, //修改时间
                deltime = good.Deletetime, //删除时间
                addren = good.CreationPerson, //创建人
                uptren = good.ModificationPerson, //修改人
                delren = good.DeletePerson //删除人
            });
        }

        /// <summary>
        /// 编辑商品信息
        /// </summary>
        /// <param name="good"></param>
        /// <returns></returns>
        public int UpdateGoodInfo(Tb_sys_GoodsInfo good)
        {
            string str = "update tb_sys_goodsinfo set GoodsName = @name,GoodsPrice = @price,GoodsIsState = @isstate,GoodsShelfState = @shelfstate,GoodsDeleteState = @delstate,GoodsNumber = @number,GoodsImg = @img,ProductID = @ductid,GoodsDescription = @iption,GoodsSpecification = @fication,GoodsServe = @serve,TypeId = @tid,CreationTime = @addtime,ModificationTime = @upttime,Deletetime = @deltime,CreationPerson = @addren,ModificationPerson = @uptren,DeletePerson = @delren where GoodsId = @gid";
            return Dapper<int>.RUD(str, new
            {
                gid = good.GoodsId, //商品id
                name = good.GoodsName, //商品名称
                price = good.GoodsPrice, //商品价格
                isstate = good.GoodsIsState, //是否有货
                shelfstate = good.GoodsShelfState, //上下架
                delstate = good.GoodsDeleteState, //是否删除
                number = good.GoodsNumber, //存货数量
                img = good.GoodsImg, //商品图片
                ductid = good.GroductID, //商品编码
                iption = good.GoodsDescription, //商品简介
                fication = good.GoodsSpecification, //商品规格
                serve = good.GoodsServe, //售后服务
                tid = good.TypeId, //类别id
                addtime = good.CreationTime, //创建时间
                upttime = good.ModificationTime, //修改时间
                deltime = good.Deletetime, //删除时间
                addren = good.CreationPerson, //创建人
                uptren = good.ModificationPerson, //修改人
                delren = good.DeletePerson //删除人
            });
        }

        /// <summary>
        /// 删除商品信息(真删)
        /// </summary>
        /// <param name="goodid">商品id</param>
        /// <returns></returns>
        public int DeleteGoodInfo(int goodid)
        {
            string str = "delete from tb_sys_goodsinfo where goodsid = @id";
            return Dapper<int>.RUD(str, new
            {
                id = goodid //商品id
            });
        }
        /// <summary>
        /// 条件查询商品信息
        /// </summary>
        /// <param name="goodname">商品名称</param>
        /// <param name="typeid">商品类别id</param>
        /// <param name="delstate">删除状态</param>
        /// <returns></returns>
        public List<Tb_sys_GoodsInfo> SelectGoodList(string? goodname, int? typeid, int delstate)
        {
            string str = "select a.GoodsId,a.GoodsName,a.GoodsPrice,a.GoodsIsState,a.GoodsShelfState,a.GoodsDeleteState,a.GoodsNumber,a.GoodsImg,a.ProductID,a.GoodsDescription,a.GoodsSpecification,a.GoodsServe,a.TypeId,a.CreationTime,a.ModificationTime,a.Deletetime,a.CreationPerson,a.ModificationPerson,a.DeletePerson,b.TypeName from Tb_sys_GoodsInfo a join tb_sys_GoodsType b on a.TypeId = b.TypeId where a.GoodsDeleteState = @deletestate";
            if (!string.IsNullOrEmpty(goodname) || typeid != 0 && !string.IsNullOrEmpty(Convert.ToString(typeid)))
            {
                str += " and a.goodsname = @name or a.typeid = @tid";
            }
            return Dapper<Tb_sys_GoodsInfo>.Query(str, new
            {
                deletestate = delstate, //删除状态
                name = goodname, //商品名称
                tid = typeid //商品类别id
            });
        }
    }
}
