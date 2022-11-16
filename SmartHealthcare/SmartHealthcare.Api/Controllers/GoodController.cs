using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartHealthcare.Domain;
using SmartHealthcare.Service.Goods;
using SmartHealthcare.Service.Upoad;
using SmartHealthcare.Service.ViewModel;

namespace SmartHealthcare.Api.Controllers
{
    /// <summary>
    /// 商品控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GoodController : ControllerBase
    {
        /// <summary>
        /// 依赖注入
        /// </summary>
        IGoodService _good;
        IUpoadService _upoad;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="good">商品服务接口</param>
        /// <param name="upoad">文件上传服务接口</param>
        public GoodController(IGoodService good, IUpoadService upoad)
        {
            _good = good;
            _upoad = upoad;
        }

        /// <summary>
        /// 获取商品信息(未加入回收站)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetGoodList()
        {
            //获取商品信息
            List<Tb_sys_GoodsInfo> good = _good.GetGoodsList(0);
            //返回数据
            return Ok(new
            {
                code = 200,
                msg = "成功",
                data = good
            });
        }

        /// <summary>
        /// 获取商品信息(已加入回收站)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetDeleteGoodList()
        {
            //获取商品信息
            List<Tb_sys_GoodsInfo> good = _good.GetDeleteGoodsList(0);
            //返回数据
            return Ok(new
            {
                code = 200,
                msg = "成功",
                data = good
            });
        }

        /// <summary>
        /// 条件查询商品信息
        /// </summary>
        /// <param name="goodname">商品名称</param>
        /// <param name="typeid">商品类别id</param>
        /// <param name="delstate">删除状态</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        [HttpGet]
        public IActionResult SelectGoodList(string? goodname, int? typeid, int delstate)
        {
            //捕获异常
            try
            {
                //获取商品信息
                List<Tb_sys_GoodsInfo> good = _good.SelectGoodList(goodname, typeid, delstate);
                //返回数据
                return Ok(new
                {
                    code = 200,
                    msg = "成功",
                    data = good
                });
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("条件查询商品信息异常", ex);
            }
        }

        #region 文件流

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="file">图片路径</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpLoad(IFormFile file)
        {
            //捕获异常
            try
            {
                //定义文件名
                string? fname = null;
                //获取文件名并赋值
                fname = _upoad.UpLoad(file);
                //返回数据
                return Ok(new
                {
                    newFileName = "https://6bj3594361.zicp.fun/" + fname
                });
            }
            catch (Exception)
            {
                //抛出异常
                throw new Exception("文件上传异常");
            }
        }

        #endregion

        /// <summary>
        /// 新增商品信息
        /// </summary>
        /// <param name="good">商品视图模型</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        [HttpPost]
        public IActionResult InsertGoodInfo(Tb_sys_GoodsInfoViewModel good)
        {
            //捕获异常
            try
            {
                //新增商品信息
                int i = _good.InsertGoodInfo(good);
                if (i > 0)
                {
                    //返回数据
                    return Ok(new
                    {
                        code = 200,
                        msg = "新增商品信息成功",
                        data = i
                    });
                }
                else
                {
                    //返回数据
                    return Ok(new
                    {
                        code = 400,
                        msg = "新增商品信息失败",
                        data = i
                    });
                }
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("新增商品信息异常", ex);
            }
        }

        /// <summary>
        /// 变更商品删除状态
        /// </summary>
        /// <param name="goodid">商品id</param>
        /// <param name="state">判断商品状态</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        [HttpPut]
        public IActionResult UpdateDeleteStateGood(int goodid, int state)
        {
            //捕获异常
            try
            {
                //变更商品信息
                int i = _good.UpdateDeleteGoodInfo(goodid, state);
                if (i > 0)
                {
                    //返回数据
                    return Ok(new
                    {
                        code = 200,
                        msg = "变更商品删除状态成功",
                        data = i
                    });
                }
                else
                {
                    //返回数据
                    return Ok(new
                    {
                        code = 400,
                        msg = "变更商品删除状态失败",
                        data = i
                    });
                }
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("变更商品删除状态异常", ex);
            }
        }

        /// <summary>
        /// 编辑商品信息
        /// </summary>
        /// <param name="good">商品视图模型</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        [HttpPut]
        public IActionResult UpdateGoodInfo(Tb_sys_GoodsInfoViewModel good)
        {
            //捕获异常
            try
            {
                //编辑商品信息
                int i = _good.UpdateGoodInfo(good);
                if (i > 0)
                {
                    //返回数据
                    return Ok(new
                    {
                        code = 200,
                        msg = "编辑商品信息成功",
                        data = i
                    });
                }
                else
                {
                    //返回数据
                    return Ok(new
                    {
                        code = 400,
                        msg = "编辑商品信息失败",
                        data = i
                    });
                }
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("编辑商品信息异常", ex);
            }
        }

        /// <summary>
        /// 删除该商品信息
        /// </summary>
        /// <param name="goodid">商品id</param>
        /// <returns></returns>
        /// <exception cref="Exception">捕获异常</exception>
        [HttpDelete]
        public IActionResult DeleteGoodInfo(int goodid = 0)
        {
            //捕获异常
            try
            {
                //删除商品信息
                int i = _good.DeleteGoodInfo(goodid);
                if (i > 0)
                {
                    //返回数据
                    return Ok(new
                    {
                        code = 200,
                        msg = "删除该商品信息成功",
                        data = i
                    });
                }
                else
                {
                    //返回数据
                    return Ok(new
                    {
                        code = 400,
                        msg = "删除该商品信息失败",
                        data = i
                    });
                }
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("删除该商品信息异常", ex);
            }
        }
    }
}
