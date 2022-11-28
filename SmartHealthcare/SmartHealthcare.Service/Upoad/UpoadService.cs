using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Qiniu.Http;
using Qiniu.Storage;
using Qiniu.Util;

namespace SmartHealthcare.Service.Upoad
{
    /// <summary>
    /// 文件上传服务实践
    /// </summary>
    public class UpoadService : IUpoadService
    {
        /// <summary>
        /// 上传本地
        /// </summary>
        /// <param name="file">图片路径</param>
        /// <returns></returns>
        public string UpLoad(IFormFile file)
        {
            //分析bin文件的绝对路径
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

        /// <summary>
        /// 上传云端
        /// 七牛云
        /// </summary>
        /// <param name="file">图片路径</param>
        /// <returns></returns>
        public string UpLoads(IFormFile file)
        {
            //这里是生成上传凭证的密钥
            Mac mac = new Mac(Settings.AccessKey, Settings.SecretKey);

            //七牛云空间名称
            string bucket = "imagesyu";
            //重新生成文件名称
            string saveKey = DateTime.Now.ToString("yyyyMMddHHmmssffff") + Path.GetExtension(file.FileName);
            //分析绝对路径
            string rootdir = AppContext.BaseDirectory.Split(@"\bin\")[0];
            //生成上传到iis文件夹中的绝对路径
            var path = rootdir + @"/img/" + saveKey;
            //获取该文件的本地绝对路径 用于上传该文件
            string localFile = path;
            //清空文件流
            using (FileStream fs = File.Create(path))
            {
                file.CopyTo(fs);
                fs.Flush();
            }

            //实例化PutPolicy
            PutPolicy putPolicy = new();

            // 如果需要设置为"覆盖"上传(如果云端已有同名文件则覆盖)，请使用 SCOPE = "BUCKET:KEY"
            putPolicy.Scope = bucket;

            // 生成上传凭证                    
            string jstr = putPolicy.ToJsonString();
            string token = Auth.CreateUploadToken(mac, jstr);

            //UseHttps表示：是否采用https域名 UseCdnDomains表示：上传是否使用CDN上传加速 MaxRetryTimes表示：重试请求次数
            UploadManager um = new UploadManager(new Config() { Zone = Zone.ZONE_CN_South, UseHttps = false, UseCdnDomains = false, MaxRetryTimes = 3 });
            //进行上传七牛云
            HttpResult result = um.UploadFile(localFile, saveKey, token, new PutExtra());
            //返回生成后的文件名
            return saveKey;
        }
        /// <summary>
        /// 七牛云密钥AccessKey和SecretKey
        /// </summary>
        class Settings
        {
            public static string AccessKey { get; set; } = "q8dgCTRuhW3kQ8urbjF5zKLpYKq4KJS3GCEIWLhS";
            public static string SecretKey { get; set; } = "m-5aIp4OTEDB-W8jMAmUfRopII21A-zIERdAH3TR";
        }
    }
}
