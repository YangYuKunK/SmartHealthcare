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
        string UpLoad(IFormFile file);
    }
}
