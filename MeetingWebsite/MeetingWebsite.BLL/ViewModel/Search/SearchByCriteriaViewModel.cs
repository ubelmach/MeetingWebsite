using System.Collections.Generic;
using System.Data;

namespace MeetingWebsite.BLL.ViewModel
{
    public class SearchByCriteriaViewModel
    {
        public int AgeFrom { get; set; }
        public int AgeTo { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Genders { get; set; }
        public List<int> PurposeOfDating { get; set; }
        public List<int> Education { get; set; }
        public List<int> Nationality { get; set; }
        public List<int> ZodiacSign { get; set; }
        public List<int> KnowledgeOfLanguages { get; set; }
        public List<int> BadHabits { get; set; }
        public List<int> FinancialSituation { get; set; }
        public List<int> Interests { get; set; }
    }
}