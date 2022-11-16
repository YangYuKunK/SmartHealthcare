using AutoMapper;
using SmartHealthcare.Domain;
using SmartHealthcare.Interface;
using SmartHealthcare.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthcare.Service.GoodsType
{
    /// <summary>
    /// 商品分类服务实践
    /// </summary>
    public class GoodTypeService : IGoodTypeService
    {
        /// <summary>
        /// 依赖注入
        /// </summary>
        IGoodTypeRepository _type;
        IMapper _mapper;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="type">商品分类仓储接口</param>
        /// <param name="mapper">automapper</param>
        public GoodTypeService(IGoodTypeRepository type, IMapper mapper)
        {
            _type = type;
            _mapper = mapper;
        }

        /// <summary>
        /// 获取商品分类信息
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        public List<Tb_sys_GoodsType> GetGoodTypeList()
        {
            //捕获异常
            try
            {
                //获取商品分类信息
                List<Tb_sys_GoodsType> type = _type.GetGoodTypeList();
                //返回数据
                return type;
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("获取商品分类信息异常", ex);
            }
        }

        /// <summary>
        /// 新增商品分类
        /// </summary>
        /// <param name="type">商品分类视图模型</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        public int InsertGoodTypeInfo(Tb_sys_GoodsTypeViewModel type)
        {
            //捕获异常
            try
            {
                //模型映射
                Tb_sys_GoodsType types = _mapper.Map<Tb_sys_GoodsType>(type);
                //审计字段赋值
                types.CreationTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                type.CreationPerson = "杨宇坤";
                //新增商品分类信息
                int i = _type.InsertGoodTypeInfo(types);
                //返回数据
                return i;
            }
            catch (Exception ex)
            {
                //抛出异常
                throw;
            }
        }

        /// <summary>
        /// 删除商品分类
        /// </summary>
        /// <param name="typeid">分类id</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        public int DeleteGoodTypeInfo(int typeid)
        {
            //捕获异常
            try
            {
                //判断分类id是否未0
                if (typeid != 0)
                {
                    //删除该商品分类
                    int i = _type.DeleteGoodTypeInfo(typeid);
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
                throw new Exception("删除该商品分类异常", ex);
            }
        }

        /// <summary>
        /// 编辑商品分类
        /// </summary>
        /// <param name="type">商品分类视图模型</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        public int UpdateGoodTypeInfo(Tb_sys_GoodsTypeViewModel type)
        {
            //捕获异常
            try
            {
                //模型映射
                Tb_sys_GoodsType types = _mapper.Map<Tb_sys_GoodsType>(type);
                //审计字段赋值
                types.ModificationTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                type.ModificationPerson = "杨宇坤";
                //编辑商品分类信息
                int i = _type.UpdateGoodTypeInfo(types);
                //返回数据
                return i;
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("编辑商品分类异常", ex);
            }
        }

        
    }
}
