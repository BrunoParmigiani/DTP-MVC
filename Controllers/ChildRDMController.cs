using Microsoft.AspNetCore.Mvc;
using DTP.Services;
using DTP.Models.ViewModels;
using DTP.Services.Exceptions;
using DTP.Models;

namespace DTP.Controllers
{
    public class ChildRDMController : Controller
    {
        private readonly DTPsService _dtpsService;
        private readonly ParentRDMService _parentRDMService;
        private readonly ChildrenRDMService _childrenRDMService;

        public ChildRDMController(DTPsService dtpsService, ParentRDMService parentRDMService, ChildrenRDMService childrenRDMService)
        {
            _dtpsService = dtpsService;
            _parentRDMService = parentRDMService;
            _childrenRDMService = childrenRDMService;
        }

        public IActionResult Create(int? dtpId, int? parentId)
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
        public async Task<IActionResult> Create(ChildrenRDM child, int dtpId, int parentId)
        {
            child.Ticket = await _dtpsService.FindByIdAsync(dtpId);
            child.Parent = await _parentRDMService.FindByIdAsync(parentId);
            child.OpenDate = DateTime.Now;

            await _childrenRDMService.InsertAsync(child);

            return RedirectToAction("Index", "DTPs");
        }

        public async Task<IActionResult> Details(int? dtpId, int? childId)
        {
            var child = await _childrenRDMService.FindByIdAsync(childId.Value);
            child.Ticket = await _dtpsService.FindByIdAsync(dtpId.Value);

            return View(child);
        }

        public async Task<IActionResult> Edit(int? dtpId, int? childId, int? parentId)
        {
            var child = await _childrenRDMService.FindByIdAsync(childId.Value);
            child.Parent = await _parentRDMService.FindByIdAsync(parentId.Value);
            child.Ticket = await _dtpsService.FindByIdAsync(dtpId.Value);

            var viewModel = new ChildFormViewModel
            {
                DTPId = dtpId.Value,
                ParentId = parentId.Value,
                Child = child
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ChildrenRDM child, int dtpId, int parentId)
        {
            child.Parent = await _parentRDMService.FindByIdAsync(parentId);
            child.Ticket = await _dtpsService.FindByIdAsync(dtpId);

            await _childrenRDMService.UpdateAsync(child);

            return RedirectToAction("Index", "DTPs");
        }

        public async Task<IActionResult> Delete(int? dtpId, int? childId)
        {
            var child = await _childrenRDMService.FindByIdAsync(childId.Value);
            child.Ticket = await _dtpsService.FindByIdAsync(dtpId.Value);

            return View(child);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _childrenRDMService.RemoveAsync(id);

            return RedirectToAction("Index", "DTPs");
        }
    }
}
