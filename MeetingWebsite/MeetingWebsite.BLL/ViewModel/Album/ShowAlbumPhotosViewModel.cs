using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.ViewModel
{
    public class ShowAlbumPhotosViewModel
    {
        //public List<int> IdPhoto { get; set; }
        //public List<string> PathPhoto { get; set; }

        public int IdPhoto { get; set; }
        public string PathPhoto { get; set; }

        public ShowAlbumPhotosViewModel(FileModel photos)
        {
            IdPhoto = photos.Id;
            PathPhoto = photos.User.HomeDir + photos.Album.Path + "/" +  photos.Name;

            //Photo = photos.User.HomeDir + photos.Path;
        }
    }
}