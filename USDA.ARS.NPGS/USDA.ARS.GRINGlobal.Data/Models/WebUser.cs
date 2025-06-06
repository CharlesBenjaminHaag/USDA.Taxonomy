﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace USDA.ARS.GRINGlobal.Data.Models;

public partial class WebUser
{
    public int WebUserId { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public string IsEnabled { get; set; }

    public int SysLangId { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public int? WebCooperatorId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual SysLang SysLang { get; set; }

    public virtual WebCooperator WebCooperator { get; set; }

    public virtual ICollection<WebCooperator> WebCooperatorCreatedByNavigations { get; set; } = new List<WebCooperator>();

    public virtual ICollection<WebCooperator> WebCooperatorModifiedByNavigations { get; set; } = new List<WebCooperator>();

    public virtual ICollection<WebCooperator> WebCooperatorOwnedByNavigations { get; set; } = new List<WebCooperator>();

    public virtual ICollection<WebOrderRequestAddress> WebOrderRequestAddressCreatedByNavigations { get; set; } = new List<WebOrderRequestAddress>();

    public virtual ICollection<WebOrderRequestAddress> WebOrderRequestAddressModifiedByNavigations { get; set; } = new List<WebOrderRequestAddress>();

    public virtual ICollection<WebOrderRequestAddress> WebOrderRequestAddressOwnedByNavigations { get; set; } = new List<WebOrderRequestAddress>();

    public virtual ICollection<WebOrderRequestAttach> WebOrderRequestAttachCreatedByNavigations { get; set; } = new List<WebOrderRequestAttach>();

    public virtual ICollection<WebOrderRequestAttach> WebOrderRequestAttachModifiedByNavigations { get; set; } = new List<WebOrderRequestAttach>();

    public virtual ICollection<WebOrderRequestAttach> WebOrderRequestAttachOwnedByNavigations { get; set; } = new List<WebOrderRequestAttach>();

    public virtual ICollection<WebOrderRequest> WebOrderRequestCreatedByNavigations { get; set; } = new List<WebOrderRequest>();

    public virtual ICollection<WebOrderRequestItem> WebOrderRequestItemCreatedByNavigations { get; set; } = new List<WebOrderRequestItem>();

    public virtual ICollection<WebOrderRequestItem> WebOrderRequestItemModifiedByNavigations { get; set; } = new List<WebOrderRequestItem>();

    public virtual ICollection<WebOrderRequestItem> WebOrderRequestItemOwnedByNavigations { get; set; } = new List<WebOrderRequestItem>();

    public virtual ICollection<WebOrderRequest> WebOrderRequestOwnedByNavigations { get; set; } = new List<WebOrderRequest>();

    public virtual ICollection<WebUserCart> WebUserCartCreatedByNavigations { get; set; } = new List<WebUserCart>();

    public virtual ICollection<WebUserCartItem> WebUserCartItemCreatedByNavigations { get; set; } = new List<WebUserCartItem>();

    public virtual ICollection<WebUserCartItem> WebUserCartItemModifiedByNavigations { get; set; } = new List<WebUserCartItem>();

    public virtual ICollection<WebUserCartItem> WebUserCartItemOwnedByNavigations { get; set; } = new List<WebUserCartItem>();

    public virtual ICollection<WebUserCart> WebUserCartModifiedByNavigations { get; set; } = new List<WebUserCart>();

    public virtual ICollection<WebUserCart> WebUserCartOwnedByNavigations { get; set; } = new List<WebUserCart>();

    public virtual ICollection<WebUserCart> WebUserCartWebUsers { get; set; } = new List<WebUserCart>();

    public virtual ICollection<WebUserPreference> WebUserPreferenceCreatedByNavigations { get; set; } = new List<WebUserPreference>();

    public virtual ICollection<WebUserPreference> WebUserPreferenceModifiedByNavigations { get; set; } = new List<WebUserPreference>();

    public virtual ICollection<WebUserPreference> WebUserPreferenceOwnedByNavigations { get; set; } = new List<WebUserPreference>();

    public virtual ICollection<WebUserPreference> WebUserPreferenceWebUsers { get; set; } = new List<WebUserPreference>();

    public virtual ICollection<WebUserShippingAddress> WebUserShippingAddressCreatedByNavigations { get; set; } = new List<WebUserShippingAddress>();

    public virtual ICollection<WebUserShippingAddress> WebUserShippingAddressModifiedByNavigations { get; set; } = new List<WebUserShippingAddress>();

    public virtual ICollection<WebUserShippingAddress> WebUserShippingAddressOwnedByNavigations { get; set; } = new List<WebUserShippingAddress>();

    public virtual ICollection<WebUserShippingAddress> WebUserShippingAddressWebUsers { get; set; } = new List<WebUserShippingAddress>();
}