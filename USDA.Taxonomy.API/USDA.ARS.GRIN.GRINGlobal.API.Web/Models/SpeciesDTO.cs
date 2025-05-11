using USDA.Taxonomy.API.Web.Models;

namespace USDA.ARS.GRIN.GRINGlobal.API.Web.Models
{
    public class SpeciesDTO
    {
        public int taxonomy_species_id { get; set; }

        public int? current_taxonomy_species_id { get; set; }

        public string accepted_name { get; set; }   

        public bool is_accepted_name { get; set; }
        
        public string species_name { get; set; }

        public string name { get; set; }

        public string protologue { get; set; }

        public string species_authority { get; set; }

        public string is_subspecific_hybrid { get; set; }

        public string subspecies_name { get; set; }

        public string subspecies_authority { get; set; }

        public string name_verified_date { get; set; }

        public string is_varietal_hybrid { get; set; }

        public string variety_name { get; set; }

        public string variety_authority { get; set; }

        public string is_subvarietal_hybrid { get; set; }

        public string subvariety_name { get; set; }

        public string subvariety_authority { get; set; }

        public string is_forma_hybrid { get; set; }

        public string forma_rank_type { get; set; }

        public string forma_name { get; set; }

        public string forma_authority { get; set; }

        public int taxonomy_genus_id { get; set; }
 
        public string genus_name { get; set; }

        public ICollection<CommonNameDTO> common_names { get; set; } = new List<CommonNameDTO>();

        public ICollection<CitationDTO> citations { get; set; } = new List<CitationDTO>();
        
        public ICollection<DistributionDTO> distributions { get; set; } = new List<DistributionDTO>();

        public ICollection<SpeciesSynonymMapDTO> synonyms { get; set; } = new List<SpeciesSynonymMapDTO>();
    }
}
