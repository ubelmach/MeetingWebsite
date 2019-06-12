using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeetingWebsite.Models.Entities
{
    public class Gender
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
    }
}