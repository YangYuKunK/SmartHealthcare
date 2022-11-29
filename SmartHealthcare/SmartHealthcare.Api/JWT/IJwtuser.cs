using SmartHealthcare.Domain;

namespace SmartHealthcare.Api.JWT
{
    public interface IJwtuser
    {
        /// <summary>
        /// 用户登录jwt认证
        /// 进行加密
        /// </summary>
        /// <param name="user">用户数据模型</param>
        /// <returns></returns>
        string JwtJia(Tb_sys_UserInfo user);
    }
}
