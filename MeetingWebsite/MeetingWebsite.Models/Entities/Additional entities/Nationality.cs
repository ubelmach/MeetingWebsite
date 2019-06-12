using System.ComponentModel.DataAnnotations;

namespace MeetingWebsite.Models.Entities
{
    public class Nationality
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
    }
}