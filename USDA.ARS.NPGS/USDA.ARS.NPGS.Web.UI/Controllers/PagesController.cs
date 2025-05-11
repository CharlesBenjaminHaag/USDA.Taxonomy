using Microsoft.AspNetCore.Mvc;

namespace USDA.ARS.NPGS.Web.UI.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult NPGS()
        {
            ViewBag.PageTitle = "NPGS";
            return View("~/Views/Pages/npgs.cshtml");
        }

        public IActionResult Directory()
        {
            ViewBag.PageTitle = "NPGS Directory";
            return View("~/Views/Pages/directory.cshtml");
        }

        public IActionResult Citations()
        {
            ViewBag.PageTitle = "NPGS Directory";
            return View("~/Views/Pages/citations.cshtml");
        }

        public IActionResult GRINGlobal()
        {
            ViewBag.PageTitle = "NPGS Directory";
            return View("~/Views/Pages/gringlobal.cshtml");
        }

        public IActionResult TechnicalResources()
        {
            ViewBag.PageTitle = "NPGS Directory";
            return View("~/Views/Pages/technical-resources.cshtml");
        }

        public IActionResult Microbes()
        {
            ViewBag.PageTitle = "NPGS Directory";
            return View("~/Views/Pages/microbes.cshtml");
        }

        public IActionResult PVP()
        {
            ViewBag.PageTitle = "NPGS Directory";
            return View("~/Views/Pages/pvp.cshtml");
        }
    }
}
