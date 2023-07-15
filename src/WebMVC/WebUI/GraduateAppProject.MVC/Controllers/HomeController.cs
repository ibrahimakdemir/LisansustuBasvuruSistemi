using GraduateAppProject.DataTransferObjects.Requests;
using GraduateAppProject.Entities;
using GraduateAppProject.MVC.CacheTools;
using GraduateAppProject.MVC.Extensions;
using GraduateAppProject.MVC.Models;
using GraduateAppProject.WebMVC.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;
using System.Security.Claims;
using System.Text.Json;

namespace GraduateAppProject.MVC.Controllers
{
    [Authorize(Roles = "Misafir")]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IGraduateInformationService _graduateService;
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _memoryCache;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMailService _mailService;



        public HomeController(IUserService userService, ILogger<HomeController> logger, IConfiguration configuration
                            , IGraduateInformationService graduateInformationService, IMemoryCache memoryCache, IHttpContextAccessor httpContextAccessor
                            , IMailService mailService)
        {
            _userService = userService;
            _logger = logger;
            _configuration = configuration;
            _graduateService = graduateInformationService;
            _memoryCache = memoryCache;
            _httpContextAccessor = httpContextAccessor;
            _mailService = mailService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (User.Identity.IsAuthenticated && User.IsInRole("Aday"))
            {
                return RedirectToAction("Index", "Applicant");
            }

            await HttpContext.SignOutAsync();
            var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Role, "Misafir")
                };
            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), authProperties);

            //For Login --> Password:123
            ViewData["Admin"] = ("VhwrcVkRa+41v3otU1vUFg==").DecryptWithHash(_configuration);
            ViewData["Aday"] = ("f12TZfT4Fn/pi3H8AfxXAQ==").DecryptWithHash(_configuration);



            //Burada cache'e attığım için kullanıcı tarafında bile sürekli veritabanına sorgu atmama gerek yok!
            //Ayrıca announcement veya graduate program'lar ile ilgili bir veri değişikliği söz konusu ise
            //o veri değişikliği yapıldığında memorycache içindeki bu bilgi de silinmelidir ki gelen ilk istekte güncel veri cache'e eklenmiş olsun!
            
            var indexPageModel = await CachingExtensions.GetIndexPageModelFromCacheOrDb(_graduateService, _memoryCache, _logger);

            ViewBag.Index = indexPageModel.Announcements.Count();


            return View(indexPageModel);
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (User.Identity.IsAuthenticated && User.IsInRole("Aday"))
            {
                return RedirectToAction("Index", "Applicant");
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                int userCitizenId = await GetUserCitizenId(loginModel);
                if (userCitizenId != 0)
                {
                    //Authorize
                    var userRole = await _userService.GetUserRoleByCitizenIdAsync(userCitizenId);
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Role, userRole)
                    };
                    var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties();
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), authProperties);


                    var userId = await _userService.GetUserIdByCitizenIdAsync(userCitizenId);
                    _httpContextAccessor.HttpContext.Session.SaveToSession("UserId", userId);

                    if (userRole == "Admin")
                    {
                        return RedirectToAction("Index", "Admin", new { id = userId }); //Session kullan
                    }
                    return RedirectToAction("Index", "Applicant", new { id = userId });
                }
                ModelState.AddModelError(string.Empty, "T.C. Kimlik Numarası/ Şifre Yanlış Veya Sisteme Kayıtlı Değilsiniz!");
            }
            return View(loginModel);
        }

        private async Task<int> GetUserCitizenId(LoginModel loginModel)
        {
            var citizenNumber = loginModel.CitizenNumber.ToString().EncryptWithHash(_configuration);
            var password = loginModel.Password.ToString().EncryptWithHash(_configuration);
            var userCitizenId = await _userService.CheckUserAsync(citizenNumber, password);
            return userCitizenId;
        }


        public IActionResult Register()
        {
            var errorMessage = TempData["ErrorMessage"] as string;
            if (!string.IsNullOrEmpty(errorMessage))
            {
                ModelState.AddModelError(string.Empty, errorMessage);
            }
            return View();
        }

        [HttpGet]
        public IActionResult RegisterStepTwo(int id, string citizenNumber)
        {
            var model = new UserRegisterModel()
            {
                CitizenId = id,
                CitizenNumber = citizenNumber
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult RegisterStepTwo(UserRegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var newUser = new CreateNewUserRequest()
                {
                    CitizenId = registerModel.CitizenId,
                    CitizenNumber = registerModel.CitizenNumber,
                    Email = registerModel.Email,
                    Password = registerModel.Password.EncryptWithHash(_configuration),
                };
                _userService.RegisterUser(newUser);
                return RedirectToAction("Login", "Home");
            }
            return View(registerModel);
        }

        [HttpPost]
        public async Task<IActionResult> CitizenCheck(CitizenCheckerModel citizenChecker)
        {

            var citizenId = citizenChecker.CheckAndGetCitizenId(_configuration);

            if (citizenId != 0)
            {
                var IsExists = await _userService.IsRegisteredAsync(citizenId);
                if (!IsExists)
                {
                    return RedirectToAction("RegisterStepTwo", "Home", new { id = citizenId, citizenNumber = citizenChecker.CitizenNumber });

                }
                return RedirectToAction("Login", "Home");

            }
            TempData["ErrorMessage"] = "Bilgiler Doğrulanamadı! Lütfen Girdiğiniz Bilgileri Kontrol Ediniz!";
            return RedirectToAction("Register", "Home");

        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        public IActionResult Help()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Help(CreateNewMailRequest request)
        {
            if (ModelState.IsValid)
            {
                if (request.IsRegistered)
                {
                    var userId = JsonSerializer.Deserialize<int>(_httpContextAccessor.HttpContext.Session.GetString("UserId"));
                    request.SenderId = userId;
                    var citizenId = await _userService.GetCitizenIdByUserIdAsync(userId);
                    var userContact = await _userService.GetUserContactInformationDTOByCitizenIdAsync(citizenId);
                    var userIdentity = await _userService.GetUserIdentityInformationDTOByCitizenIdAsync(citizenId);
                    request.GuestFirstName = userIdentity.FirstName;
                    request.GuestLastName = userIdentity.LastName;
                    request.GuestMailAddress = userContact.Email;
                }

                await _mailService.SaveMailAsync(request);
                ViewData["Sonuc"] = "Mesajınız Başarılı Bir Şekilde İletilmiştir. En Kısa Zamanda Sizinle Mail Yoluyla İletişime Geçilecektir.";
                if (request.IsRegistered)
                {
                    return RedirectToAction("Index", "Applicant");
                }
                return View();
            }
            return View(ModelState);
        }

        [AllowAnonymous]
        public IActionResult AccessDeniedPage()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (User.Identity.IsAuthenticated && User.IsInRole("Aday"))
            {
                return RedirectToAction("Index", "Applicant");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [AllowAnonymous]
        public async Task<IActionResult> AnnouncementsDetail(int id)
        {
            var indexPageModel = await CachingExtensions.GetIndexPageModelFromCacheOrDb(_graduateService, _memoryCache, _logger);

            var announcement = indexPageModel.Announcements.FirstOrDefault(a => a.Id == id);
            return View(announcement);

        }

    }
}