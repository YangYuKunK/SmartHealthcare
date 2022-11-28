using SmartHealthcare.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthcare.Interface
{
    /// <summary>
    /// 医生仓储接口
    /// </summary>
    public interface IDoctorRepository
    {
        /// <summary>
        /// 获取医生信息
        /// </summary>
        /// <returns></returns>
        List<Tb_sys_DoctorInfo> GetDoctorList();

        /// <summary>
        /// 医生登录
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns></returns>
        Tb_sys_DoctorInfo SelectDoctorLogin(string phone);

        /// <summary>
        /// 查询用户当中是否存在当前手机号
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns></returns>
        Tb_sys_UserInfo SelectUserLogin(string phone);

        /// <summary>
        /// 医生注册
        /// </summary>
        /// <param name="doctor">医生数据模型</param>
        /// <returns></returns>
        int CreateDoctorInfo(Tb_sys_DoctorInfo doctor);

        /// <summary>
        /// 插入用户角色信息
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="doctor"></param>
        /// <returns></returns>
        int SelectUserInfo(string? phone, Tb_sys_DoctorInfo doctor);
    }
}
