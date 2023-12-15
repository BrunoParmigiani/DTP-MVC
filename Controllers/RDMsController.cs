using Microsoft.AspNetCore.Mvc;
using DTP.Services;
using DTP.Models.ViewModels;

namespace DTP.Controllers
{
    public class RDMsController : Controller
    {
        private readonly ParentRDMService _parentRDMService;
        private readonly ChildrenRDMService _childrenRDMService;

        public RDMsController(ParentRDMService parentRDMService, ChildrenRDMService childrenRDMService)
        {
            _parentRDMService = parentRDMService;
            _childrenRDMService = childrenRDMService;
        }

        public async Task<IActionResult> Index()
        {
            var parentsList = await _parentRDMService.FindAllAsync();
            var childrenList = await _childrenRDMService.FindAllAsync();

            var viewModel = new RDMsViewModel
            {
                ParentRDMs = parentsList,
                ChildrenRDMs = childrenList
            };

            return View(viewModel);
        }
    }
}
