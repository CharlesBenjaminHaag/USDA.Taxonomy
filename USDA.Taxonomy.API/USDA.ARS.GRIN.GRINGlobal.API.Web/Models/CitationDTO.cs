namespace USDA.Taxonomy.API.Web.Models
{
    public class CitationDTO
    {
        public int citation_id { get; set; }

        public int? literature_id { get; set; }

        public string? assembled_name { get; set; }

        public string? literature_title { get; set; }

        public string? literature_abbreviation { get; set; }

        public string? literature_standard_abbreviation { get; set; }

        public string citation_title { get; set; }

        public string author_name { get; set; }

        public int? citation_year { get; set; }

        public string reference { get; set; }

        public string doi_reference { get; set; }

        public string url { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        private string GetAssembledName()
        {
            string author = (author_name ?? "").Trim();
            string year = string.IsNullOrWhiteSpace(citation_year.ToString()) ? "" : ". " + citation_year.ToString().Trim();
            string assembledTitle = string.IsNullOrWhiteSpace(citation_title ?? title) ? "" : ". " + (citation_title ?? title).Trim();
            string abbreviation = string.IsNullOrWhiteSpace(literature_abbreviation) ? "" : ". " + literature_abbreviation.Trim();
            string assembledReference = string.IsNullOrWhiteSpace(reference) ? "" : ". " + reference.Trim();

            string assembledName = (author + year + assembledTitle + abbreviation + assembledReference).Trim();
            return assembledName;
        }
    }
}
