﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace USDA.ARS.GRINGlobal.Data.Models;

public partial class AccessionInvAttach
{
    public int AccessionInvAttachId { get; set; }

    public int InventoryId { get; set; }

    public string VirtualPath { get; set; }

    public string ThumbnailVirtualPath { get; set; }

    public int? SortOrder { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string DescriptionCode { get; set; }

    public string ContentType { get; set; }

    public string CategoryCode { get; set; }

    public string CopyrightInformation { get; set; }

    public int? AttachCooperatorId { get; set; }

    public string IsWebVisible { get; set; }

    public DateTime? AttachDate { get; set; }

    public string AttachDateCode { get; set; }

    public string Note { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime OwnedDate { get; set; }

    public int OwnedBy { get; set; }

    public string IsThumbnailVirtualPathValid { get; set; }

    public string IsVirtualPathValid { get; set; }

    public DateTime? ValidatedDate { get; set; }

    public string FileExtension { get; set; }

    public virtual Cooperator AttachCooperator { get; set; }

    public virtual Cooperator CreatedByNavigation { get; set; }

    public virtual Inventory Inventory { get; set; }

    public virtual Cooperator ModifiedByNavigation { get; set; }

    public virtual Cooperator OwnedByNavigation { get; set; }
}