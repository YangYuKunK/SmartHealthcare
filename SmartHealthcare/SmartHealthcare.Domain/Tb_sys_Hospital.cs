using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthcare.Domain
{
    /// <summary>
    /// 医院数据模型
    /// </summary>
    public class Tb_sys_Hospital
    {
        private int hospitalId; //医院id
        private string? hospitalName; //医院名称
        private string? hospitalCode; //医院编码
        private int hospitalPId; //医院父级id

        private DateTime creationTime; //创建日期
        private DateTime modificationTime; //修改日期
        private DateTime deletetime; //删除日期
        private string? creationPerson; //创建人
        private string? modificationPerson; //修改人
        private string? deletePerson; //删除人

        #region 医院id
        /// <summary>
        /// 医院id
        /// </summary>
        public int HospitalId
        {
            get { return hospitalId; }
            set { hospitalId = value; }
        }
        #endregion
        #region 医院名称
        /// <summary>
        /// 医院名称
        /// </summary>
        public string? HospitalName
        {
            get { return hospitalName; }
            set { hospitalName = value; }
        }
        #endregion
        #region 医院编码
        /// <summary>
        /// 医院编码
        /// </summary>
        public string? HospitalCode
        {
            get { return hospitalCode; }
            set { hospitalCode = value; }
        }
        #endregion
        #region 医院父级id
        /// <summary>
        /// 医院父级id
        /// </summary>
        public int HospitalPId
        {
            get { return hospitalPId; }
            set { hospitalPId = value; }
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
    }
}
