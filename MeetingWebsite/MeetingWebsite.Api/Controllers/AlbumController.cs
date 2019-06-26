using System.Linq;
using System.Threading.Tasks;
using MeetingWebsite.BLL.Services;
using MeetingWebsite.BLL.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace MeetingWebsite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private const int UploadFileMaxLength = 5 * 1024 * 1024;
        private const string CorrectType = "image/jpeg";

        private readonly IAlbumService _albumService;
        private readonly IAccountService _accountService;
        private readonly IFileService _fileService;

        public AlbumController(IAlbumService albumService,
            IAccountService accountService,
            IFileService fileService)
        {
            _albumService = albumService;
            _accountService = accountService;
            _fileService = fileService;
        }

        //GET: api/album/GetAllAlbum
        [HttpGet, Route("GetAllAlbum")]
        public IActionResult Get()
        {
            var userId = GetUserId();
            var albums = _albumService.FindAllAlbumsCurrentUser(userId).ToList();
            var showAlbumCurrentUser = albums.Select(item => new ShowCurrentUserAlbumViewModel(item)).ToList();

            if (showAlbumCurrentUser.Any())
            {
                return Ok(showAlbumCurrentUser);  
            }
            return BadRequest(new { message = "Error, current user has no albums" });
        }

        //GET: api/album/GetAllAlbumUser/id
        [HttpGet, Route("GetAllAlbumUser/{id}")]
        public IActionResult GetAlbum(string id)
        {
            var albums = _albumService.FindAllAlbumsCurrentUser(id).ToList();

            if (!albums.Any())
            {
                return BadRequest(new { message = "Error, user has no albums" });
            }

            var showAlbumCurrentUser = albums.Select(item => new ShowCurrentUserAlbumViewModel(item)).ToList();
            return Ok(showAlbumCurrentUser);
        }

        //GET: api/album/AlbumDetails
        [HttpGet, Route("AlbumDetails/{id}")]
        public IActionResult Get(int id)
        {
            var album = _albumService.OpenAlbum(id);
            if (album == null)
            {
                return NotFound();
            }

            var photoAlbum = _fileService.FindPhotosInAlbum(id);
            var showAlbumPhotos = photoAlbum.Select(photo => new ShowAlbumPhotosViewModel(photo, id)).ToList();
            return Ok(showAlbumPhotos);
        }

        //POST: api/album/CreateAlbum
        [HttpPost, Route("CreateAlbum")]
        public async Task<IActionResult> Post([FromBody] CreateAlbumViewModel createAlbum)
        {
            if (createAlbum == null)
            {
                return BadRequest();
            }

            var user = await _accountService.GetUser(GetUserId());
            createAlbum.UserId = user.Id;
            createAlbum.HomeDir = user.HomeDir;

            var newAlbum = _albumService.CreateAlbum(createAlbum);
            if (newAlbum == null)
            {
                return BadRequest(new { message = "Error creating album" });
            }
            return Ok(newAlbum);
        }

        //PUT: api/album/AddPhotoInAlbum/id
        [HttpPut, Route("AddPhotoInAlbum/{id}")]
        public async Task<IActionResult> AddPhoto(int id)
        {
            var album = _albumService.FindAlbum(id);
            if (album == null)
            {
                return NotFound();
            }

            var addPhoto = new AddPhotoInAlbumViewModel();
            var files = HttpContext.Request.Form.Files;
            var userId = GetUserId();
            var user = await _accountService.GetUser(userId);
            addPhoto.AppendAdditionalInfo(album, user, files);

            foreach (var photo in addPhoto.Photos)
            {
                if (photo.ContentType != CorrectType)
                {
                    return BadRequest(new { message = "Error, allowed image resolution jpg / jpeg" });
                }

                if (photo.Length > UploadFileMaxLength)
                {
                    return BadRequest(new { message = "Error, permissible image size should not exceed 5 MB" });
                }
            }

            await _fileService.AddPhotoInAlbum(addPhoto);
            return Ok(addPhoto);
        }

        //DELETE: api/album/DeleteAlbum/id
        [HttpDelete, Route("DeleteAlbum/{id}")]
        public IActionResult DeleteAlbum(int id)
        {
            var album = _albumService.FindAlbum(id);
            if (album == null)
            {
                return NotFound();
            }
            _albumService.DeleteAlbum(id);
            return Ok();
        }

        //DELETE: api/album/DeletePhotoInAlbum
        [HttpDelete, Route("DeletePhotoInAlbum/{id}")]
        public IActionResult DeletePhotoInAlbum(int id)
        {
            var photo = _fileService.FindPhotoInAlbum(id);
            if (photo == null)
            {
                return NotFound();
            }
            _fileService.DeletePhotoInAlbum(id);
            return Ok();
        }

        private string GetUserId()
        {
            return User.Claims.First(c => c.Type == "UserID").Value;
        }
    }
}