using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingWebsite.BLL.ViewModel.Dialog;
using MeetingWebsite.DAL.Interfaces;
using MeetingWebsite.Models.Entities;
using Microsoft.AspNetCore.Http;

namespace MeetingWebsite.BLL.Services
{
    public class DialogService: IDialogService
    {
        private readonly IUnitOfWork _database;
        private readonly IAccountService _accountService;
        private readonly IFileService _fileService;

        public DialogService(IUnitOfWork database,
            IAccountService accountService,
            IFileService fileService)
        {
            _database = database;
            _accountService = accountService;
            _fileService = fileService;
        }

        public async Task<List<Dialog>> FindAllDialogs(string userId)
        {
            var user = await _accountService.GetUser(userId);

            var incomingDialogs = user.IncomingMessages.Where(x =>
                x.ReceiverId == userId).ToList();

            var outgoingDialogs = user.OutgoingMessages.Where(x =>
                x.SenderId == userId).ToList();

            var dialogs = new List<Dialog>();
            dialogs.AddRange(incomingDialogs);
            dialogs.AddRange(outgoingDialogs);

            return dialogs;
        }

        public Dialog FindDialog(int id)
        {
            return _database.DialogRepository.Get(id);
        }

        public async Task<bool> IsExistDialog(string userId, string receiverId)
        {
            var user = await _accountService.GetUser(userId);

            var incomingDialogs = user.IncomingMessages.Where(x =>
                x.ReceiverId == userId && x.SenderId == receiverId)
                .ToList();

            var outgoingDialogs = user.OutgoingMessages.Where(x =>
                x.ReceiverId == receiverId && x.SenderId == userId)
                .ToList();

            var fullList = new List<Dialog>();
            fullList.AddRange(incomingDialogs);
            fullList.AddRange(outgoingDialogs);

            return !fullList.Any() ? true : false;
        }

        public async Task AddDialogMessage(string userId, string message, int dialogId, IFormFileCollection files)
        {
            var newMessage = new Message
            {
                SenderId = userId,
                IdDialog = dialogId,
                Text = message,
                Date = DateTime.Now,
                New = false
            };

            _database.MessageRepository.Create(newMessage);
            _database.Save();

            if (!files.Any())
            {
                await _fileService.AddDialogMessagePhotos(dialogId, newMessage.Id, files);
            }
        }

        public async Task<Dialog> GetDialogDetails(string userId, string companionId)
        {
            var user = await _accountService.GetUser(userId);

            var incomingDialogs = user.IncomingMessages.Where(x =>
                    x.ReceiverId == userId && x.SenderId == companionId)
                .ToList();

            var outgoingDialogs = user.OutgoingMessages.Where(x =>
                    x.ReceiverId == companionId && x.SenderId == userId)
                .ToList();

            var fullList = new List<Dialog>();
            fullList.AddRange(incomingDialogs);
            fullList.AddRange(outgoingDialogs);

            return fullList.First();
        }

        public Dialog CreateDialog(string receiverId, string senderId)
        {
            var newDialog = new Dialog
            {
                SenderId = senderId,
                ReceiverId = receiverId,
                Date = DateTime.Now
            };

            _database.DialogRepository.Create(newDialog);
            _database.Save();

            return newDialog;
        }
    }
}