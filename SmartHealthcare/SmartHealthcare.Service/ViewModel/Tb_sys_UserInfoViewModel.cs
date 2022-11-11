using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthcare.Service.ViewModel
{
    /// <summary>
    /// 用户试图模型
    /// </summary>
    public class Tb_sys_UserInfoViewModel
    {
        public int  UserId { get; set; } //用户id
        public string? UserName { get; set; } //用户姓名
        public string? UserAdmin { get; set; } //用户登录账号
        public string? UserPass { get; set; } //用户登录密码
        public int  UserAge { get; set; } //用户年龄
        public int  UserSex { get; set; } //用户性别
        public string? UserIDCard { get; set; } //用户身份证号
        public string? UserPhone { get; set; } //用户手机号
        public int  UserDeleteState { get; set; } //用户状态(逻辑删除)
        public string? UserNumber { get; set; } //用户编号
        public string? UserAvatar { get; set; } //用户头像
        public string? UserHobby { get; set; } //用户爱好
        public decimal UserBalance { get; set; } //用户余额
        public string? UserAddress { get; set; } //用户地址

        public DateTime creationTime { get; set; }//创建日期
        public DateTime modificationTime { get; set; } //修改日期
        public DateTime deletetime { get; set; } //删除日期
        public string? creationPerson { get; set; } //创建人
        public string? modificationPerson { get; set; } //修改人
        public string? deletePerson { get; set; } //删除人
    }
}
