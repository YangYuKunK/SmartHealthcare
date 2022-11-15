using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHealthcare.Domain
{
    /// <summary>
    /// 商品数据模型
    /// </summary>
    public class Tb_sys_GoodsInfo
    {
        private int goodsId; //商品id
        private string? goodsName; //商品名称
        private decimal goodsPrice; //商品价格
        private int goodsIsState; //是否有货
        private int goodsShelfState; //上下架
        private int goodsDeleteState; //是否删除
        private int goodsNumber; //存货数量
        private string? goodsImg; //商品图片
        private string? productID; //商品编码
        private string? goodsDescription; //商品简介
        private string? goodsSpecification; //商品规格
        private string? goodsServe; //售后服务
        private int typeId; //类别id
        private string? typeName; //类别名称

        private DateTime creationTime; //创建日期
        private DateTime modificationTime; //修改日期
        private DateTime deletetime; //删除日期
        private string? creationPerson; //创建人
        private string? modificationPerson; //修改人
        private string? deletePerson; //删除人

        #region 商品id
        /// <summary>
        /// 商品id
        /// </summary>
        public int GoodsId
        {
            get { return goodsId; }
            set { goodsId = value; }
        }
        #endregion
        #region 商品名称
        /// <summary>
        /// 商品名称
        /// </summary>
        public string? GoodsName
        {
            get { return goodsName; }
            set { goodsName = value; }
        }
        #endregion
        #region 商品价格
        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal GoodsPrice
        {
            get { return goodsPrice; }
            set { goodsPrice = value; }
        }
        #endregion
        #region 是否有货
        /// <summary>
        /// 是否有货
        /// </summary>
        public int GoodsIsState
        {
            get { return goodsIsState; }
            set { goodsIsState = value; }
        }
        #endregion
        #region 上下架
        /// <summary>
        /// 上下架
        /// </summary>
        public int GoodsShelfState
        {
            get { return goodsShelfState; }
            set { goodsShelfState = value; }
        }
        #endregion
        #region 是否删除
        /// <summary>
        /// 是否删除
        /// </summary>
        public int GoodsDeleteState
        {
            get { return goodsDeleteState; }
            set { goodsDeleteState = value; }
        }
        #endregion
        #region 存货数量
        /// <summary>
        /// 存货数量
        /// </summary>
        public int GoodsNumber
        {
            get { return goodsNumber; }
            set { goodsNumber = value; }
        }
        #endregion
        #region 商品图片
        /// <summary>
        /// 商品图片
        /// </summary>
        public string? GoodsImg
        {
            get { return goodsImg; }
            set { goodsImg = value; }
        }
        #endregion
        #region 商品编码
        /// <summary>
        /// 商品编码
        /// </summary>
        public string? GroductID
        {
            get { return productID; }
            set { productID = value; }
        }
        #endregion
        #region 商品简介
        /// <summary>
        /// 商品简介
        /// </summary>
        public string? GoodsDescription
        {
            get { return goodsDescription; }
            set { goodsDescription = value; }
        }
        #endregion
        #region 商品规格
        /// <summary>
        /// 商品规格
        /// </summary>
        public string? GoodsSpecification
        {
            get { return goodsSpecification; }
            set { goodsSpecification = value; }
        }
        #endregion
        #region 售后服务
        /// <summary>
        /// 售后服务
        /// </summary>
        public string? GoodsServe
        {
            get { return goodsServe; }
            set { goodsServe = value; }
        }
        #endregion
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
