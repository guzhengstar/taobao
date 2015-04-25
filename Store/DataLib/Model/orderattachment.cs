﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Store
{
    /// <summary>返现列表</summary>
    [Serializable]
    [DataObject]
    [Description("返现列表")]
    [BindIndex("PRIMARY", true, "Id")]
    [BindIndex("IX_orderattachment_AttachmentTypeId", false, "AttachmentTypeId")]
    [BindIndex("IX_orderattachment_OrderId", false, "OrderId")]
    [BindRelation("AttachmentTypeId", false, "attachmenttype", "Id")]
    [BindRelation("OrderId", false, "order", "Id")]
    [BindTable("orderattachment", Description = "返现列表", ConnName = "ConnName", DbType = DatabaseType.MySql)]
    public partial class orderattachment : Iorderattachment
    {
        #region 属性
        private Int32 _Id;
        /// <summary></summary>
        [DisplayName("Id")]
        [Description("")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "Id", "", null, "int(11)", 10, 0, false)]
        public virtual Int32 Id
        {
            get { return _Id; }
            set { if (OnPropertyChanging(__.Id, value)) { _Id = value; OnPropertyChanged(__.Id); } }
        }

        private Int32 _OrderId;
        /// <summary>订单id</summary>
        [DisplayName("订单id")]
        [Description("订单id")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(2, "OrderId", "订单id", null, "int(11)", 10, 0, false)]
        public virtual Int32 OrderId
        {
            get { return _OrderId; }
            set { if (OnPropertyChanging(__.OrderId, value)) { _OrderId = value; OnPropertyChanged(__.OrderId); } }
        }

        private SByte _AttachmentTypeId;
        /// <summary>返现类型</summary>
        [DisplayName("返现类型")]
        [Description("返现类型")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(3, "AttachmentTypeId", "返现类型", null, "tinyint(4)", 3, 0, false)]
        public virtual SByte AttachmentTypeId
        {
            get { return _AttachmentTypeId; }
            set { if (OnPropertyChanging(__.AttachmentTypeId, value)) { _AttachmentTypeId = value; OnPropertyChanged(__.AttachmentTypeId); } }
        }

        private SByte _IsPaid;
        /// <summary></summary>
        [DisplayName("IsPaid")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(4, "IsPaid", "", null, "tinyint(4)", 3, 0, false)]
        public virtual SByte IsPaid
        {
            get { return _IsPaid; }
            set { if (OnPropertyChanging(__.IsPaid, value)) { _IsPaid = value; OnPropertyChanged(__.IsPaid); } }
        }

        private SByte _IsNeed;
        /// <summary></summary>
        [DisplayName("IsNeed")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(5, "IsNeed", "", null, "tinyint(4)", 3, 0, false)]
        public virtual SByte IsNeed
        {
            get { return _IsNeed; }
            set { if (OnPropertyChanging(__.IsNeed, value)) { _IsNeed = value; OnPropertyChanged(__.IsNeed); } }
        }

        private Decimal _Money;
        /// <summary></summary>
        [DisplayName("Money")]
        [Description("")]
        [DataObjectField(false, false, true, 6)]
        [BindColumn(6, "Money", "", null, "decimal(6,2)", 6, 2, false)]
        public virtual Decimal Money
        {
            get { return _Money; }
            set { if (OnPropertyChanging(__.Money, value)) { _Money = value; OnPropertyChanged(__.Money); } }
        }

        private String _Remark;
        /// <summary></summary>
        [DisplayName("Remark")]
        [Description("")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(7, "Remark", "", "", "varchar(20)", 0, 0, false)]
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
                    case __.OrderId : return _OrderId;
                    case __.AttachmentTypeId : return _AttachmentTypeId;
                    case __.IsPaid : return _IsPaid;
                    case __.IsNeed : return _IsNeed;
                    case __.Money : return _Money;
                    case __.Remark : return _Remark;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.Id : _Id = Convert.ToInt32(value); break;
                    case __.OrderId : _OrderId = Convert.ToInt32(value); break;
                    case __.AttachmentTypeId : _AttachmentTypeId = Convert.ToSByte(value); break;
                    case __.IsPaid : _IsPaid = Convert.ToSByte(value); break;
                    case __.IsNeed : _IsNeed = Convert.ToSByte(value); break;
                    case __.Money : _Money = Convert.ToDecimal(value); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得返现列表字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary></summary>
            public static readonly Field Id = FindByName(__.Id);

            ///<summary>订单id</summary>
            public static readonly Field OrderId = FindByName(__.OrderId);

            ///<summary>返现类型</summary>
            public static readonly Field AttachmentTypeId = FindByName(__.AttachmentTypeId);

            ///<summary></summary>
            public static readonly Field IsPaid = FindByName(__.IsPaid);

            ///<summary></summary>
            public static readonly Field IsNeed = FindByName(__.IsNeed);

            ///<summary></summary>
            public static readonly Field Money = FindByName(__.Money);

            ///<summary></summary>
            public static readonly Field Remark = FindByName(__.Remark);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得返现列表字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String Id = "Id";

            ///<summary>订单id</summary>
            public const String OrderId = "OrderId";

            ///<summary>返现类型</summary>
            public const String AttachmentTypeId = "AttachmentTypeId";

            ///<summary></summary>
            public const String IsPaid = "IsPaid";

            ///<summary></summary>
            public const String IsNeed = "IsNeed";

            ///<summary></summary>
            public const String Money = "Money";

            ///<summary></summary>
            public const String Remark = "Remark";

        }
        #endregion
    }

    /// <summary>返现列表接口</summary>
    public partial interface Iorderattachment
    {
        #region 属性
        /// <summary></summary>
        Int32 Id { get; set; }

        /// <summary>订单id</summary>
        Int32 OrderId { get; set; }

        /// <summary>返现类型</summary>
        SByte AttachmentTypeId { get; set; }

        /// <summary></summary>
        SByte IsPaid { get; set; }

        /// <summary></summary>
        SByte IsNeed { get; set; }

        /// <summary></summary>
        Decimal Money { get; set; }

        /// <summary></summary>
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