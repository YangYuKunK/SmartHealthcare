using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthcare.Domain
{
    /// <summary>
    /// 医生职称数据模型
    /// </summary>
    public class Tb_sys_PhysicianTitle
    {
        private int physicianId; //医生职称id
        private string? physicianName; //医生职称名称

        #region 医生职称id
        /// <summary>
        /// 医生职称id
        /// </summary>
        public int PhysicianId
        {
            get { return physicianId; }
            set { physicianId = value; }
        }
        #endregion
        #region 医生职称名称
        /// <summary>
        /// 医生职称名称
        /// </summary>
        public string? PhysicianName
        {
            get { return physicianName; }
            set { physicianName = value; }
        }
        #endregion
    }
}
