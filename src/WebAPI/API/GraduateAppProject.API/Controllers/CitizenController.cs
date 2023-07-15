using GraduateAppProject.DataTransferObjects;
using GraduateAppProject.DataTransferObjects.Requests;
using GraduateAppProject.DataTransferObjects.Responses;
using GraduateAppProject.Infrastructure.Data;
using GraduateAppProject.Infrastructure.Models;
using GraduateAppProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GraduateAppProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitizenController : ControllerBase
    {
        private readonly ICitizenService _citizenService;
        private readonly ICitizenInformationService _citizenInformationService;
        private readonly ILogger<CitizenController> _logger;
        private readonly IConfiguration _configuration;
        public CitizenController(ICitizenService citizenService, ICitizenInformationService citizenInformationService, ILogger<CitizenController> logger, IConfiguration configuration)
        {
            _citizenService = citizenService;
            _citizenInformationService = citizenInformationService;
            _logger = logger;
            _configuration = configuration;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> ShowCitizensWithLogger()
        {
            var citizens = await _citizenService.GetCitizensAsync();
            var divider = "----------------------------------------";
            foreach (var citizen in citizens)
            {
                _logger.LogInformation($"Firstname: {citizen.FirstName}\n" +
                                       $"Lastname: {citizen.LastName}\n" +
                                       $"Birth Year: {citizen.BirthDate.Year}\n" +
                                       $"Citizen Number: {citizen.CitizenNumber.DecryptWithHash(_configuration)}\n" +
                                       $"{divider}\n ");
            }
            return Ok();
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetAlesExamsByCitizenId(int id)
        {
            var alesExams = await _citizenInformationService.GetCitizenAlesExamsDTOByCitizenIdAsync(id);
            return Ok(alesExams);
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetBachelorDegreesByCitizenId(int id)
        {
            var bachelorDegrees = await _citizenInformationService.GetCitizenBachelorDegreesDTOByCitizenIdAsync(id);

            return Ok(bachelorDegrees);
        }
        
        
        [HttpGet("[action]")]
        public async Task<IActionResult> GetDoctorateDegreesByCitizenId(int id)
        {
            var doctorateDegrees = await _citizenInformationService.GetCitizenDoctorateDegreesDTOByCitizenIdAsync(id);

            return Ok(doctorateDegrees);
        }
        
        [HttpGet("[action]")]
        public async Task<IActionResult> GetIdentityInformationsByCitizenId(int id)
        {
            var identityInformations = await _citizenInformationService.GetCitizenIdentityInformationsDTOByCitizenIdAsync(id);

            return Ok(identityInformations);
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetMasterDegreesByCitizenId(int id)
        {
            var masterDegrees = await _citizenInformationService.GetCitizenMasterDegreesDTOByCitizenIdAsync(id);
            return Ok(masterDegrees);
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetYdsExamsByCitizenId(int id)
        {
            var ydsExams = await _citizenInformationService.GetCitizenYdsExamsDTOByCitizenIdAsync(id);
            return Ok(ydsExams);
        }




        [HttpPost("[action]")]
        public async Task<IActionResult> CheckCitizen(CheckCitizenRequest request)
        {
            if (ModelState.IsValid)
            {
                var citizenId = await _citizenService.IsValidCitizenAsync(request);
                if (citizenId == 0)
                {
                    return NotFound();
                }
                return CreatedAtAction(nameof(GetIdentityInformationsByCitizenId), routeValues: new {id = citizenId},null);
            }
            return BadRequest(ModelState);
            

        }

        
    }
}
