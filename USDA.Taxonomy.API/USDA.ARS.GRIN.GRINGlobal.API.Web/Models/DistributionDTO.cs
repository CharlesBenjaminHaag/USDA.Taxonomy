using USDA.ARS.GRIN.GRINGlobal.API.Data.Models;

namespace USDA.Taxonomy.API.Web.Models
{
    public class DistributionDTO
    {
        //public int taxonomy_geography_map_id { get; set; }

        //public int taxonomy_species_id { get; set; }

        //public int? geography_id { get; set; }

        //public string geography_status_code { get; set; }

        public string country_code { get; set; }

        public string admin_1 { get; set; }

        public string note { get; set; }

        public string citation_text { get; set; }
    }
}
