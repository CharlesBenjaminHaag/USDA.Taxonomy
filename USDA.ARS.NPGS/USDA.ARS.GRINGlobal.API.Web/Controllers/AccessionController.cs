using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using USDA.ARS.GRINGlobal.Domain.Models;
using USDA.ARS.GRINGlobal.Domain.Services;

namespace USDA.ARS.GRINGlobal.API.Web.Controllers
{
    [EnableCors("DefaultPolicy")]
    [ApiController]
    [Route("v1/accession")]
    public class AccessionController : ControllerBase
    {
        private readonly ILogger<AccessionController> _logger;
        private readonly IAccessionRepository _accessionRepository;

        public AccessionController(IAccessionRepository accessionRepository , ILogger<AccessionController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _accessionRepository = accessionRepository ??
                    throw new ArgumentNullException(nameof(accessionRepository));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccessionById(int id)
        {
            try
            {
                var accession = await _accessionRepository.GetAccessionByIdAsync(id);
                if (accession == null)
                {
                    return NotFound();
                }
                return Ok(accession);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving accession with ID {id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetAccessionsByCriteria([FromQuery] AccessionCriteriaDTO criteria)
        {
            try
            {
                var accessions = await _accessionRepository.GetAccessionsByCriteriaAsync(criteria);
                return Ok(accessions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving accessions by supplied criteria");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("report")]
        public async Task<IActionResult> GetReport(string criteria)
        {
            try
            {
                var reportData = await _accessionRepository.GetReportSummaryDiversityAsync();
                return Ok(reportData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving accessions by criteria {criteria}", criteria);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
