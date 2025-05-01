using Microsoft.AspNetCore.Mvc;

namespace USDA.Taxonomy.Web.UI.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult Index(string context)
        {
            string viewName = context + ".cshtml";
            return View(viewName);
        }
    }
}
