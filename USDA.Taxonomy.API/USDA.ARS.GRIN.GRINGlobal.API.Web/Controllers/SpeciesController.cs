using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using USDA.ARS.GRIN.GRINGlobal.API.Data;
using USDA.ARS.GRIN.GRINGlobal.API.Web.Models;
using USDA.ARS.GRIN.GRINGlobal.API.Web.Services;
using AutoMapper;
using USDA.ARS.GRIN.GRINGlobal.API.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Cors;
using USDA.Taxonomy.API.Web.Models;


namespace USDA.ARS.GRIN.GRINGlobal.API.Web.Controllers
{
    [EnableCors("DefaultPolicy")]
    [ApiController]
    [Route("api/species")]
    public class SpeciesController : ControllerBase
    {
        private readonly ILogger<SpeciesController> _logger;
        private readonly ISpeciesRepository _speciesRepository;
        private readonly IMapper _mapper;
        const int maxSpeciesPerPage = 25;

        public SpeciesController(ISpeciesRepository speciesRepository, IMapper mapper, ILogger<SpeciesController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _speciesRepository = speciesRepository ?? 
                    throw new ArgumentNullException(nameof(speciesRepository));
            _mapper = mapper ??
                    throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Returns a single species (taxa) record.
        /// </summary>
        /// <param name="id">The GRIN-Global unique ID of the species.</param>
        /// <param name="includeCommonNames">(Boolean) Indicates whether or not to include all common names associated with the species.</param>
        /// <returns></returns>
        [EnableCors("DefaultPolicy")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecies(int id, bool includeCommonNames = false)
        {
            try
            {
                var species = await _speciesRepository.GetSpeciesByIdAsync(id, includeCommonNames);

                if (species == null)
                {
                    _logger.LogInformation($"Species with id {id} not found.");
                    return NotFound();
                }

                if (includeCommonNames == true)
                {
                    return Ok(_mapper.Map<SpeciesDTO>(species));
                }

                return Ok(_mapper.Map<SpeciesDTOWithoutChildren>(species));
            }
            catch (Exception ex) {
                _logger.LogCritical($"Exception while getting species with id {id}", ex);
                return StatusCode(500,"A problem occurred while handling your request.");
            }
        }

        /// <summary>
        /// Searches for species taxa using one or more criteria.
        /// </summary>
        /// <param name="speciesId">The GRIN-defined unique ID of the taxon.</param>
        /// <param name="genusName">All or part of the genus name.</param>
        /// <param name="speciesName">All or part of the species epithet.</param>
        /// <param name="includeAcceptedNamesOnly">Indicates whether or not to search only accepted names.</param>
        /// <param name="includeCommonNames">(true/false) Indicates whether or not to retrieve common names associated with this taxon.</param>
        /// <param name="includeDistributions">(true/false) Indicates whether or not to include geographic distributions associated with this taxon.</param>
        /// <param name="includeSynonyms">(true/false) Indicates whether or not to include synonyms associated with this taxon.</param>
        /// <param name="includeCitations">(true/false) Indicates whether or not to include ciations associated with this taxon.</param>
        /// <param name="pageNumber">The page number at which to begin (default 1).</param>
        /// <param name="pageSize">The desired size of each page of search results (maximum 25).</param>
        /// <returns></returns>
        [EnableCors("DefaultPolicy")]
        [HttpGet]
        public async Task<IActionResult> SearchSpecies(int? speciesId, string? genusName, string? speciesName, bool includeAcceptedNamesOnly = false, bool includeCommonNames = false, bool includeDistributions = false, bool includeSynonyms = false, bool includeCitations = false, int pageNumber = 1, int pageSize = 10)
        {
            try 
            { 
                var speciesCollection = await _speciesRepository.SearchSpeciesAsync(speciesId, genusName, speciesName, includeAcceptedNamesOnly, includeCommonNames, includeDistributions, includeSynonyms, includeCitations, pageNumber, pageSize);
                var result = speciesCollection.Select(static species =>
                {
                    string? v = species.name_verified_date.ToString();
                    return new SpeciesDTO
                    {
                        taxonomy_species_id = species.taxonomy_species_id,
                        current_taxonomy_species_id = species.current_taxonomy_species_id,
                        name = species.taxonomy_genus.genus_name + species.species_name,
                        is_accepted_name = (species.current_taxonomy_species_id == species.taxonomy_species_id) ? true : false,
                        accepted_name = (species.Inversecurrent_taxonomy_species.Count > 0) ? species.Inversecurrent_taxonomy_species.First().name : null,
                        protologue = species.protologue,
                        species_authority = species.species_authority,
                        taxonomy_common_name = (from cn in species.taxonomy_common_name
                                                select new CommonNameDTO
                                                {
                                                    taxonomy_common_name_id = cn.taxonomy_common_name_id,
                                                    name = cn.name,
                                                    language_description = cn.language_description,
                                                }).ToList(),
                        citation = (from ct in species.citation
                                    select new CitationDTO
                                    {
                                        citation_id = ct.citation_id,
                                        title = ct.title,
                                        description = ct.description,
                                        citation_year = ct.citation_year,
                                        literature_abbreviation = ct.literature.abbreviation,
                                        literature_standard_abbreviation = ct.literature.standard_abbreviation,
                                        literature_title = ct.literature.reference_title
                                    }).ToList()
                    };
                }).ToList();

                //return Ok(_mapper.Map<IEnumerable<SpeciesDTO>>(speciesCollection));
                return Ok(result);
            }
            catch (Exception ex) 
            {
                _logger.LogCritical("Exception while searching species.", ex);
                return StatusCode(500,"A problem occurred while handling your request.");
            }
        }
    }
}
