using SmartHealthcare.Domain;
using SmartHealthcare.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthcare.Service.Doctor
{
    /// <summary>
    /// 医生服务接口
    /// </summary>
    public interface IDoctorService
    {
        /// <summary>
        /// 获取医生信息
        /// </summary>
        /// <returns></returns>
        List<Tb_sys_DoctorInfo> GetDoctorList();

        /// <summary>
        /// 医生登录
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        int SelectDoctorLogin(string phone);

        /// <summary>
        /// 医生注册
        /// </summary>
        /// <param name="doctor">用户视图模型</param>
        /// <returns></returns>
        int CreateDoctorInfo(Tb_sys_DoctorInfoViewModel doctor);
    }
}
