using Microsoft.EntityFrameworkCore;
using USDA.ARS.GRINGlobal.Data.Models;
using USDA.ARS.GRINGlobal.Domain.Models;

namespace USDA.ARS.GRINGlobal.Domain.Services
{
    public class SiteRepository : ISiteRepository
    {
        private readonly gringlobalContext _context;

        public SiteRepository(gringlobalContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
       
        public async Task<IEnumerable<SiteDTO>> GetSitesByCriteriaAsync(SiteCriteriaDTO criteria)
        {
            var query = _context.Sites.AsQueryable();

            if (criteria.site_id > 0)
            {
                query = query.Where(s => s.SiteId ==  criteria.site_id);
            }

            if (!String.IsNullOrEmpty(criteria.full_name))
            {
                query = query.Where(s => (s.SiteShortName + s.SiteLongName).Contains(criteria.full_name));
            }

            return await Task.Run(() =>
            {
                var sites = _context.Sites
                    .Select(s => new SiteDTO
                    {
                        site_id = s.SiteId,
                        full_name = "(" + s.SiteShortName + ") " + s.SiteLongName
                    }).ToList().OrderBy(s => s.full_name);
                return sites;
            });
        }
    }
}
