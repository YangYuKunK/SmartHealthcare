using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthcare.Service.Upoad
{
    /// <summary>
    /// 文件上传服务接口
    /// </summary>
    public interface IUpoadService
    {
        /// <summary>
        /// 上传本地方式
        /// </summary>
        /// <param name="file">图片路径</param>
        /// <returns></returns>
        string UpLoad(IFormFile file);

        /// <summary>
        /// 上传云端
        /// 七牛云
        /// </summary>
        /// <param name="file">图片路径</param>
        /// <returns></returns>
        string UpLoads(IFormFile file);
    }

}
