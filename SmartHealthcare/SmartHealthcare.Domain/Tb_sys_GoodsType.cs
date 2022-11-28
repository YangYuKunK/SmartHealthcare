using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthcare.Domain
{
    /// <summary>
    /// 商品类型数据模型
    /// </summary>
    public class Tb_sys_GoodsType
    {
        private int typeId; //类别id
        private string? typeName; //类别名称
        private int goodsTypeNumber; //类别商品剩余数量
        private string? typeImg; //商品分类图片

        private DateTime creationTime; //创建日期
        private DateTime modificationTime; //修改日期
        private DateTime deletetime; //删除日期
        private string? creationPerson; //创建人
        private string? modificationPerson; //修改人
        private string? deletePerson; //删除人

        #region 类别id
        /// <summary>
        /// 类别id
        /// </summary>
        public int TypeId
        {
            get { return typeId; }
            set { typeId = value; }
        }
        #endregion
        #region 类别名称
        /// <summary>
        /// 类别名称
        /// </summary>
        public string? TypeName
        {
            get { return typeName; }
            set { typeName = value; }
        }
        #endregion
        #region 类别商品剩余数量
        /// <summary>
        /// 类别商品剩余数量
        /// </summary>
        public int GoodsTypeNumber
        {
            get { return goodsTypeNumber; }
            set { goodsTypeNumber = value; }
        }
        #endregion
        #region 商品分类图片
        /// <summary>
        /// 商品分类图片
        /// </summary>
        public string? TypeImg
        {
            get { return typeImg; }
            set { typeImg = value; }
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
