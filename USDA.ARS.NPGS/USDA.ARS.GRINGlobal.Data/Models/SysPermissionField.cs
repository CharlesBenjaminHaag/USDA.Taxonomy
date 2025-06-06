﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace USDA.ARS.GRINGlobal.Data.Models;

public partial class SysPermissionField
{
    public int SysPermissionFieldId { get; set; }

    public int SysPermissionId { get; set; }

    public int? SysDataviewFieldId { get; set; }

    public int? SysTableFieldId { get; set; }

    public string FieldType { get; set; }

    public string CompareOperator { get; set; }

    public string CompareValue { get; set; }

    public int? ParentTableFieldId { get; set; }

    public string ParentFieldType { get; set; }

    public string ParentCompareOperator { get; set; }

    public string ParentCompareValue { get; set; }

    public string CompareMode { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime OwnedDate { get; set; }

    public int OwnedBy { get; set; }

    public virtual Cooperator CreatedByNavigation { get; set; }

    public virtual Cooperator ModifiedByNavigation { get; set; }

    public virtual Cooperator OwnedByNavigation { get; set; }

    public virtual SysTableField ParentTableField { get; set; }

    public virtual SysPermission SysPermission { get; set; }

    public virtual SysTableField SysTableField { get; set; }
}