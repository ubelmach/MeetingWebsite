using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingWebsite.BLL.Services;
using MeetingWebsite.BLL.ViewModel.Dialog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingWebsite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DialogController : ControllerBase
    {
        private readonly IDialogService _dialogService;

        public DialogController(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        //GET: api/dialog/GetAllDialogs
        [HttpGet, Route("GetAllDialogs")]
        public async Task<IActionResult> GetAll()
        {
            var userId = User.Claims.First(c => c.Type == "UserID").Value;
            var dialogs = await _dialogService.FindAllDialogs(userId);
            if (dialogs == null)
            {
                return BadRequest(new {message = "Error, you have no dialogs yet"});
            }

            return Ok(GetAllDialogsViewModel.MapToViewModels(userId, dialogs).ToList());
        }

        //GET: api/dialog/DialogDetails/id
        [HttpGet, Route("DialogDetails/{id}")]
        public IActionResult Get(int id)
        {
            var dialog = _dialogService.FindDialog(id);
            return null;
        }
    }
}