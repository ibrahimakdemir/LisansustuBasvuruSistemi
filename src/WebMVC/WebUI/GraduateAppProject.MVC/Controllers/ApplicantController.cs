using GraduateAppProject.DataTransferObjects.Responses.UserResponses;
using GraduateAppProject.Entities;
using GraduateAppProject.MVC.CacheTools;
using GraduateAppProject.MVC.Extensions;
using GraduateAppProject.MVC.Models;
using GraduateAppProject.WebMVC.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace GraduateAppProject.MVC.Controllers
{
    [Authorize(Roles = "Aday")]
    public class ApplicantController : Controller
    {
        private readonly IUserService _userService;
        private readonly IGraduateInformationService _graduateService;
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<ApplicantController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _hostEnvironment;
        public ApplicantController(IUserService userService, IGraduateInformationService graduateInformationService, IMemoryCache memoryCache, ILogger<ApplicantController> logger, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment hostEnvironment)
        {
            _userService = userService;
            _graduateService = graduateInformationService;
            _memoryCache = memoryCache;
            _logger = logger;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index(int id)
        {
            var session = _httpContextAccessor.HttpContext.Session.GetString("UserId");

            if (id == 0 && session == null)
            {
                await HttpContext.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
            else if (id == 0 && session != null)
            {
                id = JsonSerializer.Deserialize<int>(session);
            }

            if (session == null)
            {
                _httpContextAccessor.HttpContext.Session.SaveToSession("UserId", id);
            }

            var indexPageModel = await CachingExtensions.GetIndexPageModelFromCacheOrDb(_graduateService, _memoryCache, _logger);
            ApplicantInformationsModel infoModel = await GetApplicantInformationsModelAsync(id);
            infoModel.UserIdentityInformationDTO.CitizenNumber = (infoModel.UserIdentityInformationDTO.CitizenNumber).DecryptWithHash(_configuration);
            var userLandingPageModel = new ApplicantLandingPageModel()
            {
                IndexPageModel = indexPageModel,
                ApplicantInformationsModel = infoModel
            };
            return View(userLandingPageModel);
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
                //var infoModel = await GetApplicantInformationsModelAsync(userId);
                var infoModel = await GetApplicantInformationsExtensions.GetApplicantInformationsModelAsync(userId, _userService);
                var citizenNumber = (infoModel.UserIdentityInformationDTO.CitizenNumber).DecryptWithHash(_configuration);
                infoModel.UserIdentityInformationDTO.CitizenNumber = citizenNumber;
                return View(infoModel);
            }

            return RedirectToAction("Index", "Applicant");

        }

        public async Task<IActionResult> MyApplications()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }

            var session = _httpContextAccessor.HttpContext.Session.GetString("UserId");
            if (session != null)
            {
                var userId = JsonSerializer.Deserialize<int>(session);
                var userApplications = await _userService.GetUserApplicationProgramByUserIdAsync(userId);

                var userApplicationAllInfo = new List<UserApplicationsWithStateAndReasonModel>();

                return View(userApplications);
            }

            return RedirectToAction("Index", "Applicant");



        }
        public async Task<IActionResult> ApplyToPrograms()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }

            var indexPageModel = await CachingExtensions.GetIndexPageModelFromCacheOrDb(_graduateService, _memoryCache, _logger);
            ViewBag.GraduateProgramsForSelectList = await GetOpenedGraduateProgramsForSelectList(indexPageModel.GraduatePrograms);
            return View(indexPageModel.GraduatePrograms);


        }

        public async Task<IActionResult> Apply(int programId)
        {
            if (programId != 0)
            {
                var session = _httpContextAccessor.HttpContext.Session.GetString("UserId");
                if (session != null)
                {
                    var userId = JsonSerializer.Deserialize<int>(session);
                    var userApplications = await _userService.GetUserApplicationProgramByUserIdAsync(userId);

                    var existingApplication = userApplications.FirstOrDefault(a => a.Id == programId);
                    if (existingApplication != null)
                    {

                        TempData["Message"] = "Bu programa zaten başvurmuşsunuz!";
                        return RedirectToAction("MyApplications", "Applicant");
                    }

                    await _userService.ApplyToProgramAsync(userId, programId);

                    TempData["Message"] = "Başvurunuz başarıyla tamamlandı.";
                    return RedirectToAction("MyApplications", "Applicant");
                }
                TempData["Message"] = "Oturum açmanız gerekmektedir!";
                return RedirectToAction("MyApplications", "Applicant");
            }
            TempData["Message"] = "Lütfen başvurmak istediğiniz programı seçiniz!";
            return RedirectToAction("ApplyToPrograms", "Applicant");

        }

        private async Task<IEnumerable<SelectListItem>> GetOpenedGraduateProgramsForSelectList(IList<GraduateProgram> graduatePrograms)
        {
            return graduatePrograms.Select(gp => new SelectListItem()
            {
                Text = gp.GraduateMajor.GraduateMajorName + "/" + gp.Language.LanguageName + "/" + (gp.WithThesis ? "Tezli" : "Tezsiz"),
                Value = gp.Id.ToString()
            });
        }
        [HttpGet]
        public async Task<IActionResult> GetGraduateProgramDetails(int programId)
        {
            var program = await _graduateService.GetGraduateProgramWithInfoByProgramIdAsync(programId);
            return PartialView("_GetGraduateProgramDetails", program);
        }




        #region Caching Not
        //Cache'leme işlemini kullanıcı bilgilerini içeren model ile yapamam çünkü tüm kullanıcılar için ortak tutuluyor.
        //Yani kullanıcı bilgilerini session'a atıp, kullanıcı özel olmasını sağlamış olurken,
        //herkes için ortak olan Announcements ve GraduatePrograms modellerini cache ile tutabilirim. Çünkü herkes aynısnı görüyor.
        //Buna göre universiteler, fakülteler, bölümler ... gibi tabloların verilerini
        //uygulama ayağa kalktığında cache içerisinde saklayarak, her 24 saatte(veya haftada) bir yenilenmesini sağlayabilirim.
        //Böylece her lazım olduğunda veritabanına sorgu göndermeme gerek kalmaz.
        #endregion
        private async Task<ApplicantInformationsModel> GetApplicantInformationsModelAsync(int userId)
        {
            var citizenId = await _userService.GetCitizenIdByUserIdAsync(userId);
            var infoModel = new ApplicantInformationsModel()
            {
                UserContactInformationDTO = await _userService.GetUserContactInformationDTOByCitizenIdAsync(citizenId),
                UserIdentityInformationDTO = await _userService.GetUserIdentityInformationDTOByCitizenIdAsync(citizenId),
                UserAlesExamDTO = await _userService.GetUserAlesExamDTOByCitizenIdAsync(citizenId),
                UserBachelorDegreeDTO = await _userService.GetUserBachelorDegreeDTOByCitizenIdAsync(citizenId),
                UserDoctorateDegreeDTO = await _userService.GetUserDoctorateDegreeDTOByCitizenIdAsync(citizenId),
                UserMasterDegreeDTO = await _userService.GetUserMasterDegreeDTOByCitizenIdAsync(citizenId),
                UserYdsExamDTO = await _userService.GetUserYdsExamDTOByCitizenIdAsync(citizenId)
            };
            return infoModel;

        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> UpdateContactInfo(UserContactInformationDTO contactInformationDTO)
        {
            var session = _httpContextAccessor.HttpContext.Session.GetString("UserId");
            if (session != null)
            {
                var userId = JsonSerializer.Deserialize<int>(session);

                await _userService.UpdateUserContactInformationsByUserIdAsync(userId, contactInformationDTO.Email, contactInformationDTO.PhoneNumber, contactInformationDTO.Address);

            }

            return RedirectToAction("GetMyInformations", "Applicant");
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> UpdatePhoto(IFormFile photoFile)
        {
            var session = _httpContextAccessor.HttpContext.Session.GetString("UserId");

            if (photoFile != null && photoFile.Length > 0 && session != null)
            {
                var userId = JsonSerializer.Deserialize<int>(session);
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "uploads/ProfilePhotos");
                string fileName = userId + Path.GetExtension(photoFile.FileName);
                string filePath = Path.Combine(uploadsFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await photoFile.CopyToAsync(fileStream);
                }

                await _userService.UpdateUserPhotoURLByUserIdAsync(userId, $"/uploads/ProfilePhotos/{fileName}");


            }

            return RedirectToAction("GetMyInformations", "Applicant");
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
