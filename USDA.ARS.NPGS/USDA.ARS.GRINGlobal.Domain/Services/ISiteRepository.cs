using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USDA.ARS.GRINGlobal.Domain.Models;

namespace USDA.ARS.GRINGlobal.Domain.Services
{
    public interface ISiteRepository
    {
        Task<IEnumerable<SiteDTO>> GetSitesByCriteriaAsync(SiteCriteriaDTO criteria);
    }
}
