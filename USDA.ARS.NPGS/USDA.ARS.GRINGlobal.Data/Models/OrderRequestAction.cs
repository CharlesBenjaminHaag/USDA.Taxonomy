﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace USDA.ARS.GRINGlobal.Data.Models;

public partial class OrderRequestAction
{
    public int OrderRequestActionId { get; set; }

    public int OrderRequestId { get; set; }

    public string ActionNameCode { get; set; }

    public DateTime StartedDate { get; set; }

    public string StartedDateCode { get; set; }

    public DateTime? CompletedDate { get; set; }

    public string CompletedDateCode { get; set; }

    public string ActionInformation { get; set; }

    public decimal? ActionCost { get; set; }

    public int? CooperatorId { get; set; }

    public string Note { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime OwnedDate { get; set; }

    public int OwnedBy { get; set; }

    public virtual Cooperator Cooperator { get; set; }

    public virtual Cooperator CreatedByNavigation { get; set; }

    public virtual Cooperator ModifiedByNavigation { get; set; }

    public virtual OrderRequest OrderRequest { get; set; }

    public virtual Cooperator OwnedByNavigation { get; set; }
}