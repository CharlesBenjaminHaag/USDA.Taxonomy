namespace USDA.ARS.GRINGlobal.Domain.Models
{
    public class AccessionDTO
    {
        public string? accession_name { get; set; }
        public string? plant_name { get; set; }
        public string? doi { get; set; }
        public int? taxonomy_species_id { get; set; }
        public string? taxonomy_species_name { get; set; }
        public string? origin_location { get; set; }
        public string? genebank_name { get; set; }
        public string? image_url { get; set; }
        public string? availability { get; set; }
        public int? received_date { get; set; }
        public string? source_type { get; set; }
        public string? source_date { get; set; }
        public string? source_collection_location { get; set; }
        public string? source_location_lat_long { get; set; }
        public string? source_location_elevation { get; set; }
        public string? source_habitat_description { get; set; }
        public string? improvement_level { get; set; }
        public string? narrative { get; set; }
        public int? accession_id { get; set; }
        public DateTime? initial_received_date { get; set; }
    }
}
