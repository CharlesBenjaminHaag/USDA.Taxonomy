using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDA.ARS.GRINGlobal.Domain.Models
{
    public class CriteriaBaseDTO
    {
        public int startPage { get; set; } = 1;
        public int pageSize { get; set; } = 100;
    }
}
