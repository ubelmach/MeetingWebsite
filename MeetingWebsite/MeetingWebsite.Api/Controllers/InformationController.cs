using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingWebsite.BLL.Services;
using MeetingWebsite.BLL.ViewModel.Information;
using MeetingWebsite.Models.Entities;
using MeetingWebsite.Models.EntityEnums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingWebsite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationController : ControllerBase
    {
        private readonly IPurposeService _purposeService;
        private readonly ILanguageService _languageService;
        private readonly IBadHabitsService _badHabitsService;
        private readonly IInterestsService _interestsService;
        private readonly IGenderService _genderService;
        private readonly IEducationService _educationService;
        private readonly IFinancialSituationService _financialSituationService;
        private readonly INationalityService _nationalityService;
        private readonly IZodiacSignsService _zodiacSignsService;

        public InformationController(
            IPurposeService purposeService,
            ILanguageService languageService,
            IBadHabitsService badHabitsService,
            IInterestsService interestsService,
            IGenderService genderService,
            IEducationService educationService,
            IFinancialSituationService financialSituationService,
            INationalityService nationalityService,
            IZodiacSignsService zodiacSignsService
            )
        {
            _purposeService = purposeService;
            _languageService = languageService;
            _badHabitsService = badHabitsService;
            _interestsService = interestsService;
            _genderService = genderService;
            _educationService = educationService;
            _financialSituationService = financialSituationService;
            _nationalityService = nationalityService;
            _zodiacSignsService = zodiacSignsService;
        }

        //GET: /api/user/GetInfo
        [HttpGet, Route("GetInfo")]
        public InfoViewModel GetResult()
        {
            var info = new InfoViewModel
            {
                Purposes = _purposeService.GetAll().ToList(),
                Languages = _languageService.GetAll().ToList(),
                BadHabits = _badHabitsService.GetAll().ToList(),
                Interests = _interestsService.GetAll().ToList(),
                Gender = _genderService.GetAll().ToList(),
                Education = _educationService.GetAll().ToList(),
                Finans = _financialSituationService.GetAll().ToList(),
                Nationality = _nationalityService.GetAll().ToList(),
                ZodiacSigns = _zodiacSignsService.GetAll().ToList()
            };

            return info;
        }
    }
}