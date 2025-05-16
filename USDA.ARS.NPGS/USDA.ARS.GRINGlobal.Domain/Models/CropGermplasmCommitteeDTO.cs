using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USDA.ARS.GRINGlobal.Data.Models;

namespace USDA.ARS.GRINGlobal.Domain.Models
{
    public class CropGermplasmCommitteeDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string roster_url { get; set;}
        public List<DocumentDTO> documents { get; set; }
    }
}
