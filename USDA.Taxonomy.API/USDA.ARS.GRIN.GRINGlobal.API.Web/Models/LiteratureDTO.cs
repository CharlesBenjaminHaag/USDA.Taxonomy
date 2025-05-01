﻿namespace USDA.Taxonomy.API.Web.Models
{
    public class LiteratureDTO
    {
        public int literature_id { get; set; }

        public string abbreviation { get; set; }

        public string standard_abbreviation { get; set; }

        public string reference_title { get; set; }

        public string editor_author_name { get; set; }

        public string literature_type_code { get; set; }

        public string publication_year { get; set; }

        public string publisher_name { get; set; }

        public string publisher_location { get; set; }

        public string url { get; set; }

        public string note { get; set; }

        public DateTime created_date { get; set; }

        public int created_by { get; set; }

        public DateTime? modified_date { get; set; }

        public int? modified_by { get; set; }

        public DateTime owned_date { get; set; }

        public int owned_by { get; set; }
    }
}
