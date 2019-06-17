using MeetingWebsite.Models.Entities;

namespace MeetingWebsite.BLL.ViewModel
{
    public class ShowAlbumPhotosViewModel
    {
        public int IdAlbum { get; set; }
        public int IdPhoto { get; set; }
        public string PathPhoto { get; set; }

        public ShowAlbumPhotosViewModel(FileModel photos, int id)
        {
            IdPhoto = photos.Id;
            PathPhoto = photos.User.HomeDir + photos.Album.Path + "/" +  photos.Name;
            IdAlbum = id;
        }
    }
}