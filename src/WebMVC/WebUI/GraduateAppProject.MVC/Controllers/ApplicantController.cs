using GraduateAppProject.DataTransferObjects.Responses.UserResponses;
using GraduateAppProject.Entities;
using GraduateAppProject.MVC.CacheTools;
using GraduateAppProject.MVC.Extensions;
using GraduateAppProject.MVC.Models;
using GraduateAppProject.WebMVC.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace GraduateAppProject.MVC.Controllers
{
    [Authorize(Roles = "Aday")]
    public class ApplicantController : Controller
    {
        private readonly IUserService _userService;
        private readonly IGraduateInformationService _graduateService;
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<ApplicantController> _logger;
        public ApplicantController(IUserService userService, IGraduateInformationService graduateInformationService, IMemoryCache memoryCache, ILogger<ApplicantController> logger)
        {
            _userService = userService;
            _graduateService = graduateInformationService;
            _memoryCache = memoryCache;
            _logger = logger;
        }

        public async Task<IActionResult> Index(int id)
        {
            var indexPageModel = await CachingExtensions.GetIndexPageModelFromCacheOrDb(_graduateService, _memoryCache,_logger);
            ApplicantInformationsModel infoModel = await GetApplicantInformationsModelAsync(id);

            var userLandingPageModel = new ApplicantLandingPageModel()
            {
                IndexPageModel = indexPageModel,
                ApplicantInformationsModel = infoModel
            };
            return View(userLandingPageModel);
        }

        //Cache'leme işlemini kullanıcı bilgilerini içeren model ile yapamam çünkü tüm kullanıcılar için ortak tutuluyor.
        //Yani kullanıcı bilgilerini session'a atıp, kullanıcı özel olmasını sağlamış olurken,
        //herkes için ortak olan Announcements ve GraduatePrograms modellerini cache ile tutabilirim. Çünkü herkes aynısnı görüyor.
        //Buna göre universiteler, fakülteler, bölümler ... gibi tabloların verilerini
        //uygulama ayağa kalktığında cache içerisinde saklayarak, her 24 saatte(veya haftada) bir yenilenmesini sağlayabilirim.
        //Böylece her lazım olduğunda veritabanına sorgu göndermeme gerek kalmaz.

        //private async Task<ApplicantInformationsModel> GetApplicantInfoFromCacheOrDb(int citizenId)
        //{
        //    if (!_memoryCache.TryGetValue("ApplicantInformationsModel", out CacheDataInfoForApplicantPages cacheDataInfo))
        //    {
        //        var options = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(1))
        //                                                   .SetPriority(CacheItemPriority.Normal);

        //        cacheDataInfo = new CacheDataInfoForApplicantPages()
        //        {
        //            CacheTime = DateTime.Now,
        //            ApplicantInformationsModel = await GetApplicantInformationsModelAsync(citizenId)
        //        };

        //        _memoryCache.Set("ApplicantInformationsModel", cacheDataInfo, options);
        //    }
        //    _logger.LogInformation($"{cacheDataInfo.CacheTime.ToLongTimeString()} anındaki cache'i görmektesiniz!");
        //    var infoModel = cacheDataInfo.ApplicantInformationsModel;
        //    return infoModel;
        //}

        private async Task<ApplicantInformationsModel> GetApplicantInformationsModelAsync(int citizenId)
        {
            //var userIdentityInfo = await _userService.GetUserIdentityInformationDTOByCitizenIdAsync(citizenId);
            //var userAlesExamsInfo = await _userService.GetUserAlesExamDTOByCitizenIdAsync(citizenId);
            //var bachelorDegreesInfo = await _userService.GetUserBachelorDegreeDTOByCitizenIdAsync(citizenId);
            //var doctorateDegreesInfo = await _userService.GetUserDoctorateDegreeDTOByCitizenIdAsync(citizenId);
            //var masterDegreesInfo = await _userService.GetUserMasterDegreeDTOByCitizenIdAsync(citizenId);
            //var ydsExamsInfo = await _userService.GetUserYdsExamDTOByCitizenIdAsync(citizenId);

            var infoModel = new ApplicantInformationsModel() 
            {
                UserIdentityInformationDTO = await _userService.GetUserIdentityInformationDTOByCitizenIdAsync(citizenId),
                UserAlesExamDTO = await _userService.GetUserAlesExamDTOByCitizenIdAsync(citizenId),
                UserBachelorDegreeDTO = await _userService.GetUserBachelorDegreeDTOByCitizenIdAsync(citizenId),
                UserDoctorateDegreeDTO = await _userService.GetUserDoctorateDegreeDTOByCitizenIdAsync(citizenId),
                UserMasterDegreeDTO = await _userService.GetUserMasterDegreeDTOByCitizenIdAsync(citizenId),
                UserYdsExamDTO = await _userService.GetUserYdsExamDTOByCitizenIdAsync(citizenId)
            };
            return infoModel;

        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
 