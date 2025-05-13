using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDA.ARS.GRINGlobal.Domain.Models
{
    public class DocumentDTO
    {
        public string title { get; set; }
        public string url  { get; set; }
        public string category { get; set; }
        public string crop_germplam_committee_name { get; set; }
    }
}
