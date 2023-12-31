﻿using GraduateAppProject.DataTransferObjects.Requests;
using GraduateAppProject.Infrastructure.Models;
using GraduateAppProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateAppProject.Services
{
    public class CitizenService : ICitizenService
    {
        private readonly ICitizenRepository _citizenRepository;

        public CitizenService(ICitizenRepository citizenRepository)
        {
            _citizenRepository = citizenRepository;
        }

        public Task<IList<Citizen>> GetCitizensAsync()
        {
            return _citizenRepository.GetAllAsync();
        }

        public IList<Citizen> GetCitizens()
        {
            return _citizenRepository.GetAll();
        }

        public int IsValidCitizen(CheckCitizenRequest request)
        {
            var citizenId = _citizenRepository.CheckCitizen(request.CitizenNumber, request.FirstName, request.LastName, request.BirthYear);

            return citizenId;
        }

        public async Task<int> IsValidCitizenAsync(CheckCitizenRequest request)
        {
            var citizenId = await _citizenRepository.CheckCitizenAsync(request.CitizenNumber, request.FirstName, request.LastName, request.BirthYear);

            return citizenId;
        }
    }
}
