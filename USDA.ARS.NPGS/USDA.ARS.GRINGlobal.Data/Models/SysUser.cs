﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace USDA.ARS.GRINGlobal.Data.Models;

public partial class SysUser
{
    public int SysUserId { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public string IsEnabled { get; set; }

    public int? CooperatorId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime OwnedDate { get; set; }

    public int OwnedBy { get; set; }

    public virtual Cooperator Cooperator { get; set; }

    public virtual Cooperator CreatedByNavigation { get; set; }

    public virtual Cooperator ModifiedByNavigation { get; set; }

    public virtual Cooperator OwnedByNavigation { get; set; }

    public virtual ICollection<SysGroupUserMap> SysGroupUserMaps { get; set; } = new List<SysGroupUserMap>();

    public virtual ICollection<SysUserPermissionMap> SysUserPermissionMaps { get; set; } = new List<SysUserPermissionMap>();
}