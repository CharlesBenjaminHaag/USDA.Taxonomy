using USDA.ARS.GRIN.GRINGlobal.API.Data.Models;

namespace USDA.ARS.GRIN.GRINGlobal.API.Web.Services
{
    public interface ISpeciesRepository
    {
        Task<IEnumerable<taxonomy_species>> GetSpeciesListAsync();
        Task<taxonomy_species?> GetSpeciesByIdAsync(int id, bool includeCommonNames);
        Task<IEnumerable<taxonomy_species>> SearchSpeciesAsync(int? speciesId, string? genusName, string? speciesName, bool includeAcceptedNamesOnly = false, bool includeCommonNames = false, bool includeDistributions = false, bool includeSynonyms = false, bool includeCitations = false, int pageNumber = 1, int pageSize = 10);
        Task<IEnumerable<taxonomy_species_synonym_map>> GetSpeciesSynonyms(int id);

    }
}
