namespace USDA.Taxonomy.API.Web.Models
{
    public class SpeciesSynonymMapDTO
    {
        public int taxona_taxonomy_species_id { get; set; }
        public string taxona_species_name { get; set; }
        public string synonym_code { get; set; }
        public int taxonb_taxonomy_species_id { get; set; }
        //public string
        //public string note { get; set; }
    }
}
