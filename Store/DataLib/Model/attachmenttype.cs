﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Store
{
    /// <summary>返现类型</summary>
    [Serializable]
    [DataObject]
    [Description("返现类型")]
    [BindIndex("PRIMARY", true, "Id")]
    [BindRelation("Id", true, "orderattachment", "AttachmentTypeId")]
    [BindTable("attachmenttype", Description = "返现类型", ConnName = "ConnName", DbType = DatabaseType.MySql)]
    public partial class attachmenttype : Iattachmenttype
    {
        #region 属性
        private SByte _Id;
        /// <summary></summary>
        [DisplayName("Id")]
        [Description("")]
        [DataObjectField(true, true, false, 3)]
        [BindColumn(1, "Id", "", null, "tinyint(4)", 3, 0, false)]
        public virtual SByte Id
        {
            get { return _Id; }
            set { if (OnPropertyChanging(__.Id, value)) { _Id = value; OnPropertyChanged(__.Id); } }
        }

        private String _Name;
        /// <summary>名称</summary>
        [DisplayName("名称")]
        [Description("名称")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(2, "Name", "名称", "", "varchar(20)", 0, 0, false)]
        public virtual String Name
        {
            get { return _Name; }
            set { if (OnPropertyChanging(__.Name, value)) { _Name = value; OnPropertyChanged(__.Name); } }
        }

        private Decimal _Money;
        /// <summary>金额</summary>
        [DisplayName("金额")]
        [Description("金额")]
        [DataObjectField(false, false, true, 6)]
        [BindColumn(3, "Money", "金额", null, "decimal(6,2)", 6, 2, false)]
        public virtual Decimal Money
        {
            get { return _Money; }
            set { if (OnPropertyChanging(__.Money, value)) { _Money = value; OnPropertyChanged(__.Money); } }
        }

        private String _Requirement;
        /// <summary>要求</summary>
        [DisplayName("要求")]
        [Description("要求")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(4, "Requirement", "要求", "", "varchar(10)", 0, 0, false)]
        public virtual String Requirement
        {
            get { return _Requirement; }
            set { if (OnPropertyChanging(__.Requirement, value)) { _Requirement = value; OnPropertyChanged(__.Requirement); } }
        }

        private String _Remark;
        /// <summary></summary>
        [DisplayName("Remark")]
        [Description("")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(5, "Remark", "", "", "varchar(20)", 0, 0, false)]
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
                    case __.Money : return _Money;
                    case __.Requirement : return _Requirement;
                    case __.Remark : return _Remark;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.Id : _Id = Convert.ToSByte(value); break;
                    case __.Name : _Name = Convert.ToString(value); break;
                    case __.Money : _Money = Convert.ToDecimal(value); break;
                    case __.Requirement : _Requirement = Convert.ToString(value); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得返现类型字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary></summary>
            public static readonly Field Id = FindByName(__.Id);

            ///<summary>名称</summary>
            public static readonly Field Name = FindByName(__.Name);

            ///<summary>金额</summary>
            public static readonly Field Money = FindByName(__.Money);

            ///<summary>要求</summary>
            public static readonly Field Requirement = FindByName(__.Requirement);

            ///<summary></summary>
            public static readonly Field Remark = FindByName(__.Remark);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得返现类型字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String Id = "Id";

            ///<summary>名称</summary>
            public const String Name = "Name";

            ///<summary>金额</summary>
            public const String Money = "Money";

            ///<summary>要求</summary>
            public const String Requirement = "Requirement";

            ///<summary></summary>
            public const String Remark = "Remark";

        }
        #endregion
    }

    /// <summary>返现类型接口</summary>
    public partial interface Iattachmenttype
    {
        #region 属性
        /// <summary></summary>
        SByte Id { get; set; }

        /// <summary>名称</summary>
        String Name { get; set; }

        /// <summary>金额</summary>
        Decimal Money { get; set; }

        /// <summary>要求</summary>
        String Requirement { get; set; }

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