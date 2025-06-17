using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDA.ARS.GRINGlobal.Domain.Models
{
    public class GeographyDTO
    {
        public int geography_id { get; set; }

        public int? current_geography_id { get; set; }

        public string country_code { get; set; }

        public string country_name { get; set; }

        public string adm1 { get; set; }

        public string adm1_type_code { get; set; }

        public string adm1_abbrev { get; set; }

        public string adm2 { get; set; }

        public string adm2_type_code { get; set; }

        public string adm2_abbrev { get; set; }

        public string adm3 { get; set; }

        public string adm3_type_code { get; set; }

        public string adm3_abbrev { get; set; }

        public string adm4 { get; set; }

        public string adm4_type_code { get; set; }

        public string adm4_abbrev { get; set; }

        public string is_valid { get; set; }

        public string note { get; set; }
    }
}
