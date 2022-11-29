using Microsoft.IdentityModel.Tokens;
using SmartHealthcare.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartHealthcare.Api.JWT
{
    public class JwtUser : IJwtuser
    {
        /// <summary>
        /// 依赖注入
        /// </summary>
        readonly JwtConfig _jwt;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="jwt"></param>
        public JwtUser(JwtConfig jwt)
        {
            _jwt = jwt;
        }

        public string JwtJia(Tb_sys_UserInfo user)
        {
            //定义声明（证件单元）
            Claim[] claims = new Claim[]
            {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.Role,"Users")
            };

            //创建jwt字符串
            var token = new JwtSecurityToken(
                issuer: _jwt.Issuer,   //发布者
                audience: _jwt.Audience,   //接受者
                claims: claims,          //最重要的授权信息
                notBefore: DateTime.Now,    //发布时间
                expires: DateTime.Now.AddMinutes(_jwt.AccessTokenExpiresMinutes),   //过期时间
                signingCredentials: new SigningCredentials( //签名整数
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.IssuerSigningKey)), //秘钥(至少16位)
                SecurityAlgorithms.HmacSha256
                )
            );

            //把token对象转换成字符串
            string strToken = new JwtSecurityTokenHandler().WriteToken(token);

            //将token字符串返回至控制器
            return strToken;
        }
        /*jwt解析首先判断是否是三段信息（第一段头部、第二段用户信息、第三段签名即令牌）
        为三段后进行下一步，判断最后一段签名是否正确
        如用的64位加密则使用64位进行解密、32位则同上*/
    }
}
