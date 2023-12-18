using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DTP.Services;
using DTP.Services.Exceptions;
using DTP.Models;
using DTP.Models.ViewModels;

namespace DTP.Controllers
{
    public class DTPsController : Controller
    {
        private readonly DTPsService _dtpsService;
        private readonly ParentRDMService _parentRDMService;

        public DTPsController(DTPsService dtpsService, ParentRDMService parentRDMService)
        {
            _dtpsService = dtpsService;
            _parentRDMService = parentRDMService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _dtpsService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not provided" });
            }

            var obj = await _dtpsService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not found" });
            }

            obj.ParentRDMs = await _parentRDMService.FindAllByDTPAsync(obj);

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
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not provided" });
            }

            var obj = await _dtpsService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not found" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DTPs obj)
        {
            if (id != obj.Id)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id mismatch" });
            }

            try
            {
                await _dtpsService.UpdateAsync(obj);
                return RedirectToAction(nameof(Index));
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
                return RedirectToAction(nameof(Error), new { Message = "Id not provided" });
            }

            var obj = await _dtpsService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not found" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _dtpsService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException ex)
            {
                return RedirectToAction(nameof(Error), new { Message = ex.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                Message = message
            };

            return View(viewModel);
        }
    }
}
