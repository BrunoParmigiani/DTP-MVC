using Microsoft.AspNetCore.Mvc;
using DTP.Services;
using DTP.Models;

namespace DTP.Controllers
{
    public class SitesController : Controller
    {
        private readonly SitesService _sitesService;

        public SitesController(SitesService service)
        {
            _sitesService = service;
        }

        public IActionResult Index()
        {
            var list = _sitesService.FindAll();
            return View(list);
        }

        public IActionResult Create() // [GET] Page to be rendered
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Sites site) // [POST] Insertion method
        {
            _sitesService.Insert(site);
            return RedirectToAction(nameof(Index));
        }
    }
}
