using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using USDA.ARS.GRINGlobal.Domain.Services;

namespace USDA.ARS.GRINGlobal.API.Web.Controllers
{
    [EnableCors("DefaultPolicy")]
    [ApiController]
    [Route("v1/site")]
    public class SiteController : ControllerBase
    {
        private readonly ILogger<SiteController> _logger;
        private readonly ISiteRepository _siteRepository;

        public SiteController(ISiteRepository siteRepository, ILogger<SiteController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _siteRepository = siteRepository ??
                    throw new ArgumentNullException(nameof(siteRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSites()
        {
            try
            {
                var sites = await _siteRepository.GetSitesByCriteriaAsync(new Domain.Models.SiteCriteriaDTO());
                if (sites == null)
                {
                    return NotFound();
                }
                return Ok(sites);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving sites");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
