using System.ComponentModel.DataAnnotations;

namespace MeetingWebsite.Models.Entities
{
    public class ZodiacSigns
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }

        //public virtual UserProfile UserProfile { get; set; }
    }
}