using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthcare.Service.Upoad
{
    /// <summary>
    /// 文件上传服务实践
    /// </summary>
    public class UpoadService : IUpoadService
    {
        public string UpLoad(IFormFile file)
        {
            //分析绝对路径
            string rootdir = AppContext.BaseDirectory.Split(@"\bin\")[0];
            string fname = DateTime.Now.ToString("yyyyMMddHHmmssffff") + Path.GetExtension(file.FileName);
            var path = rootdir + @"/img/" + fname;
            using (FileStream fs = File.Create(path))
            {
                file.CopyTo(fs);
                fs.Flush();//清空文件流
            }
            return fname;
        }
    }
}
