using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthcare.Domain
{
    /// <summary>
    /// 用户数据模型
    /// </summary>
    public class Tb_sys_UserInfo
    {
        private int userId; //用户id
        private string? userName; //用户姓名
        private string? userAdmin; //用户登录账号
        private string? userPass; //用户登录密码
        private int userAge; //用户年龄
        private int userSex; //用户性别
        private string? userIDCard; //用户身份证号
        private string? userPhone; //用户手机号        
        private int userDeleteState; //用户状态(逻辑删除)
        private string? userNumber; //用户编号
        private string? userAvatar; //用户头像
        private string? userHobby; //用户爱好
        private decimal userBalance; //用户余额
        private string? userAddress; //用户地址

        private DateTime creationTime; //创建日期
        private DateTime modificationTime; //修改日期
        private DateTime deletetime; //删除日期
        private string? creationPerson; //创建人
        private string? modificationPerson; //修改人
        private string? deletePerson; //删除人

        #region 用户id
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        #endregion
        #region 用户姓名
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string? UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        #endregion
        #region 用户登录账号
        /// <summary>
        /// 用户登录账号
        /// </summary>
        public string? UserAdmin
        {
            get { return userAdmin; }
            set { userAdmin = value; }
        }
        #endregion
        #region 用户登录密码
        /// <summary>
        /// 用户登录密码
        /// </summary>
        public string? UserPass
        {
            get { return userPass; }
            set { userPass = value; }
        }
        #endregion
        #region 用户年龄
        /// <summary>
        /// 用户年龄
        /// </summary>
        public int UserAge
        {
            get { return userAge; }
            set { userAge = value; }
        }
        #endregion
        #region 用户性别
        /// <summary>
        /// 用户性别
        /// </summary>
        public int UserSex
        {
            get { return userSex; }
            set { userSex = value; }
        }
        #endregion
        #region 用户身份证号
        /// <summary>
        /// 用户身份证号
        /// </summary>
        public string? UserIDCard
        {
            get { return userIDCard; }
            set { userIDCard = value; }
        }
        #endregion
        #region 用户手机号
        /// <summary>
        /// 用户手机号
        /// </summary>
        public string? UserPhone
        {
            get { return userPhone; }
            set { userPhone = value; }
        }
        #endregion
        #region 用户状态(逻辑删除)
        /// <summary>
        /// 用户状态(逻辑删除)
        /// </summary>
        public int UserDeleteState
        {
            get { return userDeleteState; }
            set { userDeleteState = value; }
        }
        #endregion
        #region 用户编号
        /// <summary>
        /// 用户编号
        /// </summary>
        public string? UserNumber
        {
            get { return userNumber; }
            set { userNumber = value; }
        }
        #endregion
        #region 用户头像
        /// <summary>
        /// 用户头像
        /// </summary>
        public string? UserAvatar
        {
            get { return userAvatar; }
            set { userAvatar = value; }
        }
        #endregion
        #region 用户爱好
        /// <summary>
        /// 用户爱好
        /// </summary>
        public string? UserHobby
        {
            get { return userHobby; }
            set { userHobby = value; }
        }
        #endregion
        #region 用户余额
        /// <summary>
        /// 用户余额
        /// </summary>
        public decimal UserBalance
        {
            get { return userBalance; }
            set { userBalance = value; }
        }
        #endregion
        #region 用户地址
        /// <summary>
        /// 用户地址
        /// </summary>
        public string? UserAddress
        {
            get { return userAddress; }
            set { userAddress = value; }
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
