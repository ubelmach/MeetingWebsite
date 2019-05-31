using System;
using System.ComponentModel.DataAnnotations;

namespace MeetingWebsite.BLL.ViewModel
{
    public class UserProfileViewModel
    {
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}