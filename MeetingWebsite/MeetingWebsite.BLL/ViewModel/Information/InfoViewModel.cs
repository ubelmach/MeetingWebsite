using System.Collections.Generic;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.ViewModel.Information
{
    public class InfoViewModel
    {
        public IEnumerable<PurposeOfDating> PurposeOfDatings { get; set; }
        public IEnumerable<Languages> Languages { get; set; }
        public IEnumerable<BadHabits> BadHabits { get; set; }
        public IEnumerable<Interests> Interests { get; set; }
    }
}