using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using USDA.ARS.GRINGlobal.Domain.Models;
using USDA.ARS.GRINGlobal.Domain.Services;

namespace USDA.ARS.GRINGlobal.API.Web.Controllers
{
    [EnableCors("DefaultPolicy")]
    [ApiController]
    [Route("v1/geography")]
    public class GeographyController : ControllerBase
    {
        private readonly ILogger<GeographyController> _logger;
        private readonly IGeographyRepository _geographyRepository;

        public GeographyController(IGeographyRepository geographyRepository, ILogger<GeographyController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _geographyRepository = geographyRepository ??
                    throw new ArgumentNullException(nameof(geographyRepository));
        }

        [HttpGet("countries")]
        public async Task<IActionResult> GetAllCountries()
        {
            try
            {
                var countries = await _geographyRepository.GetAllCountriesAsync();
                if (countries == null)
                {
                    return NotFound();
                }
                return Ok(countries);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving countries");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
