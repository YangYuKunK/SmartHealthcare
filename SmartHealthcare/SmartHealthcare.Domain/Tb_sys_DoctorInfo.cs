using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthcare.Domain
{
    /// <summary>
    /// 医生信息数据模型
    /// </summary>
    public class Tb_sys_DoctorInfo
    {
        private int doctorId; //医生id
        private string? doctorName; //医生姓名
        private int hospitalId; //所属医院
        private int physicianId; //医生职称
        private string? userPhone; //手机号
        private string? useridcardImg; //身份证照片
        private string? certificateImg; //医师资格证
        private string? professionalImg; //医师执业证书
        private string? hospitalCode; //所属科室

        private DateTime creationTime; //创建日期
        private DateTime modificationTime; //修改日期
        private DateTime deletetime; //删除日期
        private string? creationPerson; //创建人
        private string? modificationPerson; //修改人
        private string? deletePerson; //删除人

        private int userSex; //性别
        private int userAge; //年龄
        

        #region 医生id
        /// <summary>
        /// 医生id
        /// </summary>
        public int DoctorId
        {
            get { return doctorId; }
            set { doctorId = value; }
        }
        #endregion
        #region 医生姓名
        /// <summary>
        /// 医生姓名
        /// </summary>
        public string? DoctorName
        {
            get { return doctorName; }
            set { doctorName = value; }
        }
        #endregion
        #region 所属医院
        /// <summary>
        /// 所属医院
        /// </summary>
        public int HospitalId
        {
            get { return hospitalId; }
            set { hospitalId = value; }
        }
        #endregion
        #region 医生职称
        /// <summary>
        /// 医生职称
        /// </summary>
        public int PhysicianId
        {
            get { return physicianId; }
            set { physicianId = value; }
        }
        #endregion
        #region 手机号
        /// <summary>
        /// 手机号
        /// </summary>
        public string? UserPhone
        {
            get { return userPhone; }
            set { userPhone = value; }
        }
        #endregion
        #region 身份证照片
        /// <summary>
        /// 身份证照片
        /// </summary>
        public string? UseridcardImg
        {
            get { return useridcardImg; }
            set { useridcardImg = value; }
        }
        #endregion
        #region 医师资格证
        /// <summary>
        /// 医师资格证
        /// </summary>
        public string? CertificateImg
        {
            get { return certificateImg; }
            set { certificateImg = value; }
        }
        #endregion
        #region 医师执业证书
        /// <summary>
        /// 医师执业证书
        /// </summary>
        public string? ProfessionalImg
        {
            get { return professionalImg; }
            set { professionalImg = value; }
        }
        #endregion
        #region 所属科室
        /// <summary>
        /// 所属科室
        /// </summary>
        public string? HospitalCode
        {
            get { return hospitalCode; }
            set { hospitalCode = value; }
        }
        #endregion

        #region 创建日期
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreationTime
        {
            get { return creationTime; }
            set { creationTime = value; }
        }
        #endregion
        #region 修改日期
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime ModificationTime
        {
            get { return modificationTime; }
            set { modificationTime = value; }
        }
        #endregion
        #region 删除日期
        /// <summary>
        /// 删除日期
        /// </summary>
        public DateTime Deletetime
        {
            get { return deletetime; }
            set { deletetime = value; }
        }
        #endregion
        #region 创建人
        /// <summary>
        /// 创建人
        /// </summary>
        public string? CreationPerson
        {
            get { return creationPerson; }
            set { creationPerson = value; }
        }
        #endregion
        #region 修改人
        /// <summary>
        /// 修改人
        /// </summary>
        public string? ModificationPerson
        {
            get { return modificationPerson; }
            set { modificationPerson = value; }
        }
        #endregion
        #region 删除人
        /// <summary>
        /// 删除人
        /// </summary>
        public string? DeletePerson
        {
            get { return deletePerson; }
            set { deletePerson = value; }
        }
        #endregion

        #region 性别
        /// <summary>
        /// 性别
        /// </summary>
        public int UserSex
        {
            get { return userSex; }
            set { userSex = value; }
        }
        #endregion
        #region 年龄
        /// <summary>
        /// 年龄
        /// </summary>
        public int UserAge
        {
            get { return userAge; }
            set { userAge = value; }
        }
        #endregion
    }
}
