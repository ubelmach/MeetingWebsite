using System.ComponentModel.DataAnnotations;

namespace MeetingWebsite.BLL.ViewModel
{
    public class ChangePasswordViewModel
    {
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Password must contain at least 6 characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}