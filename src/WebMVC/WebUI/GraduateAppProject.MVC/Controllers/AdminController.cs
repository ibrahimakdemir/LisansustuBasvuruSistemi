using GraduateAppProject.DataTransferObjects.Requests;
using GraduateAppProject.MVC.Extensions;
using GraduateAppProject.MVC.Models;
using GraduateAppProject.WebMVC.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;

namespace GraduateAppProject.MVC.Controllers
{
    
    [Authorize(Roles = "Admin,Görevli")]
    public class AdminController : Controller
    {
        private readonly IGraduateInformationService _graduateService;
        private readonly ILogger<AdminController> _logger;
        private readonly IMemoryCache _memoryCache;

        
        public AdminController(IGraduateInformationService graduateService, ILogger<AdminController> logger, IMemoryCache memoryCache)
        {
            _graduateService = graduateService;
            _logger = logger;
            _memoryCache = memoryCache;
        }

        public async Task<IActionResult> Index()
        {
            var indexPageModel = await CachingExtensions.GetIndexPageModelFromCacheOrDb(_graduateService, _memoryCache, _logger);
            return View(indexPageModel.GraduatePrograms);
        }

        public async Task<IActionResult> CreateGraduateProgram()
        {
            ViewBag.GraduateMajors = await GetGraduateMajorsForSelectList();
            ViewBag.Languages = await GetLanguagesForSelectList();
            ViewBag.Platforms = await GetPlatformsForSelectList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateGraduateProgram(CreateNewGraduateProgramRequest request)
        {
            if (ModelState.IsValid)
            {
                await _graduateService.CreateNewGraduateProgramAsync(request);
                _memoryCache.Remove("IndexPageModelData");
                return RedirectToAction(nameof(Index));
            }
            ViewBag.GraduateMajors = await GetGraduateMajorsForSelectList();
            ViewBag.Languages = await GetLanguagesForSelectList();
            ViewBag.Platforms = await GetPlatformsForSelectList();

            return View();
        }

        private async Task<IEnumerable<SelectListItem>> GetPlatformsForSelectList()
        {
            var platforms = await _graduateService.GetPlatformsAsync();
            return platforms.Select(p => new SelectListItem() { Text = p.PlatformName, Value = p.Id.ToString() });
        }

        private async Task<IEnumerable<SelectListItem>> GetLanguagesForSelectList()
        {
            var languages = await _graduateService.GetLanguagesAsync();
            return languages.Select(l => new SelectListItem() { Text = l.LanguageName, Value = l.Id.ToString() });
        }

        private async Task<IEnumerable<SelectListItem>> GetGraduateMajorsForSelectList()
        {
            var graduateMajorsForSelectList = await _graduateService.GetGraduateMajorsAsync();
            return graduateMajorsForSelectList.Select(g => new SelectListItem() { Text = g.GraduateMajorName, Value = g.Id.ToString() });
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Help()
        {
            
            return View();
        }
    }
}
