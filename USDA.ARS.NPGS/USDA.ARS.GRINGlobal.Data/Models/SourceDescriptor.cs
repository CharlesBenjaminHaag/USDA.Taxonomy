﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace USDA.ARS.GRINGlobal.Data.Models;

public partial class SourceDescriptor
{
    public int SourceDescriptorId { get; set; }

    public string CodedName { get; set; }

    public string CategoryCode { get; set; }

    public string DataTypeCode { get; set; }

    public string IsCoded { get; set; }

    public int? MaxLength { get; set; }

    public string NumericFormat { get; set; }

    public decimal? NumericMaximum { get; set; }

    public decimal? NumericMinimum { get; set; }

    public string OriginalValueTypeCode { get; set; }

    public string OriginalValueFormat { get; set; }

    public string OntologyUrl { get; set; }

    public string Note { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime OwnedDate { get; set; }

    public int OwnedBy { get; set; }

    public virtual Cooperator CreatedByNavigation { get; set; }

    public virtual Cooperator ModifiedByNavigation { get; set; }

    public virtual Cooperator OwnedByNavigation { get; set; }

    public virtual ICollection<SourceDescObservation> SourceDescObservations { get; set; } = new List<SourceDescObservation>();

    public virtual ICollection<SourceDescriptorCode> SourceDescriptorCodes { get; set; } = new List<SourceDescriptorCode>();

    public virtual ICollection<SourceDescriptorLang> SourceDescriptorLangs { get; set; } = new List<SourceDescriptorLang>();
}