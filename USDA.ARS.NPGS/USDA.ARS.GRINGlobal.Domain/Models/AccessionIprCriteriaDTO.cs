using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDA.ARS.GRINGlobal.Domain.Models
{
    public class AccessionIprCriteriaDTO
    {
        public string? type_code { get; set; }

        public string? status_code { get; set; }

        public string? ipr_number { get; set; }

        public string? ipr_crop_name { get; set; }

        public string? ipr_full_name { get; set; }

        public DateTime? certificate_issued_date { get; set; }

        public DateTime? certificate_expired_date { get; set; }

        public DateTime? accepted_Date { get; set; }

        public DateTime? expected_date { get; set; }
    }
}
