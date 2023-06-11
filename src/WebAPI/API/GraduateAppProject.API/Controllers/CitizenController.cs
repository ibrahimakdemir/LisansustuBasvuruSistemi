using GraduateAppProject.DataTransferObjects;
using GraduateAppProject.DataTransferObjects.Requests;
using GraduateAppProject.DataTransferObjects.Responses;
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

        public CitizenController(ICitizenService citizenService, ICitizenInformationService citizenInformationService)
        {
            _citizenService = citizenService;
            _citizenInformationService = citizenInformationService;
        }


        //[HttpGet("{id:int}")]
        //public async Task<IActionResult> GetCitizenInformations(int id)
        //{
        //    var citizenInfo = await _citizenInformationService.GetCitizenInformationsModelByCitizenIdAsync(id);
        //    //var response = JsonSerializer.Serialize<CitizenInformationsModel>(citizenInfo);
        //    return Ok(citizenInfo);
        //}


        [HttpGet("[action]")]
        public async Task<IActionResult> GetAlesExamsByCitizenId(int id)
        {
            var alesExams = await _citizenInformationService.GetCitizenAlesExamsDTOByCitizenIdAsync(id);
            //if (alesExams == null)
            //{
            //    return NotFound();
            //}
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
