using Microsoft.AspNetCore.Mvc;
using DTP.Services;
using DTP.Models;
using DTP.Services.Exceptions;
using System.Diagnostics;

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
                return RedirectToAction(nameof(Error), new { Message = "Id not provided" });
            }

            var obj = _sitesService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not found" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Sites site)
        {
            if (!ModelState.IsValid)
            {
                return View(site);
            }

            if (id != site.Id)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id mismatch" });
            }

            try
            {
                _sitesService.Update(site);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction(nameof(Error), new { Message = ex.Message });
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = _sitesService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
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

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel()
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}
