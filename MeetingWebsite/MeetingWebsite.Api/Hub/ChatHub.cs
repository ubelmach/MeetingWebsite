using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingWebsite.BLL.Services;
using MeetingWebsite.BLL.ViewModel.Dialog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace MeetingWebsite.Api.Hub
{
    public class UserIds
    {
        public string UserId;
        public string ConnId;
    }

    //[Authorize]
    public class ChatHub : Microsoft.AspNetCore.SignalR.Hub
    {
        private readonly IDialogService _dialogService;
        static List<UserIds> _usersList = new List<UserIds>();

        public ChatHub(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public override async Task OnConnectedAsync()
        {
            var callerId = Context.User.Claims.First(c => c.Type == "UserID").Value;
            UpdateList(callerId);
            await base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            _usersList.Remove(_usersList.Find(user => user.ConnId == Context.ConnectionId));
            return base.OnDisconnectedAsync(exception);
        }

        public async Task Send(string message, string receiverId, int dialogId)
        {
            UserIds receiver, caller;
            FindCallerReceiverByIds(receiverId, out caller, out receiver);
            var file = Context.GetHttpContext().Request.Form.Files;
            await _dialogService.AddDialogMessage(caller.UserId, message, dialogId, file);
            await Clients.Client(caller.ConnId).SendAsync("SendMyself", message);
            if (receiver != null)
            {
                await Clients.Client(receiver.ConnId).SendAsync("Send", message, caller.UserId);
                
                //await Clients.Client(receiver.ConnId).SendAsync("SoundNotify", "");
            }
        }

        public async Task SendFromProfile(string message, string receiverId)
        {
            UserIds receiver, caller;
            FindCallerReceiverByIds(receiverId, out caller, out receiver);

            var file = Context.GetHttpContext().Request.Form.Files;

            var dialogExist = await _dialogService.IsExistDialog(caller.UserId, receiverId);
            if (dialogExist)
            {
                var dialog = _dialogService.GetDialogDetails(caller.UserId, receiverId);
                await _dialogService.AddDialogMessage(caller.UserId, message, dialog.Id, file);

                await Clients.Client(receiver.ConnId).SendAsync("Send", message, caller.UserId);

                //await Clients.Client(receiver.ConnId).SendAsync("SoundNotify", "");
            }
            else
            {
                var dialog =  _dialogService.CreateDialog(receiverId, caller.UserId);
                await _dialogService.AddDialogMessage(caller.UserId, message, dialog.Id, file);
                var dialogDetails = _dialogService.GetDialogDetails(caller.UserId, receiverId);
                var result = JsonConvert.SerializeObject(dialogDetails);
                if (receiver != null)
                {
                    await Clients.Client(receiver.ConnId).SendAsync("AddNewDialog", message, result);
                    //await Clients.Client(receiver.ConnId).SendAsync("SoundNotify", "");
                }
            }
        }

        private void UpdateList(string callerId)
        {
            var index = _usersList.FindIndex(x => x.UserId == callerId);
            if (index != -1 && _usersList[index].ConnId != Context.ConnectionId)
            {
                _usersList[index].ConnId = Context.ConnectionId;
            }
            else
            {
                _usersList.Add(new UserIds { ConnId = Context.ConnectionId, UserId = callerId });
            }
        }

        private void FindCallerReceiverByIds(string receiverId, out UserIds caller, out UserIds receiver)
        {
            receiver = _usersList.Find(r => r.UserId == receiverId);
            caller = _usersList.Find(c => c.ConnId == Context.ConnectionId);
        }
    }
}