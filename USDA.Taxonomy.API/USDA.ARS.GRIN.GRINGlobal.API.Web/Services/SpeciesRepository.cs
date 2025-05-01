using Microsoft.EntityFrameworkCore;
using USDA.ARS.GRIN.GRINGlobal.API.Data.Models;
//using USDA.ARS.GRIN.GRINGlobal.API.Web.Models;

namespace USDA.ARS.GRIN.GRINGlobal.API.Web.Services
{
    public class SpeciesRepository : ISpeciesRepository
    {
        private readonly gringlobalContext _context;

        public SpeciesRepository(gringlobalContext context) 
        { 
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        
        /// <summary>
        /// Returns a single species record.
        /// </summary>
        /// <param name="id">The GRIN-Global-defined unique ID of the species.</param>
        /// <param name="includeCommonNames">(Boolean) Indicates whether or not to include all common names associated with the species.</param>
        /// <returns></returns>
        public async Task<taxonomy_species?> GetSpeciesByIdAsync(int id, bool includeCommonNames)
        {
            if (includeCommonNames)
            {
                return await _context.taxonomy_species.Include(s => s.taxonomy_common_name).Where(s => s.taxonomy_species_id == id).FirstOrDefaultAsync();
            }

            return await _context.taxonomy_species.Where(s => s.taxonomy_species_id == id).FirstOrDefaultAsync();
        }
       
        public async Task<IEnumerable<taxonomy_species>> GetSpeciesListAsync()
        {
            return await _context.taxonomy_species.OrderBy(s=>s.name).ToListAsync();
        }
        
        public async Task<IEnumerable<taxonomy_species_synonym_map>> GetSpeciesSynonyms(int id)
        {
            return await _context.taxonomy_species_synonym_map.ToListAsync();
        }

        /// <summary>
        /// Search for taxa by one or more criteria
        /// </summary>
        /// <param name="speciesId"></param>
        /// <param name="genusName">The name of the genus.</param>
        /// <param name="speciesName">The species epithet.</param>
        /// <param name="includeAcceptedNamesOnly"></param>
        /// <param name="includeCommonNames"></param>
        /// <param name="includeDistributions"></param>
        /// <param name="includeSynonyms"></param>
        /// <param name="includeCitations"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<IEnumerable<taxonomy_species>> SearchSpeciesAsync(int? speciesId, string? genusName, string? speciesName, bool includeAcceptedNamesOnly = false, bool includeCommonNames = false, bool includeDistributions = false, bool includeSynonyms = false, bool includeCitations = false, int pageNumber = 1, int pageSize = 10)
        {
            var speciesCollection = _context.taxonomy_species as IQueryable<taxonomy_species>;

            if (speciesId > 0) 
            { 
                speciesCollection = speciesCollection.Where(s => s.taxonomy_species_id == speciesId);
            }

            if (!string.IsNullOrEmpty(genusName))
            {
                genusName = genusName.Trim();
                speciesCollection = speciesCollection.Where(s => s.taxonomy_genus.genus_name.Contains(genusName));
            }

            speciesCollection = speciesCollection.Include(g => g.taxonomy_genus);

            if (!string.IsNullOrEmpty(speciesName))
            {
                speciesName = speciesName.Trim();
                speciesCollection = speciesCollection.Where(s => s.name.Contains(speciesName));
            }

            if (includeCommonNames)
            {
                speciesCollection = speciesCollection.Include(x => x.taxonomy_common_name);
            }

            if (includeDistributions)
            {
                speciesCollection = speciesCollection.Include(x => x.taxonomy_geography_map);
            }

            if (includeCitations)
            {
                speciesCollection = speciesCollection.Include(x => x.citation).ThenInclude(l => l.literature);
            }

            if (includeAcceptedNamesOnly)
            {
                speciesCollection = speciesCollection.Where(x => x.taxonomy_species_id != x.current_taxonomy_species_id && x.current_taxonomy_species_id > 0);
            }

            speciesCollection = speciesCollection.Include(x => x.Inversecurrent_taxonomy_species); 

            

            var totalRecordsFound = await speciesCollection.CountAsync();

            var speciesCollectionToReturn = await speciesCollection.OrderBy(s => s.name).Skip(pageSize * (pageNumber - 1)).ToListAsync();

            return speciesCollectionToReturn;

        }
    }
}
