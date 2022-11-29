namespace SmartHealthcare.Api.JWT
{
    public class JwtConfig
    {
        /// <summary>
        /// Token发布者
        /// </summary>
        public string? Issuer { get; set; }
        /// <summary>
        /// Token接受者
        /// </summary>
        public string? Audience { get; set; }
        /// <summary>
        /// 秘钥可以构建服务器认可的token；签名秘钥长度最少16
        /// </summary>
        public string? IssuerSigningKey { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public int AccessTokenExpiresMinutes { get; set; }
    }
}
