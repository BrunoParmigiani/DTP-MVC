using Microsoft.AspNetCore.Mvc;
using DTP.Services;
using DTP.Models;

namespace DTP.Controllers
{
    public class DTPsController : Controller
    {
        private readonly DTPsService _dtpsService;

        public DTPsController(DTPsService dtpsService)
        {
            _dtpsService = dtpsService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _dtpsService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Details(int id)
        {
            var obj = await _dtpsService.FindByIdAsync(id);
            return View(obj);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DTPs obj)
        {
            await _dtpsService.InsertAsync(obj);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var obj = await _dtpsService.FindByIdAsync(id.Value);
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DTPs obj)
        {
            await _dtpsService.UpdateAsync(obj);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var obj = await _dtpsService.FindByIdAsync(id.Value);
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _dtpsService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
