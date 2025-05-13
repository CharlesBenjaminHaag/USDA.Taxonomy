using Microsoft.AspNetCore.Mvc;

namespace USDA.ARS.NPGS.Web.UI.Controllers
{
    public class CropGermplasmCommitteeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
