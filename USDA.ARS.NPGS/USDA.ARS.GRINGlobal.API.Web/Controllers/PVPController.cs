using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using USDA.ARS.GRINGlobal.Domain.Models;
using USDA.ARS.GRINGlobal.Domain.Services;

namespace USDA.ARS.GRINGlobal.API.Web.Controllers
{
    [EnableCors("DefaultPolicy")]
    [ApiController]
    [Route("v1/pvp")]
    public class PVPController : Controller
    {
        private readonly ILogger<PVPController> _logger;
        private readonly IAccessionIprRepository _accessionIprRepository;

        public PVPController(ILogger<PVPController> logger, IAccessionIprRepository accessionIprRepository)
        {
            _logger = logger;
            _accessionIprRepository = accessionIprRepository;
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetAccessionIprsByCriteria([FromQuery] AccessionIprCriteriaDTO criteria)
        {
            try
            {
                var accessionIprs = await _accessionIprRepository.GetAccessionIprsByCriteriaAsync(criteria);
                return Ok(accessionIprs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving accessionIprs by supplied criteria");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
