using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MeetingWebsite.BLL.Services;
using MeetingWebsite.BLL.ViewModel.Dialog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;

namespace MeetingWebsite.Api.Hub
{
    public class UserIds
    {
        public string UserId;
        public string ConnId;
    }

    public class ChatHub: Microsoft.AspNetCore.SignalR.Hub
    {
        private readonly IDialogService _dialogService;
        private readonly IAccountService _accountService;
        static List<UserIds> _usersList = new List<UserIds>();

        public ChatHub(IDialogService dialogService,
            IAccountService accountService)
        {
            _dialogService = dialogService;
            _accountService = accountService;
        }

        public override async Task OnConnectedAsync()
        {
            var caller = await _accountService.GetUserByEmail(Context.User.Identity.Name);
            UpdateList(caller.Id);
            await base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            _usersList.Remove(_usersList.Find(user => user.ConnId == Context.ConnectionId));
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendFromProfile(string message, string receiverId, int dialogId)
        {
            UserIds receiver, caller;
            FindCallerReceiverByIds(receiverId, out caller, out receiver);
            var file = Context.GetHttpContext().Request.Form.Files;
            var dialogExist = await _dialogService.IsExistDialog(caller.UserId, receiverId);
            if (dialogExist)
            {
                await _dialogService.AddDialogMessage(caller.UserId, message, dialogId, file);
                await Clients.Client(receiver.ConnId).SendAsync("Send", message, caller.UserId);
                //await Clients.Client(receiver.ConnId).SendAsync("SoundNotify", "");
            }
            else
            {
                _dialogService.CreateDialog(receiverId, caller.UserId);
                await _dialogService.AddDialogMessage(caller.UserId, message, dialogId, file);
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
                _usersList.Add(new UserIds{ConnId = Context.ConnectionId, UserId = callerId});
            }
        }

        private void FindCallerReceiverByIds(string receiverId, out UserIds caller, out UserIds receiver)
        {
            receiver = _usersList.Find(r => r.UserId == receiverId);
            caller = _usersList.Find(c => c.ConnId == Context.ConnectionId);
        }
    }
}