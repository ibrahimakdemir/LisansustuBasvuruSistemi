using GraduateAppProject.MVC.CacheTools;
using GraduateAppProject.MVC.Models;
using GraduateAppProject.WebMVC.Services;
using Microsoft.Extensions.Caching.Memory;

namespace GraduateAppProject.MVC.Extensions
{
    public static class CachingExtensions
    {
        public static async Task<IndexPageModel> GetIndexPageModelFromCacheOrDb(IGraduateInformationService _graduateService, IMemoryCache _memoryCache, ILogger _logger)
        {
            if (!_memoryCache.TryGetValue("IndexPageModelData", out CacheDataInfoForIndexPageModel cacheDataInfo))
            {
                var options = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(1))
                                                           .SetPriority(CacheItemPriority.Normal);

                cacheDataInfo = new CacheDataInfoForIndexPageModel()
                {
                    CacheTime = DateTime.Now,
                    IndexPageModel = await GetIndexPageModelFromDb(_graduateService)
                };
                _memoryCache.Set("IndexPageModelData", cacheDataInfo, options);
            }
            var indexPageModel = cacheDataInfo.IndexPageModel;
            _logger.LogInformation($"{cacheDataInfo.CacheTime.ToLongTimeString()} anındaki cache'i görmektesiniz!");
            return indexPageModel;
        }

        private static async Task<IndexPageModel> GetIndexPageModelFromDb(IGraduateInformationService _graduateService)
        {
            var announcementResponse = await _graduateService.GetAnnouncementDisplayResponsesAsync();
            var programs = _graduateService.GetGraduateProgramWithInfo();

            var indexPageModel = new IndexPageModel()
            {
                Announcements = announcementResponse.ToList(),
                GraduatePrograms = programs,
            };
            return indexPageModel;
        }
    }
}


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