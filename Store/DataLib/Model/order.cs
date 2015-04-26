﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Store
{
    /// <summary>订单</summary>
    [Serializable]
    [DataObject]
    [Description("订单")]
    [BindIndex("PRIMARY", true, "Id")]
    [BindIndex("IX_order_CommodityId", false, "CommodityId")]
    [BindRelation("CommodityId", false, "commodity", "Id")]
    [BindRelation("Id", true, "orderattachment", "OrderId")]
    [BindTable("order", Description = "订单", ConnName = "ConnName", DbType = DatabaseType.MySql)]
    public partial class order : Iorder
    {
        #region 属性
        private Int32 _Id;
        /// <summary>序号</summary>
        [DisplayName("序号")]
        [Description("序号")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "Id", "序号", null, "int(11)", 10, 0, false)]
        public virtual Int32 Id
        {
            get { return _Id; }
            set { if (OnPropertyChanging(__.Id, value)) { _Id = value; OnPropertyChanged(__.Id); } }
        }

        private Int16 _CommodityId;
        /// <summary>商品序号</summary>
        [DisplayName("商品序号")]
        [Description("商品序号")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn(2, "CommodityId", "商品序号", null, "smallint(4)", 5, 0, false)]
        public virtual Int16 CommodityId
        {
            get { return _CommodityId; }
            set { if (OnPropertyChanging(__.CommodityId, value)) { _CommodityId = value; OnPropertyChanged(__.CommodityId); } }
        }

        private String _Taobao;
        /// <summary>买家账户</summary>
        [DisplayName("买家账户")]
        [Description("买家账户")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(3, "Taobao", "买家账户", "", "varchar(20)", 0, 0, false)]
        public virtual String Taobao
        {
            get { return _Taobao; }
            set { if (OnPropertyChanging(__.Taobao, value)) { _Taobao = value; OnPropertyChanged(__.Taobao); } }
        }

        private String _Truename;
        /// <summary>买家姓名</summary>
        [DisplayName("买家姓名")]
        [Description("买家姓名")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(4, "Truename", "买家姓名", "", "varchar(20)", 0, 0, false)]
        public virtual String Truename
        {
            get { return _Truename; }
            set { if (OnPropertyChanging(__.Truename, value)) { _Truename = value; OnPropertyChanged(__.Truename); } }
        }

        private String _MobilePhone;
        /// <summary>买家手机</summary>
        [DisplayName("买家手机")]
        [Description("买家手机")]
        [DataObjectField(false, false, true, 15)]
        [BindColumn(5, "MobilePhone", "买家手机", "", "varchar(15)", 0, 0, false)]
        public virtual String MobilePhone
        {
            get { return _MobilePhone; }
            set { if (OnPropertyChanging(__.MobilePhone, value)) { _MobilePhone = value; OnPropertyChanged(__.MobilePhone); } }
        }

        private Decimal _SellingPrice;
        /// <summary>售价</summary>
        [DisplayName("售价")]
        [Description("售价")]
        [DataObjectField(false, false, true, 8)]
        [BindColumn(6, "SellingPrice", "售价", null, "decimal(8,3)", 8, 3, false)]
        public virtual Decimal SellingPrice
        {
            get { return _SellingPrice; }
            set { if (OnPropertyChanging(__.SellingPrice, value)) { _SellingPrice = value; OnPropertyChanged(__.SellingPrice); } }
        }

        private Decimal _RealPrice;
        /// <summary>实际售价</summary>
        [DisplayName("实际售价")]
        [Description("实际售价")]
        [DataObjectField(false, false, true, 8)]
        [BindColumn(7, "RealPrice", "实际售价", null, "decimal(8,3)", 8, 3, false)]
        public virtual Decimal RealPrice
        {
            get { return _RealPrice; }
            set { if (OnPropertyChanging(__.RealPrice, value)) { _RealPrice = value; OnPropertyChanged(__.RealPrice); } }
        }

        private Decimal _Profit;
        /// <summary>利润</summary>
        [DisplayName("利润")]
        [Description("利润")]
        [DataObjectField(false, false, true, 8)]
        [BindColumn(8, "Profit", "利润", null, "decimal(8,3)", 8, 3, false)]
        public virtual Decimal Profit
        {
            get { return _Profit; }
            set { if (OnPropertyChanging(__.Profit, value)) { _Profit = value; OnPropertyChanged(__.Profit); } }
        }

        private Decimal _Cost;
        /// <summary>成本</summary>
        [DisplayName("成本")]
        [Description("成本")]
        [DataObjectField(false, false, true, 8)]
        [BindColumn(9, "Cost", "成本", null, "decimal(8,3)", 8, 3, false)]
        public virtual Decimal Cost
        {
            get { return _Cost; }
            set { if (OnPropertyChanging(__.Cost, value)) { _Cost = value; OnPropertyChanged(__.Cost); } }
        }

        private DateTime _OrderTime;
        /// <summary></summary>
        [DisplayName("OrderTime")]
        [Description("")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn(10, "OrderTime", "", null, "datetime", 0, 0, false)]
        public virtual DateTime OrderTime
        {
            get { return _OrderTime; }
            set { if (OnPropertyChanging(__.OrderTime, value)) { _OrderTime = value; OnPropertyChanged(__.OrderTime); } }
        }

        private DateTime _RefreshTime;
        /// <summary></summary>
        [DisplayName("RefreshTime")]
        [Description("")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn(11, "RefreshTime", "", null, "datetime", 0, 0, false)]
        public virtual DateTime RefreshTime
        {
            get { return _RefreshTime; }
            set { if (OnPropertyChanging(__.RefreshTime, value)) { _RefreshTime = value; OnPropertyChanged(__.RefreshTime); } }
        }

        private SByte _IsCashGift;
        /// <summary>是否礼品折现</summary>
        [DisplayName("是否礼品折现")]
        [Description("是否礼品折现")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(12, "IsCashGift", "是否礼品折现", null, "tinyint(4)", 3, 0, false)]
        public virtual SByte IsCashGift
        {
            get { return _IsCashGift; }
            set { if (OnPropertyChanging(__.IsCashGift, value)) { _IsCashGift = value; OnPropertyChanged(__.IsCashGift); } }
        }

        private Decimal _CashGift;
        /// <summary></summary>
        [DisplayName("CashGift")]
        [Description("")]
        [DataObjectField(false, false, true, 6)]
        [BindColumn(13, "CashGift", "", null, "decimal(6,2)", 6, 2, false)]
        public virtual Decimal CashGift
        {
            get { return _CashGift; }
            set { if (OnPropertyChanging(__.CashGift, value)) { _CashGift = value; OnPropertyChanged(__.CashGift); } }
        }

        private SByte _IsCashback1;
        /// <summary>是否好评返现</summary>
        [DisplayName("是否好评返现")]
        [Description("是否好评返现")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(14, "IsCashback1", "是否好评返现", null, "tinyint(4)", 3, 0, false)]
        public virtual SByte IsCashback1
        {
            get { return _IsCashback1; }
            set { if (OnPropertyChanging(__.IsCashback1, value)) { _IsCashback1 = value; OnPropertyChanged(__.IsCashback1); } }
        }

        private Decimal _Cashback1;
        /// <summary>好评返现</summary>
        [DisplayName("好评返现")]
        [Description("好评返现")]
        [DataObjectField(false, false, true, 6)]
        [BindColumn(15, "Cashback1", "好评返现", null, "decimal(6,2)", 6, 2, false)]
        public virtual Decimal Cashback1
        {
            get { return _Cashback1; }
            set { if (OnPropertyChanging(__.Cashback1, value)) { _Cashback1 = value; OnPropertyChanged(__.Cashback1); } }
        }

        private SByte _IsCashback2;
        /// <summary>是否追加返现</summary>
        [DisplayName("是否追加返现")]
        [Description("是否追加返现")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(16, "IsCashback2", "是否追加返现", null, "tinyint(4)", 3, 0, false)]
        public virtual SByte IsCashback2
        {
            get { return _IsCashback2; }
            set { if (OnPropertyChanging(__.IsCashback2, value)) { _IsCashback2 = value; OnPropertyChanged(__.IsCashback2); } }
        }

        private Decimal _Cashback2;
        /// <summary>追加返现金额</summary>
        [DisplayName("追加返现金额")]
        [Description("追加返现金额")]
        [DataObjectField(false, false, true, 6)]
        [BindColumn(17, "Cashback2", "追加返现金额", null, "decimal(6,2)", 6, 2, false)]
        public virtual Decimal Cashback2
        {
            get { return _Cashback2; }
            set { if (OnPropertyChanging(__.Cashback2, value)) { _Cashback2 = value; OnPropertyChanged(__.Cashback2); } }
        }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(18, "Remark", "备注", "", "varchar(50)", 0, 0, false)]
        public virtual String Remark
        {
            get { return _Remark; }
            set { if (OnPropertyChanging(__.Remark, value)) { _Remark = value; OnPropertyChanged(__.Remark); } }
        }
        #endregion

        #region 获取/设置 字段值
        /// <summary>
        /// 获取/设置 字段值。
        /// 一个索引，基类使用反射实现。
        /// 派生实体类可重写该索引，以避免反射带来的性能损耗
        /// </summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public override Object this[String name]
        {
            get
            {
                switch (name)
                {
                    case __.Id : return _Id;
                    case __.CommodityId : return _CommodityId;
                    case __.Taobao : return _Taobao;
                    case __.Truename : return _Truename;
                    case __.MobilePhone : return _MobilePhone;
                    case __.SellingPrice : return _SellingPrice;
                    case __.RealPrice : return _RealPrice;
                    case __.Profit : return _Profit;
                    case __.Cost : return _Cost;
                    case __.OrderTime : return _OrderTime;
                    case __.RefreshTime : return _RefreshTime;
                    case __.IsCashGift : return _IsCashGift;
                    case __.CashGift : return _CashGift;
                    case __.IsCashback1 : return _IsCashback1;
                    case __.Cashback1 : return _Cashback1;
                    case __.IsCashback2 : return _IsCashback2;
                    case __.Cashback2 : return _Cashback2;
                    case __.Remark : return _Remark;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.Id : _Id = Convert.ToInt32(value); break;
                    case __.CommodityId : _CommodityId = Convert.ToInt16(value); break;
                    case __.Taobao : _Taobao = Convert.ToString(value); break;
                    case __.Truename : _Truename = Convert.ToString(value); break;
                    case __.MobilePhone : _MobilePhone = Convert.ToString(value); break;
                    case __.SellingPrice : _SellingPrice = Convert.ToDecimal(value); break;
                    case __.RealPrice : _RealPrice = Convert.ToDecimal(value); break;
                    case __.Profit : _Profit = Convert.ToDecimal(value); break;
                    case __.Cost : _Cost = Convert.ToDecimal(value); break;
                    case __.OrderTime : _OrderTime = Convert.ToDateTime(value); break;
                    case __.RefreshTime : _RefreshTime = Convert.ToDateTime(value); break;
                    case __.IsCashGift : _IsCashGift = Convert.ToSByte(value); break;
                    case __.CashGift : _CashGift = Convert.ToDecimal(value); break;
                    case __.IsCashback1 : _IsCashback1 = Convert.ToSByte(value); break;
                    case __.Cashback1 : _Cashback1 = Convert.ToDecimal(value); break;
                    case __.IsCashback2 : _IsCashback2 = Convert.ToSByte(value); break;
                    case __.Cashback2 : _Cashback2 = Convert.ToDecimal(value); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得订单字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>序号</summary>
            public static readonly Field Id = FindByName(__.Id);

            ///<summary>商品序号</summary>
            public static readonly Field CommodityId = FindByName(__.CommodityId);

            ///<summary>买家账户</summary>
            public static readonly Field Taobao = FindByName(__.Taobao);

            ///<summary>买家姓名</summary>
            public static readonly Field Truename = FindByName(__.Truename);

            ///<summary>买家手机</summary>
            public static readonly Field MobilePhone = FindByName(__.MobilePhone);

            ///<summary>售价</summary>
            public static readonly Field SellingPrice = FindByName(__.SellingPrice);

            ///<summary>实际售价</summary>
            public static readonly Field RealPrice = FindByName(__.RealPrice);

            ///<summary>利润</summary>
            public static readonly Field Profit = FindByName(__.Profit);

            ///<summary>成本</summary>
            public static readonly Field Cost = FindByName(__.Cost);

            ///<summary></summary>
            public static readonly Field OrderTime = FindByName(__.OrderTime);

            ///<summary></summary>
            public static readonly Field RefreshTime = FindByName(__.RefreshTime);

            ///<summary>是否礼品折现</summary>
            public static readonly Field IsCashGift = FindByName(__.IsCashGift);

            ///<summary></summary>
            public static readonly Field CashGift = FindByName(__.CashGift);

            ///<summary>是否好评返现</summary>
            public static readonly Field IsCashback1 = FindByName(__.IsCashback1);

            ///<summary>好评返现</summary>
            public static readonly Field Cashback1 = FindByName(__.Cashback1);

            ///<summary>是否追加返现</summary>
            public static readonly Field IsCashback2 = FindByName(__.IsCashback2);

            ///<summary>追加返现金额</summary>
            public static readonly Field Cashback2 = FindByName(__.Cashback2);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得订单字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary>序号</summary>
            public const String Id = "Id";

            ///<summary>商品序号</summary>
            public const String CommodityId = "CommodityId";

            ///<summary>买家账户</summary>
            public const String Taobao = "Taobao";

            ///<summary>买家姓名</summary>
            public const String Truename = "Truename";

            ///<summary>买家手机</summary>
            public const String MobilePhone = "MobilePhone";

            ///<summary>售价</summary>
            public const String SellingPrice = "SellingPrice";

            ///<summary>实际售价</summary>
            public const String RealPrice = "RealPrice";

            ///<summary>利润</summary>
            public const String Profit = "Profit";

            ///<summary>成本</summary>
            public const String Cost = "Cost";

            ///<summary></summary>
            public const String OrderTime = "OrderTime";

            ///<summary></summary>
            public const String RefreshTime = "RefreshTime";

            ///<summary>是否礼品折现</summary>
            public const String IsCashGift = "IsCashGift";

            ///<summary></summary>
            public const String CashGift = "CashGift";

            ///<summary>是否好评返现</summary>
            public const String IsCashback1 = "IsCashback1";

            ///<summary>好评返现</summary>
            public const String Cashback1 = "Cashback1";

            ///<summary>是否追加返现</summary>
            public const String IsCashback2 = "IsCashback2";

            ///<summary>追加返现金额</summary>
            public const String Cashback2 = "Cashback2";

            ///<summary>备注</summary>
            public const String Remark = "Remark";

        }
        #endregion
    }

    /// <summary>订单接口</summary>
    public partial interface Iorder
    {
        #region 属性
        /// <summary>序号</summary>
        Int32 Id { get; set; }

        /// <summary>商品序号</summary>
        Int16 CommodityId { get; set; }

        /// <summary>买家账户</summary>
        String Taobao { get; set; }

        /// <summary>买家姓名</summary>
        String Truename { get; set; }

        /// <summary>买家手机</summary>
        String MobilePhone { get; set; }

        /// <summary>售价</summary>
        Decimal SellingPrice { get; set; }

        /// <summary>实际售价</summary>
        Decimal RealPrice { get; set; }

        /// <summary>利润</summary>
        Decimal Profit { get; set; }

        /// <summary>成本</summary>
        Decimal Cost { get; set; }

        /// <summary></summary>
        DateTime OrderTime { get; set; }

        /// <summary></summary>
        DateTime RefreshTime { get; set; }

        /// <summary>是否礼品折现</summary>
        SByte IsCashGift { get; set; }

        /// <summary></summary>
        Decimal CashGift { get; set; }

        /// <summary>是否好评返现</summary>
        SByte IsCashback1 { get; set; }

        /// <summary>好评返现</summary>
        Decimal Cashback1 { get; set; }

        /// <summary>是否追加返现</summary>
        SByte IsCashback2 { get; set; }

        /// <summary>追加返现金额</summary>
        Decimal Cashback2 { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}