using System;
using System.Linq;
using System.Threading.Tasks;
using MeetingWebsite.Api.Hub;
using MeetingWebsite.BLL.Services;
using MeetingWebsite.BLL.ViewModel.Dialog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace MeetingWebsite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DialogController : ControllerBase
    {
        private const int UploadFileMaxLength = 2 * 1024 * 1024;
        private const string CorrectType = "image/jpeg";

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
                return BadRequest(new { message = "Error, you have no dialogs yet" });
            }

            var allDialogs = GetAllDialogsViewModel.MapToViewModels(userId, dialogs).ToList();
            return Ok(allDialogs);
        }

        //GET: api/dialog/DialogDetails/id
        [HttpGet, Route("DialogDetails/{id}")]
        public IActionResult Get(int id)
        {
            var userId = User.Claims.First(c => c.Type == "UserID").Value;
            var dialog = _dialogService.FindDialog(id);
            var detailsDialog = DetailsDialogViewModel.MapToViewModel(dialog.Messages, userId).ToList();
            return Ok(detailsDialog);
        }

        //POST: api/dialog/SendMessage
        [HttpPost, Route("SendMessage")]
        public async Task<IActionResult> SendMessage([FromForm] DetailsParamsViewModel model)
        {
            UserIds receiver, caller;
            FindCallerReceiverByIds(model.ReceiverId, out caller, out receiver);

            if (model.Photo != null)
            {
                foreach (var photo in model.Photo)
                {
                    if (photo.ContentType != CorrectType)
                    {
                        return BadRequest(new { message = "Error, allowed image resolution jpg / jpeg" });
                    }

                    if (photo.Length > UploadFileMaxLength)
                    {
                        return BadRequest(new { message = "Error, permissible image size should not exceed 2 MB" });
                    }
                }
            }

            var newMessage = await _dialogService.AddDialogMessage(caller.UserId, model.Message, model.DialogId, model.Photo);
            var dialog = await _dialogService.GetDialogDetails(caller.UserId, model.ReceiverId);
            var lastMessage = dialog.Messages.Last();
            await _chatHub.Clients.Client(caller.ConnId).SendAsync("SendMyself", new AddDialogMessageViewModel(lastMessage));
            if (receiver != null)
            {
                await _chatHub.Clients.Client(receiver.ConnId).SendAsync("Send", new AddDialogMessageViewModel(lastMessage), caller.UserId);
                //await Clients.Client(receiver.ConnId).SendAsync("SoundNotify", "");
            }

            return Ok();
        }

        //POST: api/dialog/SendFromProfile
        [HttpPost, Route("SendFromProfile")]
        public async Task SendFromProfile([FromForm] DetailsParamsViewModel model)
        {

            UserIds receiver, caller;
            FindCallerReceiverByIds(model.ReceiverId, out caller, out receiver);
            var dialogExist = await _dialogService.IsExistDialog(caller.UserId, model.ReceiverId);
            if (dialogExist)
            {
                var dialog = await _dialogService.GetDialogDetails(caller.UserId, model.ReceiverId);
                var newMessage = await _dialogService.AddDialogMessage(caller.UserId, model.Message, dialog.Id, model.Photo);
                var lastMessage = dialog.Messages.Last();

                if (receiver != null)
                {
                    await _chatHub.Clients.Client(receiver.ConnId).SendAsync("Send", new AddDialogMessageViewModel(lastMessage), caller.UserId);
                    //await Clients.Client(receiver.ConnId).SendAsync("SoundNotify", "");
                }
            }
            else
            {
                var dialog = _dialogService.CreateDialog(model.ReceiverId, caller.UserId);
                await _dialogService.AddDialogMessage(caller.UserId, model.Message, dialog.Id, model.Photo);
                if (receiver != null)
                {
                    await _chatHub.Clients.Client(receiver.ConnId).SendAsync("AddNewDialog", model.Message);
                    //await Clients.Client(receiver.ConnId).SendAsync("SoundNotify", "");
                }
            }

        }

        private void FindCallerReceiverByIds(string receiverId, out UserIds caller, out UserIds receiver)
        {
            var connId = ChatHub._usersList
                .Where(x => x.UserId == User.Claims.First(c => c.Type == "UserID").Value)
                .Select(x => x.ConnId)
                .First();

            receiver = ChatHub._usersList.Find(r => r.UserId == receiverId);
            caller = ChatHub._usersList.Find(c => c.ConnId == connId);
        }
    }
}