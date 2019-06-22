using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingWebsite.Api.Hub;
using MeetingWebsite.BLL.Services;
using MeetingWebsite.BLL.ViewModel.Dialog;
using MeetingWebsite.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace MeetingWebsite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DialogController : ControllerBase
    {
        private readonly IDialogService _dialogService;
        private readonly IHubContext<ChatHub> _chatHub;

        public DialogController(IDialogService dialogService,
            IHubContext<ChatHub> chatHub)
        {
            _dialogService = dialogService;
            _chatHub = chatHub;
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


            var result = GetAllDialogsViewModel.MapToViewModels(userId, dialogs).ToList();

            return Ok(result);
        }

        //GET: api/dialog/DialogDetails/id
        [HttpGet, Route("DialogDetails/{id}")]
        public IActionResult Get(int id)
        {
            var userId = User.Claims.First(c => c.Type == "UserID").Value;
            var dialog = _dialogService.FindDialog(id);

            var result = DetailsDialogViewModel.MapToViewModel(dialog.Messages, userId).ToList();

            return Ok(result);
        }

        //POST: api/dialog/SendMessage
        [HttpPost, Route("SendMessage")]
        public async Task<IActionResult> SendMessage([Fro] DetailsParamsViewModel model)
        {
            try
            {
                UserIds receiver, caller;
                FindCallerReceiverByIds(model.ReceiverId, out caller, out receiver);

                var newMessage = _dialogService.AddDialogMessage(caller.UserId, model.Message, model.DialogId);
                var dialog = _dialogService.GetDialogDetails(caller.UserId, model.ReceiverId);
                var lastMessage = dialog.Result.Messages.Last();

                await _chatHub.Clients.Client(caller.ConnId).SendAsync("SendMyself", new AddDialogMessageViewModel(lastMessage));

                if (receiver != null)
                {
                    await _chatHub.Clients.Client(receiver.ConnId)
                        .SendAsync("Send", new AddDialogMessageViewModel(lastMessage), caller.UserId);

                    //await Clients.Client(receiver.ConnId).SendAsync("SoundNotify", "");
                }

                return Ok();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void FindCallerReceiverByIds(string receiverId, out UserIds caller, out UserIds receiver)
        {
            var connId = ChatHub._usersList
                .Where(x => x.UserId == User.Claims.First(c => c.Type == "UserID").Value)
                .Select(x => x.ConnId)
                .First();

            receiver =  ChatHub._usersList.Find(r => r.UserId == receiverId);
            caller = ChatHub._usersList.Find(c => c.ConnId == connId);
        }
    }
}