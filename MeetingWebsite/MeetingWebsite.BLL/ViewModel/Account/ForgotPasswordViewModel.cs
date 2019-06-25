using System.ComponentModel.DataAnnotations;

namespace MeetingWebsite.BLL.ViewModel
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}