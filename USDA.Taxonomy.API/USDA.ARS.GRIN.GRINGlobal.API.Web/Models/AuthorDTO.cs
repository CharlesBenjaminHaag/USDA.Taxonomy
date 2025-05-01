namespace USDA.Taxonomy.API.Web.Models
{
    public class AuthorDTO
    {
        public int taxonomy_author_id { get; set; }

        public string short_name { get; set; }

        public string full_name { get; set; }

        public string short_name_expanded_diacritic { get; set; }

        public string full_name_expanded_diacritic { get; set; }

        public string note { get; set; }
    }
}
