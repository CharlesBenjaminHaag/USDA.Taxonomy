using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using USDA.ARS.GRINGlobal.Domain.Models;
using USDA.ARS.GRINGlobal.Domain.Services;


namespace USDA.ARS.GRINGlobal.API.Web.Controllers
{
    [EnableCors("DefaultPolicy")]
    [ApiController]
    [Route("v1/rhizobium")]
    public class RhizobiumController : Controller
    {
        private readonly ILogger<AccessionController> _logger;
        private readonly IRhizobiumRepository _rhizobiumRepository;

        public RhizobiumController(ILogger<AccessionController> logger, IRhizobiumRepository rhizobiumRepository)
        {
            _logger = logger;
            _rhizobiumRepository = rhizobiumRepository;
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetRhizobiaByCriteria([FromQuery] RhizobiumCriteriaDTO criteria)
        {
            try
            {
                var rhizobia = await _rhizobiumRepository.GetRhizobiaByCriteriaAsync(criteria);
                return Ok(rhizobia);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving rhizobia by supplied criteria");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
