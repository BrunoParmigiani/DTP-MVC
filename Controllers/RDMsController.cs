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

        public async Task<IActionResult> CreateAssociated(int? dtpId, int? parentId)
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
        public async Task<IActionResult> CreateAssociated(ChildrenRDM child, int dtpId, int parentId)
        {
            child.Ticket = await _dtpsService.FindByIdAsync(dtpId);
            child.Parent = await _parentRDMService.FindByIdAsync(parentId);
            child.OpenDate = DateTime.Now;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(child);
            Console.ForegroundColor = ConsoleColor.Gray;

            await _childrenRDMService.InsertAsync(child);

            return RedirectToAction(nameof(Index), "DTPs");
        }

        public async Task<IActionResult> Details(int? id)
        {
            return View();
        }

        public async Task<IActionResult> Edit()
        {
            return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var child = await _childrenRDMService.FindByIdAsync(id.Value);

            return View(child);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _childrenRDMService.RemoveAsync(id);

            return RedirectToAction(nameof(Index), "DTPs");
        }
    }
}
