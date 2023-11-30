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

        public IActionResult Details()
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

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _sitesService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Sites site)
        {
            try
            {
                _sitesService.Update(site);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _sitesService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sitesService.Remove(id);
            return RedirectToAction(nameof(Details));
        }
    }
}
