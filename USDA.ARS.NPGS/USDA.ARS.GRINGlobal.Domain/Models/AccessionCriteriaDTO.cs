using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace USDA.ARS.GRINGlobal.Domain.Models
{
    public class AccessionCriteriaDTO : CriteriaBaseDTO
    {
        public string? accession_identifier { get; set; }
        public string? scientific_name { get; set; }
        public string? plant_name { get; set; }
        public int? genebank_id { get; set; }
        public string? genebank_name { get; set; }
        public string? country_of_origin { get; set; }
        public int received_year { get; set; }
    }
}
