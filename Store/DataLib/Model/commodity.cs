﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Store
{
    /// <summary>进货清单</summary>
    [Serializable]
    [DataObject]
    [Description("进货清单")]
    [BindIndex("PRIMARY", true, "Id")]
    [BindRelation("Id", true, "order", "CommodityId")]
    [BindTable("commodity", Description = "进货清单", ConnName = "ConnName", DbType = DatabaseType.MySql)]
    public partial class commodity : Icommodity
    {
        #region 属性
        private Int16 _Id;
        /// <summary></summary>
        [DisplayName("Id")]
        [Description("")]
        [DataObjectField(true, true, false, 5)]
        [BindColumn(1, "Id", "", null, "smallint(6)", 5, 0, false)]
        public virtual Int16 Id
        {
            get { return _Id; }
            set { if (OnPropertyChanging(__.Id, value)) { _Id = value; OnPropertyChanged(__.Id); } }
        }

        private String _Name;
        /// <summary>商品名称</summary>
        [DisplayName("商品名称")]
        [Description("商品名称")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(2, "Name", "商品名称", "", "varchar(20)", 0, 0, false)]
        public virtual String Name
        {
            get { return _Name; }
            set { if (OnPropertyChanging(__.Name, value)) { _Name = value; OnPropertyChanged(__.Name); } }
        }

        private String _Type;
        /// <summary>类型</summary>
        [DisplayName("类型")]
        [Description("类型")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(3, "Type", "类型", "", "varchar(20)", 0, 0, false)]
        public virtual String Type
        {
            get { return _Type; }
            set { if (OnPropertyChanging(__.Type, value)) { _Type = value; OnPropertyChanged(__.Type); } }
        }

        private String _Color;
        /// <summary>颜色</summary>
        [DisplayName("颜色")]
        [Description("颜色")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(4, "Color", "颜色", "", "varchar(10)", 0, 0, false)]
        public virtual String Color
        {
            get { return _Color; }
            set { if (OnPropertyChanging(__.Color, value)) { _Color = value; OnPropertyChanged(__.Color); } }
        }

        private Decimal _RealPrice;
        /// <summary>进价</summary>
        [DisplayName("进价")]
        [Description("进价")]
        [DataObjectField(false, false, true, 8)]
        [BindColumn(5, "RealPrice", "进价", null, "decimal(8,3)", 8, 3, false)]
        public virtual Decimal RealPrice
        {
            get { return _RealPrice; }
            set { if (OnPropertyChanging(__.RealPrice, value)) { _RealPrice = value; OnPropertyChanged(__.RealPrice); } }
        }

        private Int16 _Amount;
        /// <summary>进货数量</summary>
        [DisplayName("进货数量")]
        [Description("进货数量")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn(6, "Amount", "进货数量", null, "smallint(6)", 5, 0, false)]
        public virtual Int16 Amount
        {
            get { return _Amount; }
            set { if (OnPropertyChanging(__.Amount, value)) { _Amount = value; OnPropertyChanged(__.Amount); } }
        }

        private Int16 _Remain;
        /// <summary>剩余数量</summary>
        [DisplayName("剩余数量")]
        [Description("剩余数量")]
        [DataObjectField(false, false, true, 5)]
        [BindColumn(7, "Remain", "剩余数量", null, "smallint(6)", 5, 0, false)]
        public virtual Int16 Remain
        {
            get { return _Remain; }
            set { if (OnPropertyChanging(__.Remain, value)) { _Remain = value; OnPropertyChanged(__.Remain); } }
        }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn(8, "CreateTime", "创建时间", null, "datetime", 0, 0, false)]
        public virtual DateTime CreateTime
        {
            get { return _CreateTime; }
            set { if (OnPropertyChanging(__.CreateTime, value)) { _CreateTime = value; OnPropertyChanged(__.CreateTime); } }
        }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(9, "Remark", "备注", "", "varchar(20)", 0, 0, false)]
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
                    case __.Name : return _Name;
                    case __.Type : return _Type;
                    case __.Color : return _Color;
                    case __.RealPrice : return _RealPrice;
                    case __.Amount : return _Amount;
                    case __.Remain : return _Remain;
                    case __.CreateTime : return _CreateTime;
                    case __.Remark : return _Remark;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.Id : _Id = Convert.ToInt16(value); break;
                    case __.Name : _Name = Convert.ToString(value); break;
                    case __.Type : _Type = Convert.ToString(value); break;
                    case __.Color : _Color = Convert.ToString(value); break;
                    case __.RealPrice : _RealPrice = Convert.ToDecimal(value); break;
                    case __.Amount : _Amount = Convert.ToInt16(value); break;
                    case __.Remain : _Remain = Convert.ToInt16(value); break;
                    case __.CreateTime : _CreateTime = Convert.ToDateTime(value); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得进货清单字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary></summary>
            public static readonly Field Id = FindByName(__.Id);

            ///<summary>商品名称</summary>
            public static readonly Field Name = FindByName(__.Name);

            ///<summary>类型</summary>
            public static readonly Field Type = FindByName(__.Type);

            ///<summary>颜色</summary>
            public static readonly Field Color = FindByName(__.Color);

            ///<summary>进价</summary>
            public static readonly Field RealPrice = FindByName(__.RealPrice);

            ///<summary>进货数量</summary>
            public static readonly Field Amount = FindByName(__.Amount);

            ///<summary>剩余数量</summary>
            public static readonly Field Remain = FindByName(__.Remain);

            ///<summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName(__.CreateTime);

            ///<summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得进货清单字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String Id = "Id";

            ///<summary>商品名称</summary>
            public const String Name = "Name";

            ///<summary>类型</summary>
            public const String Type = "Type";

            ///<summary>颜色</summary>
            public const String Color = "Color";

            ///<summary>进价</summary>
            public const String RealPrice = "RealPrice";

            ///<summary>进货数量</summary>
            public const String Amount = "Amount";

            ///<summary>剩余数量</summary>
            public const String Remain = "Remain";

            ///<summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            ///<summary>备注</summary>
            public const String Remark = "Remark";

        }
        #endregion
    }

    /// <summary>进货清单接口</summary>
    public partial interface Icommodity
    {
        #region 属性
        /// <summary></summary>
        Int16 Id { get; set; }

        /// <summary>商品名称</summary>
        String Name { get; set; }

        /// <summary>类型</summary>
        String Type { get; set; }

        /// <summary>颜色</summary>
        String Color { get; set; }

        /// <summary>进价</summary>
        Decimal RealPrice { get; set; }

        /// <summary>进货数量</summary>
        Int16 Amount { get; set; }

        /// <summary>剩余数量</summary>
        Int16 Remain { get; set; }

        /// <summary>创建时间</summary>
        DateTime CreateTime { get; set; }

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