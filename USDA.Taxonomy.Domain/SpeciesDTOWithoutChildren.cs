namespace USDA.ARS.GRIN.GRINGlobal.API.Domain
{
    public class SpeciesDTOWithoutChildren
    {
        public int taxonomy_species_id { get; set; }

        public int? current_taxonomy_species_id { get; set; }
        public string species_name { get; set; }

        public string species_authority { get; set; }

        public string is_subspecific_hybrid { get; set; }

        public string subspecies_name { get; set; }

        public string subspecies_authority { get; set; }

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
        
    }
}
