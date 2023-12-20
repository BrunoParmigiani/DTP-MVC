using Microsoft.AspNetCore.Mvc;
using DTP.Services;
using DTP.Models.ViewModels;
using DTP.Services.Exceptions;
using DTP.Models;

namespace DTP.Controllers
{
    public class RDMsController : Controller
    {
        private readonly DTPsService _dtpsService;
        private readonly ParentRDMService _parentRDMService;
        private readonly ChildrenRDMService _childrenRDMService;

        public RDMsController(DTPsService dtpsService, ParentRDMService parentRDMService, ChildrenRDMService childrenRDMService)
        {
            _dtpsService = dtpsService;
            _parentRDMService = parentRDMService;
            _childrenRDMService = childrenRDMService;
        }

        public async Task<IActionResult> Index()
        {
            // Possibly list of all RDMs

            return View();
        }

        // RDMs create

        public IActionResult CreateParent(int? dtpId)
        {
            var viewModel = new ParentFormViewModel
            {
                DTPId = dtpId.Value
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateParent(ParentRDM parent, int dtpId)
        {
            parent.Ticket = await _dtpsService.FindByIdAsync(dtpId);
            parent.OpenDate = DateTime.Now;

            await _parentRDMService.InsertAsync(parent);

            return RedirectToAction(nameof(Index), "DTPs");
        }

        public IActionResult CreateChild(int? dtpId, int? parentId)
        {
            var viewModel = new ChildFormViewModel
            {
                DTPId = dtpId.Value,
                ParentId = parentId.Value
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateChild(ChildrenRDM child, int dtpId, int parentId)
        {
            child.Ticket = await _dtpsService.FindByIdAsync(dtpId);
            child.Parent = await _parentRDMService.FindByIdAsync(parentId);
            child.OpenDate = DateTime.Now;

            await _childrenRDMService.InsertAsync(child);

            return RedirectToAction(nameof(Index), "DTPs");
        }

        // RDMs details

        public async Task<IActionResult> Details(int? id)
        {
            return View();
        }

        // RDMs edit

        public async Task<IActionResult> Edit()
        {
            return View();
        }

        // RDMs delete

        public async Task<IActionResult> DeleteChild(int? id)
        {
            var child = await _childrenRDMService.FindByIdAsync(id.Value);

            return View(child);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteChild(int id)
        {
            await _childrenRDMService.RemoveAsync(id);

            return RedirectToAction(nameof(Index), "DTPs");
        }
    }
}
