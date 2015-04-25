﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace Store
{
    /// <summary>用户表</summary>
    [Serializable]
    [DataObject]
    [Description("用户表")]
    [BindIndex("PRIMARY", true, "Id")]
    [BindTable("admin", Description = "用户表", ConnName = "ConnName", DbType = DatabaseType.MySql)]
    public partial class admin : Iadmin
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

        private String _Username;
        /// <summary></summary>
        [DisplayName("Username")]
        [Description("")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(2, "Username", "", "", "varchar(20)", 0, 0, false)]
        public virtual String Username
        {
            get { return _Username; }
            set { if (OnPropertyChanging(__.Username, value)) { _Username = value; OnPropertyChanged(__.Username); } }
        }

        private String _Truename;
        /// <summary></summary>
        [DisplayName("Truename")]
        [Description("")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(3, "Truename", "", "", "varchar(20)", 0, 0, false)]
        public virtual String Truename
        {
            get { return _Truename; }
            set { if (OnPropertyChanging(__.Truename, value)) { _Truename = value; OnPropertyChanged(__.Truename); } }
        }

        private String _Password;
        /// <summary></summary>
        [DisplayName("Password")]
        [Description("")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn(4, "Password", "", "", "varchar(30)", 0, 0, false)]
        public virtual String Password
        {
            get { return _Password; }
            set { if (OnPropertyChanging(__.Password, value)) { _Password = value; OnPropertyChanged(__.Password); } }
        }

        private SByte _UserType;
        /// <summary></summary>
        [DisplayName("UserType")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(5, "UserType", "", null, "tinyint(4)", 3, 0, false)]
        public virtual SByte UserType
        {
            get { return _UserType; }
            set { if (OnPropertyChanging(__.UserType, value)) { _UserType = value; OnPropertyChanged(__.UserType); } }
        }

        private DateTime _LoginTime;
        /// <summary></summary>
        [DisplayName("LoginTime")]
        [Description("")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn(6, "LoginTime", "", null, "datetime", 0, 0, false)]
        public virtual DateTime LoginTime
        {
            get { return _LoginTime; }
            set { if (OnPropertyChanging(__.LoginTime, value)) { _LoginTime = value; OnPropertyChanged(__.LoginTime); } }
        }

        private String _Remark;
        /// <summary></summary>
        [DisplayName("Remark")]
        [Description("")]
        [DataObjectField(false, false, true, 30)]
        [BindColumn(7, "Remark", "", "", "varchar(30)", 0, 0, false)]
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
                    case __.Username : return _Username;
                    case __.Truename : return _Truename;
                    case __.Password : return _Password;
                    case __.UserType : return _UserType;
                    case __.LoginTime : return _LoginTime;
                    case __.Remark : return _Remark;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.Id : _Id = Convert.ToInt16(value); break;
                    case __.Username : _Username = Convert.ToString(value); break;
                    case __.Truename : _Truename = Convert.ToString(value); break;
                    case __.Password : _Password = Convert.ToString(value); break;
                    case __.UserType : _UserType = Convert.ToSByte(value); break;
                    case __.LoginTime : _LoginTime = Convert.ToDateTime(value); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得用户表字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary></summary>
            public static readonly Field Id = FindByName(__.Id);

            ///<summary></summary>
            public static readonly Field Username = FindByName(__.Username);

            ///<summary></summary>
            public static readonly Field Truename = FindByName(__.Truename);

            ///<summary></summary>
            public static readonly Field Password = FindByName(__.Password);

            ///<summary></summary>
            public static readonly Field UserType = FindByName(__.UserType);

            ///<summary></summary>
            public static readonly Field LoginTime = FindByName(__.LoginTime);

            ///<summary></summary>
            public static readonly Field Remark = FindByName(__.Remark);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得用户表字段名称的快捷方式</summary>
        partial class __
        {
            ///<summary></summary>
            public const String Id = "Id";

            ///<summary></summary>
            public const String Username = "Username";

            ///<summary></summary>
            public const String Truename = "Truename";

            ///<summary></summary>
            public const String Password = "Password";

            ///<summary></summary>
            public const String UserType = "UserType";

            ///<summary></summary>
            public const String LoginTime = "LoginTime";

            ///<summary></summary>
            public const String Remark = "Remark";

        }
        #endregion
    }

    /// <summary>用户表接口</summary>
    public partial interface Iadmin
    {
        #region 属性
        /// <summary></summary>
        Int16 Id { get; set; }

        /// <summary></summary>
        String Username { get; set; }

        /// <summary></summary>
        String Truename { get; set; }

        /// <summary></summary>
        String Password { get; set; }

        /// <summary></summary>
        SByte UserType { get; set; }

        /// <summary></summary>
        DateTime LoginTime { get; set; }

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