using Microsoft.AspNetCore.Mvc;
using DTP.Services;
using DTP.Models.ViewModels;
using DTP.Services.Exceptions;
using DTP.Models;
using System.Diagnostics;

namespace DTP.Controllers
{
    public class ParentRDMController : Controller
    {
        private readonly DTPsService _dtpsService;
        private readonly ParentRDMService _parentRDMService;

        public ParentRDMController(DTPsService dtpsService, ParentRDMService parentRDMService)
        {
            _dtpsService = dtpsService;
            _parentRDMService = parentRDMService;
        }

        public async Task<IActionResult> Create(int? dtpId)
        {
            if (dtpId == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "A DTP must be assigned to a RDM"});
            }

            var dtp = await _dtpsService.FindByIdAsync(dtpId.Value);

            if (dtp == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Invalid Id, DTP does not exist" });
            }

            var viewModel = new ParentFormViewModel
            {
                DTPId = dtpId.Value
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ParentRDM parent, int dtpId)
        {
            parent.Ticket = await _dtpsService.FindByIdAsync(dtpId);
            parent.OpenDate = DateTime.Now;

            await _parentRDMService.InsertAsync(parent);

            return RedirectToAction("Index", "DTPs");
        }

        public async Task<IActionResult> Details(int? dtpId, int? parentId)
        {
            if (dtpId == null || parentId == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not provided" });
            }

            var parent = await _parentRDMService.FindByIdAsync(parentId.Value);

            if (parent == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "RDM not found" });
            }

            parent.Ticket = await _dtpsService.FindByIdAsync(dtpId.Value);

            if (parent.Ticket == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "DTP not found" });
            }

            return View(parent);
        }

        public async Task<IActionResult> Edit(int? dtpId, int? parentId)
        {
            if (dtpId == null || parentId == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not provided" });
            }

            var parent = await _parentRDMService.FindByIdAsync(parentId.Value);

            if (parent == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "RDM not found" });
            }

            var viewModel = new ParentFormViewModel
            {
                DTPId = dtpId.Value,
                Parent = parent
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ParentRDM parent, int dtpId)
        {
            parent.Ticket = await _dtpsService.FindByIdAsync(dtpId);

            await _parentRDMService.UpdateAsync(parent);

            return RedirectToAction("Index", "DTPs");
        }

        public async Task<IActionResult> Delete(int? dtpId, int? parentId)
        {
            if (dtpId == null || parentId == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not provided" });
            }

            var parent = await _parentRDMService.FindByIdAsync(parentId.Value);

            if (parent == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "RDM not found" });
            }

            parent.Ticket = await _dtpsService.FindByIdAsync(dtpId.Value);

            if (parent.Ticket == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "DTP not found" });
            }

            return View(parent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _parentRDMService.RemoveAsync(id);

            return RedirectToAction("Index", "DTPs");
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
