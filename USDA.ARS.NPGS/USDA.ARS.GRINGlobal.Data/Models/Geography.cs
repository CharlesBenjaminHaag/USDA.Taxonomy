﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace USDA.ARS.GRINGlobal.Data.Models;

public partial class Geography
{
    public int GeographyId { get; set; }

    public int? CurrentGeographyId { get; set; }

    public string CountryCode { get; set; }

    public string Adm1 { get; set; }

    public string Adm1TypeCode { get; set; }

    public string Adm1Abbrev { get; set; }

    public string Adm2 { get; set; }

    public string Adm2TypeCode { get; set; }

    public string Adm2Abbrev { get; set; }

    public string Adm3 { get; set; }

    public string Adm3TypeCode { get; set; }

    public string Adm3Abbrev { get; set; }

    public string Adm4 { get; set; }

    public string Adm4TypeCode { get; set; }

    public string Adm4Abbrev { get; set; }

    public DateTime? ChangedDate { get; set; }

    public string IsValid { get; set; }

    public string Note { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime OwnedDate { get; set; }

    public int OwnedBy { get; set; }

    public virtual ICollection<AccessionSource> AccessionSources { get; set; } = new List<AccessionSource>();

    public virtual ICollection<Cooperator> CooperatorGeographies { get; set; } = new List<Cooperator>();

    public virtual ICollection<Cooperator> CooperatorSecondaryGeographies { get; set; } = new List<Cooperator>();

    public virtual Cooperator CreatedByNavigation { get; set; }

    public virtual Geography CurrentGeography { get; set; }

    public virtual ICollection<GeographyRegionMap> GeographyRegionMaps { get; set; } = new List<GeographyRegionMap>();

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual ICollection<Geography> InverseCurrentGeography { get; set; } = new List<Geography>();

    public virtual ICollection<Method> Methods { get; set; } = new List<Method>();

    public virtual Cooperator ModifiedByNavigation { get; set; }

    public virtual Cooperator OwnedByNavigation { get; set; }

    public virtual ICollection<WebCooperator> WebCooperators { get; set; } = new List<WebCooperator>();

    public virtual ICollection<WebOrderRequestAddress> WebOrderRequestAddresses { get; set; } = new List<WebOrderRequestAddress>();

    public virtual ICollection<WebUserShippingAddress> WebUserShippingAddresses { get; set; } = new List<WebUserShippingAddress>();
}