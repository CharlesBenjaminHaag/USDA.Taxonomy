﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace USDA.ARS.GRINGlobal.Data.Models;

public partial class InventoryQualityStatus
{
    public int InventoryQualityStatusId { get; set; }

    public int InventoryId { get; set; }

    public string TestTypeCode { get; set; }

    public string ContaminantCode { get; set; }

    public string TestResultCode { get; set; }

    public string PlantPartTestedCode { get; set; }

    public string TestResultsScore { get; set; }

    public string TestResultsScoreTypeCode { get; set; }

    public decimal? NegativeControl { get; set; }

    public decimal? PositiveControl { get; set; }

    public int? Replicate { get; set; }

    public DateTime? StartedDate { get; set; }

    public string StartedDateCode { get; set; }

    public DateTime? CompletedDate { get; set; }

    public string CompletedDateCode { get; set; }

    public int? RequiredReplicationCount { get; set; }

    public int? StartedCount { get; set; }

    public int? CompletedCount { get; set; }

    public string PlateOrAssayNumber { get; set; }

    public int? MethodId { get; set; }

    public int? TesterCooperatorId { get; set; }

    public string Note { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime OwnedDate { get; set; }

    public int OwnedBy { get; set; }

    public virtual Cooperator CreatedByNavigation { get; set; }

    public virtual Inventory Inventory { get; set; }

    public virtual Method Method { get; set; }

    public virtual Cooperator ModifiedByNavigation { get; set; }

    public virtual Cooperator OwnedByNavigation { get; set; }

    public virtual Cooperator TesterCooperator { get; set; }
}