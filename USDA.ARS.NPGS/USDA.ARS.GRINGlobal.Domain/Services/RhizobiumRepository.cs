using Microsoft.EntityFrameworkCore;
using USDA.ARS.GRINGlobal.Data.Models;
using USDA.ARS.GRINGlobal.Domain.Models;

namespace USDA.ARS.GRINGlobal.Domain.Services
{
    public class RhizobiumRepository : IRhizobiumRepository
    {
        private readonly gringlobalContext _context;
        public RhizobiumRepository(gringlobalContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<RhizobiumDTO>> GetRhizobiaByCriteriaAsync(RhizobiumCriteriaDTO criteria)
        {
            var query = _context.Rhizobia.AsQueryable();
            if (!String.IsNullOrEmpty(criteria.usda_accession_code))
            {
                query = query.Where(c => c.UsdaAccessionCode == criteria.usda_accession_code);
            }

            var rhizobiums = await query
                .Select(c => new RhizobiumDTO
                {
                    usda_accession_code = c.UsdaAccessionCode,
                    host_plant_name = c.HostPlant,
                    common_name = c.CommonName,
                    source_name = c.Source,
                    geo_source_name = c.GeoSource,
                    genus_spp = c.GenusSpp
                })
                .ToListAsync();
            return rhizobiums;
        }
    }
}
