using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USDA.ARS.GRINGlobal.Data.Models;

namespace USDA.ARS.GRINGlobal.Domain.Models
{
    public class AuthenticatedUserDTO
    {
        public int id { get; set; }
        public string user_name { get; set; }
        public string first_name  { get; set; }
        public string last_name { get; set; }
        public string email_address { get; set; }
    }
}
