using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using USDA.ARS.GRIN.GRINGlobal.Web.UI.Models;

namespace USDA.ARS.GRIN.GRINGlobal.Web.UI.Controllers
{
    public class PagesController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public PagesController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Accession()
        {
            return View("~/Views/Pages/Accession.cshtml");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
