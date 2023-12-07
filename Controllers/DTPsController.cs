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
    }
}
