﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace USDA.ARS.GRIN.GRINGlobal.API.Data.Models;

public partial class taxonomy_cwr_map
{
    public int taxonomy_cwr_map_id { get; set; }

    public int taxonomy_species_id { get; set; }

    public int taxonomy_cwr_crop_id { get; set; }

    public string crop_common_name { get; set; }

    public string is_crop { get; set; }

    public string genepool_code { get; set; }

    public string is_graftstock { get; set; }

    public string is_potential { get; set; }

    public int? citation_id { get; set; }

    public string note { get; set; }

    public DateTime created_date { get; set; }

    public int created_by { get; set; }

    public DateTime? modified_date { get; set; }

    public int? modified_by { get; set; }

    public DateTime owned_date { get; set; }

    public int owned_by { get; set; }

    public virtual citation citation { get; set; }

    public virtual taxonomy_cwr_crop taxonomy_cwr_crop { get; set; }

    public virtual ICollection<taxonomy_cwr_trait> taxonomy_cwr_trait { get; set; } = new List<taxonomy_cwr_trait>();

    public virtual taxonomy_species taxonomy_species { get; set; }
}