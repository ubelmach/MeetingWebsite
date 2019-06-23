using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace MeetingWebsite.BLL.ViewModel.Dialog
{
    public class DetailsParamsViewModel
    {
        public int DialogId { get; set; }
        public string ReceiverId { get; set; }
        public string Message { get; set; }
        public IFormFileCollection Photo { get; set; }
    }
}