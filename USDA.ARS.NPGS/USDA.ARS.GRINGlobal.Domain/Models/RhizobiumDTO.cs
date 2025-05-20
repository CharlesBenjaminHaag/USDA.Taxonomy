﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDA.ARS.GRINGlobal.Domain.Models
{
    public class RhizobiumDTO
    {
        public int? id { get; set; }

        public string? usda_accession_code { get; set; }

        public string? host_plant_name { get; set; }

        public string? common_name { get; set; }

        public string? source_name { get; set; }

        public string? geo_source_name { get; set; }

        public string? note { get; set; }

        public string? genus_spp { get; set; }
    }
}
