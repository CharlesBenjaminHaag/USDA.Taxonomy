using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using USDA.ARS.GRINGlobal.Domain.Services;

namespace USDA.ARS.GRINGlobal.API.Web.Controllers
{
    [EnableCors("DefaultPolicy")]
    [ApiController]
    [Route("v1/accession")]
    public class CropGermplasmCommitteeController : ControllerBase
    {
        private readonly ILogger<AccessionController> _logger;
        private readonly ICropGermplasmCommitteeRepository _cropGermplasmCommitteeRepository;

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetCropGermplasmCommitteeById(int id)
        //{
        //}
    }
}
