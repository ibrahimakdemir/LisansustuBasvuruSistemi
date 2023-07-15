using GraduateAppProject.DataTransferObjects.Requests;
using GraduateAppProject.DataTransferObjects.Responses.UserResponses;
using GraduateAppProject.Entities;
using GraduateAppProject.Infrastructure.Models;
using GraduateAppProject.MVC.Extensions;
using GraduateAppProject.MVC.Models;
using GraduateAppProject.WebMVC.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using System.Text.Json;

namespace GraduateAppProject.MVC.Controllers
{

    [Authorize(Roles = "Admin,Görevli")]
    public class AdminController : Controller
    {
        private readonly IGraduateInformationService _graduateService;
        private readonly ILogger<AdminController> _logger;
        private readonly IMemoryCache _memoryCache;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IUserService _userService;
        private readonly IMailService _mailService;

        public AdminController(IGraduateInformationService graduateService, ILogger<AdminController> logger, IMemoryCache memoryCache
                             , IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment, IUserService userService
                             , IMailService mailService)
        {
            _graduateService = graduateService;
            _logger = logger;
            _memoryCache = memoryCache;
            _httpContextAccessor = httpContextAccessor;
            _hostEnvironment = webHostEnvironment;
            _userService = userService;
            _mailService = mailService;
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
        public async Task<IActionResult> GetMyInformations()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"].ToString();
            }
            var session = _httpContextAccessor.HttpContext.Session.GetString("UserId");
            if (session != null)
            {
                var userId = JsonSerializer.Deserialize<int>(session);
                var citizenId = await _userService.GetCitizenIdByUserIdAsync(userId);
                var userInfos = new AdminInformationsModel()
                {
                    UserIdentityInformationDTO = await _userService.GetUserIdentityInformationDTOByCitizenIdAsync(citizenId),
                    UserContactInformationDTO = await _userService.GetUserContactInformationDTOByCitizenIdAsync(citizenId)
                };

                return View(userInfos);
            }

            return RedirectToAction("Index", "Admin");

        }
        public async Task<IActionResult> GetApplications()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }

            var indexPageModel = await CachingExtensions.GetIndexPageModelFromCacheOrDb(_graduateService, _memoryCache, _logger);
            ViewBag.GraduateProgramsForSelectList = GetOpenedGraduateProgramsForSelectList(indexPageModel.GraduatePrograms);
            return View(indexPageModel.GraduatePrograms);

        }
        private IEnumerable<SelectListItem> GetOpenedGraduateProgramsForSelectList(IList<GraduateProgram> graduatePrograms)
        {
            return graduatePrograms.Select(gp => new SelectListItem()
            {
                Text = gp.GraduateMajor.GraduateMajorName + "/" + gp.Language.LanguageName + "/" + (gp.WithThesis ? "Tezli" : "Tezsiz"),
                Value = gp.Id.ToString()
            });
        }
        [HttpGet]
        public async Task<IActionResult> GetApplicants(int programId)
        {
            var applications = await _graduateService.GetApplicationByProgramIdAsync(programId);
            var users = new List<UserIdentityInformationDTO>();
            if (applications != null)
            {
                foreach (var application in applications)
                {
                    var userId = application.UserId;
                    var citizenId = await _userService.GetCitizenIdByUserIdAsync(userId);
                    var userIdentityInfo = await _userService.GetUserIdentityInformationDTOByCitizenIdAsync(citizenId);
                    users.Add(userIdentityInfo);
                }
            }
            ViewBag.ProgramId = programId;
            return PartialView("_GetApplicants", users);
        }


        [HttpGet]
        public async Task<IActionResult> GetApplicantDetails(int userId, int programId)
        {
            var infoModel = await GetApplicantInformationsExtensions.GetApplicantInformationsModelAsync(userId, _userService);
            var appliedProgram = await _graduateService.GetGraduateProgramWithInfoByProgramIdAsync(programId);

            var applicantInfoAndAppliedProgramModel = new ApplicantInfoAndAppliedProgramModel()
            {
                ApplicantInformationsModel = infoModel,
                GraduateProgram = appliedProgram
            };
            ViewBag.Reasons = await GetReasonsForSelectList();
            return View(applicantInfoAndAppliedProgramModel);
        }
        [HttpPost]
        public async Task<IActionResult> EvaluateApplication(EvaluateApplicationModel model)
        {

            var applications = await _graduateService.GetApplicationByProgramIdAsync(model.ProgramId);
            if (applications != null)
            {
                var application = applications.FirstOrDefault(a => a.UserId == model.UserId);
                if (application != null)
                {
                    
                    if (model.ReasonId != null)
                    {
                        application.ApplicationStateId = 2;
                        application.ReasonId = model.ReasonId ?? 1;
                    }
                    else
                    {
                        application.ApplicationStateId = 1;
                        application.ReasonId = 1;
                    }
                    
                    await _graduateService.EvaluateUserApplicationAsync(application);
                }
            }
            
            return RedirectToAction("GetApplications", "Admin");
        }

        private async Task<IEnumerable<SelectListItem>> GetReasonsForSelectList()
        {
            var reasons = await _graduateService.GetReasonsAsync();
            return reasons.Select(p => new SelectListItem() { Text = p.ReasonName, Value = p.Id.ToString() });
        }


        [HttpGet]
        public async Task<IActionResult> GetGraduateProgramDetails(int programId)
        {
            var program = await _graduateService.GetGraduateProgramWithInfoByProgramIdAsync(programId);
            return PartialView("_GetGraduateProgramDetails", program);
        }
        public async Task<IActionResult> DeleteGraduateProgram(int programId)
        {
            await _graduateService.DeleteGraduateProgramByProgramIdAsync(programId);
            _memoryCache.Remove("IndexPageModelData");
            return RedirectToAction("Index", "Admin");
        }
        public async Task<IActionResult> Help()
        {
            var mails = await _mailService.GetMailsAsync();
            return View(mails);
        }
        [HttpPost]
        public async Task<IActionResult> SendMail(string mailAddress, string message, int mailId)
        {
            var controller = this;
            await _mailService.SendMailAsync(controller, mailAddress, message, mailId);
            return RedirectToAction("Help", "Admin");
        }
    }
}
