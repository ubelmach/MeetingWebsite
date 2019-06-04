using System.Collections;
using System.Collections.Generic;

namespace MeetingWebsite.BLL.ViewModel
{
    public class ShowAlbumPhotosViewModel
    {
        public IEnumerable<int> IdPhoto { get; set; }
        public IEnumerable<string> PathPhoto { get; set; }
    }
}