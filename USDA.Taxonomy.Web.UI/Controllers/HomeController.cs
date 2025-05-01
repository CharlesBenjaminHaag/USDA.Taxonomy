using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using USDA.Taxonomy.Models;

namespace USDA.Taxonomy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Template()
        {
            return View("~/Views/Pages/template.cshtml");
        }

        public IActionResult Species(string? genus_name, string? species_name)
        {
            return View("~/Views/Pages/species.cshtml");
        }

        public IActionResult Authors(string? first_name, string? last_name)
        {
            return View("~/Views/Pages/authors.cshtml");
        }

        public IActionResult Publications(string? title, string? publication_year)
        {
            return View("~/Views/Pages/publications.cshtml");
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
