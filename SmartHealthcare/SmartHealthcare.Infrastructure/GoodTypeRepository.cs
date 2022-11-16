using SmartHealthcare.Domain;
using SmartHealthcare.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartHealthcare.Infrastructure
{
    /// <summary>
    /// 商品分类仓储实践
    /// </summary>
    public class GoodTypeRepository : IGoodTypeRepository
    {
        /// <summary>
        /// 获取商品分类信息
        /// </summary>
        /// <returns></returns>
        public List<Tb_sys_GoodsType> GetGoodTypeList()
        {
            string str = "select TypeId,TypeName,GoodsTypeNumber,CreationTime,ModificationTime,Deletetime,CreationPerson,ModificationPerson,DeletePerson from Tb_sys_GoodsType";
            return Dapper<Tb_sys_GoodsType>.Query(str);
        }

        /// <summary>
        /// 新增商品分类
        /// </summary>
        /// <param name="type">商品分类数据模型</param>
        /// <returns></returns>
        public int InsertGoodTypeInfo(Tb_sys_GoodsType type)
        {
            string str = "insert into Tb_sys_GoodsType (TypeId,TypeName,GoodsTypeNumber,CreationTime,ModificationTime,Deletetime,CreationPerson,ModificationPerson,DeletePerson) values (null,@name,@number,@addtime,@upttime,@deltime,@addren,@uptren,@delren)";
            return Dapper<int>.RUD(str, new
            {
                name = type.TypeName, //商品分类名称
                number = type.GoodsTypeNumber, //分类商品剩余数量
                addtime = type.CreationTime, //创建时间
                upttime = type.ModificationTime, //修改时间
                deltime = type.Deletetime, //删除时间
                addren = type.CreationPerson, //创建人
                uptren = type.ModificationPerson, //修改人
                delren = type.DeletePerson //删除人
            });
        }

        /// <summary>
        /// 删除商品分类
        /// </summary>
        /// <param name="typeid">分类id</param>
        /// <returns></returns>
        public int DeleteGoodTypeInfo(int typeid)
        {
            string str = "delete from tb_sys_goodstype where typeid = @id";
            return Dapper<int>.RUD(str, new
            {
                id = typeid //商品分类id
            });
        }

        /// <summary>
        /// 编辑商品分类
        /// </summary>
        /// <param name="type">商品分类数据模型</param>
        /// <returns></returns>
        public int UpdateGoodTypeInfo(Tb_sys_GoodsType type)
        {
            string str = "update Tb_sys_GoodsType set TypeName = @name,GoodsTypeNumber = @number,CreationTime = @addtime,ModificationTime = @upttime,Deletetime = @deltime,CreationPerson = @addren,ModificationPerson = @uptren,DeletePerson = @delren where TypeId = @tid";
            return Dapper<int>.RUD(str,new
            {
                tid = type.TypeId, //商品id
                name = type.TypeName, //商品分类名称
                number = type.GoodsTypeNumber, //分类商品剩余数量
                addtime = type.CreationTime, //创建时间
                upttime = type.ModificationTime, //修改时间
                deltime = type.Deletetime, //删除时间
                addren = type.CreationPerson, //创建人
                uptren = type.ModificationPerson, //修改人
                delren = type.DeletePerson //删除人
            });
        }
    }
}
