using Microsoft.AspNetCore.Mvc;
using DTP.Services;
using DTP.Models.ViewModels;
using DTP.Services.Exceptions;
using DTP.Models;
using System.Diagnostics;

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
            if (dtpId == null || parentId == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not provided"});
            }

            var dtp = _dtpsService.FindByIdAsync(dtpId.Value);
            
            if (dtp == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Invalid Id, DTP does not exist" });
            
            }

            var parent = _parentRDMService.FindByIdAsync(parentId.Value);

            if (parent == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Invalid Id, parent RDM does not exist" });
            }

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
            if (dtpId == null || childId == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not provided" });
            }

            var child = await _childrenRDMService.FindByIdAsync(childId.Value);

            if (child == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "RDM not found" });
            }

            child.Ticket = await _dtpsService.FindByIdAsync(dtpId.Value);
            
            if (child.Ticket == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "DTP not found" });
            }

            return View(child);
        }

        public async Task<IActionResult> Edit(int? dtpId, int? childId, int? parentId)
        {
            if (dtpId == null || childId == null || parentId == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not provided" });
            }

            var child = await _childrenRDMService.FindByIdAsync(childId.Value);
            
            if (child == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Child RDM not found" });
            }

            child.Parent = await _parentRDMService.FindByIdAsync(parentId.Value);
            
            if (child.Parent == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Parent RDM not found" });
            }

            child.Ticket = await _dtpsService.FindByIdAsync(dtpId.Value);

            if (child.Ticket == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "DTP not found" });
            }

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
            if (dtpId == null || childId == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id not provided" });
            }

            var child = await _childrenRDMService.FindByIdAsync(childId.Value);

            if (child == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "Child not provided" });
            }

            child.Ticket = await _dtpsService.FindByIdAsync(dtpId.Value);

            if (child.Ticket == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "DTP not provided" });
            }

            return View(child);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _childrenRDMService.RemoveAsync(id);

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
