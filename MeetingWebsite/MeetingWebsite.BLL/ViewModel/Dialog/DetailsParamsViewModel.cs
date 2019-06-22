using Microsoft.AspNetCore.Http;

namespace MeetingWebsite.BLL.ViewModel.Dialog
{
    public class DetailsParamsViewModel
    {
        public string Message { get; set; }
        public string ReceiverId { get; set; }
        public int DialogId { get; set; }
        public IFormFileCollection Files { get; set; }
    }
}