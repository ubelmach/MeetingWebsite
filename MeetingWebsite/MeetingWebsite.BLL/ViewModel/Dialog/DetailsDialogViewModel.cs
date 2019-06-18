using System.Collections.Generic;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.ViewModel.Dialog
{
    public class DetailsDialogViewModel
    {
        public int DialogId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Avatar { get; set; }
        public List<Message> Messages { get; set; }

        //public DetailsDialogViewModel(Models.Entities.Dialog dialog)
        //{
        //    DialogId = dialog.Id;
        //    Firstname = dialog.
        //}
    }
}