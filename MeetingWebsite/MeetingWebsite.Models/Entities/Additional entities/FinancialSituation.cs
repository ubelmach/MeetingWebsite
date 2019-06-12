using System.ComponentModel.DataAnnotations;

namespace MeetingWebsite.Models.Entities
{
    public class FinancialSituation
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
    }
}