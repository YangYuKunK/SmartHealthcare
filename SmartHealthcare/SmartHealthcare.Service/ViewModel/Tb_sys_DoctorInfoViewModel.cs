using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthcare.Service.ViewModel
{
    /// <summary>
    /// 医生视图模型
    /// </summary>
    public class Tb_sys_DoctorInfoViewModel
    {
        public int DoctorId { get; set; } //医生id
        public string? DoctorName { get; set; } //医生姓名
        public int HospitalId { get; set; } //所属医院
        public int PhysicianId { get; set; } //医生职称
        public string? UserPhone { get; set; } //手机号
        public string? UseridcardImg { get; set; } //身份证照片
        public string? CertificateImg { get; set; } //医师资格证
        public string? ProfessionalImg { get; set; } //医师执业证书
        public string? HospitalCode { get; set; } //所属科室
        public DateTime creationTime { get; set; }//创建日期
        public DateTime modificationTime { get; set; } //修改日期
        public DateTime deletetime { get; set; } //删除日期
        public string? creationPerson { get; set; } //创建人
        public string? modificationPerson { get; set; } //修改人
        public string? deletePerson { get; set; } //删除人
        public int UserSex { get; set; } //性别
        public int UserAge { get; set; } //年龄
    }
}
