﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace USDA.ARS.GRINGlobal.Data.Models;

public partial class FeedbackResultGroup
{
    public int FeedbackResultGroupId { get; set; }

    public int FeedbackReportId { get; set; }

    public int ParticipantCooperatorId { get; set; }

    public int OrderRequestId { get; set; }

    public DateTime? StartedDate { get; set; }

    public DateTime? SubmittedDate { get; set; }

    public DateTime? AcceptedDate { get; set; }

    public DateTime? RejectedDate { get; set; }

    public DateTime? DueDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime OwnedDate { get; set; }

    public int OwnedBy { get; set; }

    public virtual Cooperator CreatedByNavigation { get; set; }

    public virtual FeedbackReport FeedbackReport { get; set; }

    public virtual ICollection<FeedbackResult> FeedbackResults { get; set; } = new List<FeedbackResult>();

    public virtual Cooperator ModifiedByNavigation { get; set; }

    public virtual Cooperator OwnedByNavigation { get; set; }
}