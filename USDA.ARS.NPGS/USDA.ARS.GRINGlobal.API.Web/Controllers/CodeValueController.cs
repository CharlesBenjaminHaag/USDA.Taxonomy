using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using USDA.ARS.GRINGlobal.Domain.Services;

namespace USDA.ARS.GRINGlobal.API.Web.Controllers
{
    [EnableCors("DefaultPolicy")]
    [ApiController]
    [Route("v1/codevalue")]
    public class CodeValueController : ControllerBase
    {
        private readonly ILogger<CodeValueController> _logger;
        private readonly ICodeValueRepository _codeValueRepository;

        public CodeValueController(ICodeValueRepository referenceRepository, ILogger<CodeValueController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
             _codeValueRepository = referenceRepository ??
                    throw new ArgumentNullException(nameof(referenceRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetCodeValues(string groupName, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var codeValues = await _codeValueRepository.GetCodeValuesAsync(groupName, pageNumber, pageSize);
                return Ok(codeValues);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving code values");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
