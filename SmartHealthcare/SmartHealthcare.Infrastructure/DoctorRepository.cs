using SmartHealthcare.Domain;
using SmartHealthcare.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SmartHealthcare.Infrastructure
{
    /// <summary>
    /// 医生仓储实践
    /// </summary>
    public class DoctorRepository : IDoctorRepository
    {
        /// <summary>
        /// 获取医生信息
        /// </summary>
        /// <returns></returns>
        public List<Tb_sys_DoctorInfo> GetDoctorList()
        {
            string str = "select * from tb_sys_DoctorInfo";
            return Dapper<Tb_sys_DoctorInfo>.Query(str);
        }

        /// <summary>
        /// 医生登录
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns></returns>
        public Tb_sys_DoctorInfo SelectDoctorLogin(string phone)
        {
            string str = "select * from tb_sys_DoctorInfo where userphone = @userphone";
            return Dapper<Tb_sys_DoctorInfo>.QueryFirst(str, new
            {
                userphone = phone //手机号
            });
        }
        /// <summary>
        /// 查询用户当中是否存在当前手机号
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns></returns>
        public Tb_sys_UserInfo SelectUserLogin(string phone)
        {
            string str = "select * from tb_sys_UserInfo where userphone = @userphone";
            return Dapper<Tb_sys_UserInfo>.QueryFirst(str, new
            {
                userphone = phone //手机号
            });
        }

        /// <summary>
        /// 医生注册
        /// </summary>
        /// <param name="doctor">医生数据模型</param>
        /// <returns></returns>
        public int CreateDoctorInfo(Tb_sys_DoctorInfo doctor)
        {
            string str = "insert into tb_sys_DoctorInfo (Doctorid,Doctorname,hospitalid,physicianid,userphone,useridcardimg,certificateimg,professionalimg,hospitalcode,creationtime,modificationtime,deletetime,creationperson,modificationperson,deleteperson) values (null,@name,@hid,@pid,@phone,@userimg,@certimg,@proimg,@code,@addtime,@upttime,@deltime,@addren,@uptren,@delren);" +
                "insert into tb_sys_userinfo (userid,username,useradmin,userpass,userage,usersex,useridcard,userphone,userdeletestate,usernumber,useravatar,userhobby,userbalance,useraddress,creationtime,modificationtime,deletetime,creationperson,modificationperson,deleteperson) values (null,@username,@admin,@pass,@age,@sex,@idcard,@phone,@state,@number,@img,@hobby,@money,@dress,@createdate,@updatetime,@deletetime,@createname,@updatename,@deletename);";
            return Dapper<int>.RUD(str, new
            {
                //医生
                name = doctor.DoctorName, //医生名称
                hid = doctor.HospitalId, //所属医院
                pid = doctor.PhysicianId, //医生职称
                phone = doctor.UserPhone, //手机号
                userimg = doctor.UseridcardImg, //身份证照片
                certimg = doctor.CertificateImg, //医师资格证
                proimg = doctor.ProfessionalImg, //医师执业证书
                code = doctor.HospitalCode, //所属科室
                addtime = doctor.CreationTime, //创建时间
                upttime = doctor.ModificationTime, //修改时间
                deltime = doctor.Deletetime, //删除时间
                addren = doctor.CreationPerson, //创建人
                uptren = doctor.ModificationPerson, //修改人
                delren = doctor.DeletePerson, //删除人

                //用户
                username = doctor.DoctorName, //用户姓名
                admin = "", //用户登录账号
                pass = "", //用户登录密码
                age = doctor.UserAge, //用户年龄
                sex = doctor.UserSex, //用户性别
                idcard = "", //用户身份证号
                phone1 = doctor.UserPhone, //用户手机号
                state = 0, //逻辑删除
                number = "", //用户编号
                img = "", //用户头像
                hobby = "", //用户爱好
                money = 0, //用户余额
                dress = "", //用户地址
                createdate = DateTime.Now, //创建时间
                updatetime = doctor.ModificationTime, //修改时间
                deletetime = doctor.Deletetime, //删除时间
                createname = doctor.DoctorName, //创建人
                updatename = "", //修改人
                deletename = "" //删除人
            });
        }
        /// <summary>
        /// 插入用户角色信息
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="doctor"></param>
        /// <returns></returns>
        public int SelectUserInfo(string? phone, Tb_sys_DoctorInfo doctor)
        {
            string str = "select * from Tb_sys_UserInfo where UserPhone = @uphone";
            Tb_sys_UserInfo user = Dapper<Tb_sys_UserInfo>.QueryFirst(str, new
            {
                uphone = phone //手机号
            });
            str = "insert into tb_sys_userrole (userid,roleid) values (@uid,@rid)";
            return Dapper<int>.RUD(str, new
            {
                uid = user.UserId, //用户id
                rid = 2 //角色id
            });
        }
    }
}
