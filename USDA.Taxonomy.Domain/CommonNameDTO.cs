using USDA.ARS.GRIN.GRINGlobal.API.Data.Models;

namespace USDA.ARS.GRIN.GRINGlobal.API.Domain
{
    public class CommonNameDTO
    {
        public int taxonomy_common_name_id { get; set; }

        public int? taxonomy_genus_id { get; set; }

        public int? taxonomy_species_id { get; set; }

        public string language_description { get; set; }

        public string name { get; set; }

        public string simplified_name { get; set; }

        public string alternate_transcription { get; set; }

        public int? citation_id { get; set; }

        public string note { get; set; }

        public DateTime created_date { get; set; }

        public int created_by { get; set; }

        public DateTime? modified_date { get; set; }

        public int? modified_by { get; set; }

        public DateTime owned_date { get; set; }

        public int owned_by { get; set; }

        public int? geography_id { get; set; }

        public int? taxonomy_common_name_language_id { get; set; }

        public virtual citation citation { get; set; }

        public virtual geography geography { get; set; }

        public virtual taxonomy_common_name_language taxonomy_common_name_language { get; set; }
       
    }
}
