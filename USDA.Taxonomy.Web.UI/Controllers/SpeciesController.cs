using Microsoft.AspNetCore.Mvc;

namespace USDA.Taxonomy.Web.UI.Controllers
{
    public class SpeciesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(string? name)
        {
            return View("~/Views/Species/Index.cshtml", new { name = name });
        }
    }
}
