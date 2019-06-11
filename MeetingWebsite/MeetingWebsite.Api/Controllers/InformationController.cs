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

        public InformationController(
            IPurposeService purposeService,
            ILanguageService languageService,
            IBadHabitsService badHabitsService,
            IInterestsService interestsService)
        {
            _purposeService = purposeService;
            _languageService = languageService;
            _badHabitsService = badHabitsService;
            _interestsService = interestsService;
        }

        //GET: /api/user/GetInfo
        [HttpGet, Route("GetInfo")]
        public InfoViewModel GetResult()
        {
            var info = new InfoViewModel
            {
                PurposeOfDatings = _purposeService.GetAll().ToList(),
                Languages = _languageService.GetAll().ToList(),
                BadHabits = _badHabitsService.GetAll().ToList(),
                Interests = _interestsService.GetAll().ToList()
            };

            return info;
        }

        //GET: /api/user/ZodiacSigns
        [HttpGet, Route("ZodiacSigns")]
        public List<string> GetZodiacSigns()
        {
            return Enum.GetNames(typeof(ZodiacSigns)).ToList();
        }

        //GET: /api/user/Genders
        [HttpGet, Route("Genders")]
        public List<string> GetGenders()
        {
            return Enum.GetNames(typeof(Genders)).ToList();
        }
    }
}