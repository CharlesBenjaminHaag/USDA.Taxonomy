using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using USDA.ARS.GRINGlobal.Domain.Services;

namespace USDA.ARS.GRINGlobal.API.Web.Controllers
{
    [EnableCors("DefaultPolicy")]
    [ApiController]
    [Route("v1/cgc")]
    public class CropGermplasmCommitteeController : ControllerBase
    {
        private readonly ILogger<CropGermplasmCommitteeController> _logger;
        private readonly ICropGermplasmCommitteeRepository _cropGermplasmCommitteeRepository;

        public CropGermplasmCommitteeController(ICropGermplasmCommitteeRepository accessionRepository, ILogger<CropGermplasmCommitteeController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _cropGermplasmCommitteeRepository= accessionRepository ??
                    throw new ArgumentNullException(nameof(accessionRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetCropGermplasmCommittees()
        {
            try
            {
                var accessions = await _cropGermplasmCommitteeRepository.GetCropGermplasmCommitteesAsync();
                return Ok(accessions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving crop germplasm committees");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
