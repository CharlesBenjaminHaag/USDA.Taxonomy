using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace USDA.ARS.GRINGlobal.Domain.Models
{
    public class AccessionIprDTO
    {
        public int? accession_ipr_id { get; set; }

        public int? accession_id { get; set; }

        public string? accession_identifier { get; set; }

        public string? type_code { get; set; }

        public string? status_code { get; set; }

        public string? status_description { get; set; }

        public string? ipr_number { get; set; }

        public string? ipr_crop_name { get; set; }

        public string? ipr_full_name { get; set; }

        public DateTime? certificate_issued_date { get; set; }

        public DateTime? certificate_expired_date { get; set; }
        
        public string?  certificate_expired_status { get; set; }

        public DateTime? accepted_Date { get; set; }

        public DateTime? expected_date { get; set; }

        public string certificate_url =>
        "https://apps.ams.usda.gov/CMS//AdobeImages/" + (ipr_number?.Replace("PVP ", "").PadLeft(9, '0') ?? "000000000") + ".pdf";
    }
}
