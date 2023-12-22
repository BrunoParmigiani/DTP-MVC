using Microsoft.AspNetCore.Mvc;
using DTP.Services;
using DTP.Models.ViewModels;
using DTP.Services.Exceptions;
using DTP.Models;

namespace DTP.Controllers
{
    public class ParentRDMController : Controller
    {
        private readonly DTPsService _dtpsService;
        private readonly ParentRDMService _parentRDMService;
        private readonly ChildrenRDMService _childrenRDMService;

        public ParentRDMController(DTPsService dtpsService, ParentRDMService parentRDMService, ChildrenRDMService childrenRDMService)
        {
            _dtpsService = dtpsService;
            _parentRDMService = parentRDMService;
            _childrenRDMService = childrenRDMService;
        }

        public IActionResult Create(int? dtpId)
        {
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

        public async Task<IActionResult> Delete(int? dtpId, int? parentId)
        {
            var parent = await _parentRDMService.FindByIdAsync(parentId.Value);
            parent.Ticket = await _dtpsService.FindByIdAsync(dtpId.Value);

            return View(parent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _parentRDMService.RemoveAsync(id);

            return RedirectToAction("Index", "DTPs");
        }
    }
}
