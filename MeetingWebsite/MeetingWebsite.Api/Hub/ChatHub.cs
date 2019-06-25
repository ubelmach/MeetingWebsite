using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingWebsite.BLL.Services;
using MeetingWebsite.BLL.ViewModel.Dialog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace MeetingWebsite.Api.Hub
{
    public class UserIds
    {
        public string UserId;
        public string ConnId;
    }

    public class ChatHub : Microsoft.AspNetCore.SignalR.Hub
    {
        public static List<UserIds> _usersList = new List<UserIds>();

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
    }
}