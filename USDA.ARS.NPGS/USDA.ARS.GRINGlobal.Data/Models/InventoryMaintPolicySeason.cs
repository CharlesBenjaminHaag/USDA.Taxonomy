﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace USDA.ARS.GRINGlobal.Data.Models;

public partial class InventoryMaintPolicySeason
{
    public int InventoryMaintPolicySeasonId { get; set; }

    public int InventoryMaintPolicyId { get; set; }

    public string DistributionFormTypeCode { get; set; }

    public decimal DistributionQuantity { get; set; }

    public string DistributionUnitCode { get; set; }

    public DateTime SeasonalStartDate { get; set; }

    public DateTime SeasonalEndDate { get; set; }

    public string Note { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime OwnedDate { get; set; }

    public int OwnedBy { get; set; }

    public virtual Cooperator CreatedByNavigation { get; set; }

    public virtual InventoryMaintPolicy InventoryMaintPolicy { get; set; }

    public virtual Cooperator ModifiedByNavigation { get; set; }

    public virtual Cooperator OwnedByNavigation { get; set; }
}