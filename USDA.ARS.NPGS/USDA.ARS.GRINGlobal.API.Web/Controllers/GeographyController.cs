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
        private readonly ILogger<AccessionController> _logger;
        private readonly IGeographyRepository _geographyRepository;
    }
}
