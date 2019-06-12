using System.Collections.Generic;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.ViewModel.Information
{
    public class InfoViewModel
    {
        public IEnumerable<PurposeOfDating> Purposes { get; set; }
        public IEnumerable<Languages> Languages { get; set; }
        public IEnumerable<BadHabits> BadHabits { get; set; }
        public IEnumerable<Interests> Interests { get; set; }
        public IEnumerable<Gender> Gender { get; set; }
        public IEnumerable<Education> Education { get; set; }
        public IEnumerable<FinancialSituation> Finans { get; set; }
        public IEnumerable<Nationality> Nationality { get; set; }
        public IEnumerable<ZodiacSigns> ZodiacSigns { get; set; }
    }
}