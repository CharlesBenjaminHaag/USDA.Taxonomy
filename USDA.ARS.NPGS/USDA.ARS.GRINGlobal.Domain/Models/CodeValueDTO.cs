using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDA.ARS.GRINGlobal.Domain.Models
{
    public class CodeValueDTO
    {
        public int code_value_id { get; set; }

        public int code_value_lang_id { get; set; }

        public string group_name { get; set; }

        public string value { get; set; }

        public string title { get; set; }

        public string description { get; set; }
    }
}
