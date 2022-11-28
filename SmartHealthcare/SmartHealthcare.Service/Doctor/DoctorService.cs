using AutoMapper;
using SmartHealthcare.Domain;
using SmartHealthcare.Interface;
using SmartHealthcare.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthcare.Service.Doctor
{
    /// <summary>
    /// 医生服务实践
    /// </summary>
    public class DoctorService : IDoctorService
    {
        /// <summary>
        /// 依赖注入
        /// </summary>
        IDoctorRepository _doctor;
        IMapper _mapper;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="doctor">医生仓储接口</param>
        /// <param name="mapper">AutoMapper</param>
        public DoctorService(IDoctorRepository doctor, IMapper mapper)
        {
            _doctor = doctor;
            _mapper = mapper;
        }


        /// <summary>
        /// 获取医生信息
        /// </summary>
        /// <returns></returns>
        public List<Tb_sys_DoctorInfo> GetDoctorList()
        {
            //获取医生信息
            List<Tb_sys_DoctorInfo> doctor = _doctor.GetDoctorList();
            //返回数据
            return doctor;
        }

        /// <summary>
        /// 医生登录
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns></returns>
        public int SelectDoctorLogin(string phone)
        {
            //捕获异常
            try
            {
                int i = 0;
                //根据手机号查看是否登录成功
                Tb_sys_DoctorInfo doctor = _doctor.SelectDoctorLogin(phone);
                //查询用户信息中是否存在当前手机号
                Tb_sys_UserInfo user = _doctor.SelectUserLogin(phone);
                
                
                //查看数据是否为空
                if (doctor.DoctorId != 0)
                {
                    //判断手机号、姓名等信息是否相等
                    if (doctor.DoctorName == user.UserName)
                    {
                        if (doctor.UserPhone == user.UserPhone)
                        {
                            i = 1;
                            return i;
                        }
                        else
                        {
                            return i;
                        }
                    }
                    else
                    {
                        //返回数据
                        return i;
                    }
                }
                else
                {
                    //返回数据
                    return i;
                }
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("医生登录异常", ex);
            }
        }

        /// <summary>
        /// 医生注册
        /// </summary>
        /// <param name="doctor">用户视图模型</param>
        /// <returns></returns>
        public int CreateDoctorInfo(Tb_sys_DoctorInfoViewModel doctorv)
        {
            //捕获异常
            try
            {
                //进行模型映射
                Tb_sys_DoctorInfo doctor = _mapper.Map<Tb_sys_DoctorInfo>(doctorv);
                //医生注册信息
                int i = _doctor.CreateDoctorInfo(doctor);
                //查询医生和用户信息讲信息插入进用户角色表
                int a = _doctor.SelectUserInfo(doctor.UserPhone,doctor);
               
                //判断医生是否注册成功
                if (i > 0)
                {
                    //返回数据
                    return i;
                }
                else
                {
                    //返回数据
                    return i;
                }
            }
            catch (Exception ex)
            {
                //抛出异常
                throw new Exception("医生注册异常", ex);
            }
        }
    }
}
