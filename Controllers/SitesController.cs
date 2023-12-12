using Microsoft.AspNetCore.Mvc;
using DTP.Services;
using DTP.Models;
using DTP.Models.ViewModels;
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

        public async Task <IActionResult> Index()
        {
            var list = await _sitesService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Details()
        {
            var list = await _sitesService.FindAllAsync();
            return View(list);
        }

        public IActionResult Create() // [GET] Page to be rendered
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Sites site) // [POST] Insertion method
        {
            await _sitesService.InsertAsync(site);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not provided" });
            }

            var obj = await _sitesService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not found" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Sites site)
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
                await _sitesService.UpdateAsync(site);
                return RedirectToAction(nameof(Details));
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction(nameof(Error), new { Message = ex.Message });
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = await _sitesService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _sitesService.RemoveAsync(id);
                return RedirectToAction(nameof(Details));
            }
            catch (IntegrityException ex)
            {
                return RedirectToAction(nameof(Error), new { Message = ex.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel()
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                Message = message
            };

            return View(viewModel);
        }
    }
}
