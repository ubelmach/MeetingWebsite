using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeetingWebsite.Models.Entities
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public string PurposeOfDating { get; set; }
        public string MaritalStatus { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Education { get; set; }
        public string Nationality { get; set; }
        public string ZodiacSign { get; set; }
        public string KnowledgeOfLanguages { get; set; }
        public string BadHabits { get; set; }
        public string FinancialSituation { get; set; }
        public string Interests { get; set; }
    }
}