using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHealthcare.Domain;
using SmartHealthcare.Service.GoodsType;
using SmartHealthcare.Service.Upoad;
using SmartHealthcare.Service.ViewModel;

namespace SmartHealthcare.Api.Controllers
{
    /// <summary>
    /// 商品分类控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GoodTypeController : ControllerBase
    {
        /// <summary>
        /// 依赖注入
        /// </summary>
        IGoodTypeService _type;
        IUpoadService _upoad;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="type">商品分类服务接口</param>
        /// <param name="upoad">上传文件服务接口</param>
        public GoodTypeController(IGoodTypeService type, IUpoadService upoad)
        {
            _type = type;
            _upoad = upoad;
        }

        /// <summary>
        /// 获取商品分类信息
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        [HttpGet]
        public IActionResult GetGoodTypeList()
        {
            //捕获异常
            try
            {
                //获取商品分类信息
                List<Tb_sys_GoodsType> type = _type.GetGoodTypeList();
                //返回数据
                return Ok(new
                {
                    code = 200,
                    msg = "成功",
                    data = type
                });
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("获取商品分类信息异常", ex);
            }
        }

        [HttpPost]
        public IActionResult InsertGoodTypeInfo(Tb_sys_GoodsTypeViewModel type)
        {
            //捕获异常
            try
            {
                //新增商品分类信息
                int i = _type.InsertGoodTypeInfo(type);
                if (i > 0)
                {
                    //返回数据
                    return Ok(new
                    {
                        code = 200,
                        msg = "新增成功",
                        data = i
                    });
                }
                else
                {
                    //返回数据
                    return Ok(new
                    {
                        code = 400,
                        msg = "新增失败",
                        data = i
                    });
                }
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("新增商品分类信息异常", ex);
            }
        }
    }
}
