﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace USDA.ARS.GRINGlobal.Data.Models;

public partial class WebOrderRequestItem
{
    public int WebOrderRequestItemId { get; set; }

    public int WebCooperatorId { get; set; }

    public int WebOrderRequestId { get; set; }

    public int SequenceNumber { get; set; }

    public int AccessionId { get; set; }

    public string Name { get; set; }

    public decimal? QuantityShipped { get; set; }

    public string UnitOfShippedCode { get; set; }

    public string DistributionFormCode { get; set; }

    public string StatusCode { get; set; }

    public int? InventoryId { get; set; }

    public string CuratorNote { get; set; }

    public string UserNote { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime OwnedDate { get; set; }

    public int OwnedBy { get; set; }

    public string IsSmtaRestricted { get; set; }

    public virtual Accession Accession { get; set; }

    public virtual WebUser CreatedByNavigation { get; set; }

    public virtual Inventory Inventory { get; set; }

    public virtual WebUser ModifiedByNavigation { get; set; }

    public virtual ICollection<OrderRequestItem> OrderRequestItems { get; set; } = new List<OrderRequestItem>();

    public virtual WebUser OwnedByNavigation { get; set; }

    public virtual WebCooperator WebCooperator { get; set; }

    public virtual WebOrderRequest WebOrderRequest { get; set; }
}