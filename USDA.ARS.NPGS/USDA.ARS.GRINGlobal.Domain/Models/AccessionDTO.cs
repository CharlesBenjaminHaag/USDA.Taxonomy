namespace USDA.ARS.GRINGlobal.Domain.Models
{
    public class AccessionDTO
    {
        public int? accession_id { get; set; }
        public string? accession_identifier { get; set; }
        public string? plant_name { get; set; }
        public string? doi { get; set; }
        public int? taxonomy_species_id { get; set; }
        public string? taxonomy_species_name { get; set; }
        public string? origin_location { get; set; }
        public string? genebank_name { get; set; }
        public string? image_url { get; set; }
        public string? availability_status { get; set; }
        public int? received_date { get; set; }
        public int? received_year { get; set; }
        public string? source_type { get; set; }
        public string? source_date { get; set; }
        public string? source_collection_site { get; set; }
        public string? source_coordinates { get; set; }
        public string? source_elevation { get; set; }
        public string? source_habitat { get; set; }
        public string? improvement_level { get; set; }
        public string? narrative { get; set; }
    }
}
