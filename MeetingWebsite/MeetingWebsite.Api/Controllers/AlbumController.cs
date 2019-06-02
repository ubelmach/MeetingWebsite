using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MeetingWebsite.BLL.Services;
using MeetingWebsite.BLL.ViewModel;
using MeetingWebsite.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingWebsite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private IAlbumService _albumService;
        private IAccountService _accountService;
        private IFileService _fileService;

        public AlbumController(IAlbumService albumService,
            IAccountService accountService,
            IFileService fileService)
        {
            _albumService = albumService;
            _accountService = accountService;
            _fileService = fileService;
        }

        //GET: api/album/GetAllAlbumCurrentUser
        [HttpGet, Route("GetAllAlbum")]
        public IActionResult Get()
        {
            var userId = GetUserId();
            var albums = _albumService.FindAllAlbumsCurrentUser(userId);

            var showAlbumCurrentUser = albums.Select(item => new ShowCurrentUserAlbumViewModel
            {
                Id = item.Id,
                Name = item.Name
            }).ToList();

            return Ok(showAlbumCurrentUser);
        }

        //GET: api/album/AlbumDetails
        [HttpGet, Route("AlbumDetails/{id}")]
        public IActionResult Get(int id)
        {
            var album = _albumService.OpenAlbum(id);
            if (album == null)
                return NotFound();

            var showAlbumPhotos = new ShowAlbumPhotosViewModel()
            {
                PathPhoto = album.Files.Where(x => x.AlbumId == id).Select(x => x.Path)
            };

            return Ok(showAlbumPhotos);
        }

        //POST: api/album/CreateAlbum
        [HttpPost, Route("CreateAlbum")]
        public IActionResult Post([FromForm] CreateAlbumViewModel createAlbum)
        {
            if (createAlbum == null)
                return BadRequest();

            var userId = GetUserId();
            var user = _accountService.GetUser(userId);
            createAlbum.UserId = userId;
            createAlbum.HomeDir = user.Result.HomeDir;

            var newAlbum = _albumService.CreateAlbum(createAlbum);
            if (newAlbum == null)
                return BadRequest(new { message = "Error creating album" });
            return Ok(newAlbum);
        }

        //PUT: api/album/AddPhotoInAlbum/id
        [HttpPut, Route("AddPhotoInAlbum/{id}")]
        public IActionResult AddPhoto([FromForm] int id, AddPhotoInAlbumViewModel photo)
        {
            if (photo == null)
                return BadRequest();

            var getAlbum = _albumService.FindAlbum(id);
            var userId = GetUserId();
            var user = _accountService.GetUser(userId);

            photo.AlbumId = getAlbum.Id;
            photo.AlbumName = getAlbum.Name;
            photo.HomeDir = user.Result.HomeDir;
            photo.UserId = userId;

            var addPhoto = _fileService.AddPhotoInAlbum(photo);
            if (addPhoto == null)
                return BadRequest(new {message = "Error adding photo"});
            return Ok(addPhoto);
        }

        //DELETE: api/album/DeleteAlbum/id
        [HttpDelete, Route("DeleteAlbum/{id}")]
        public IActionResult DeleteAlbum([FromForm] int id)
        {
            var album = _albumService.FindAlbum(id);
            if (album == null)
                return NotFound();
            _albumService.DeleteAlbum(id);
            return Ok();
        }

        //DELETE: api/album/DeletePhotoInAlbum
        [HttpDelete, Route("DeletePhotoInAlbum/{id}")]
        public IActionResult DeletePhotoInAlbum([FromForm] int id)
        {
            var photo = _fileService.FindPhotoInAlbum(id);
            if (photo == null)
                return NotFound();
            _fileService.DeletePhotoInAlbum(id);
            return Ok();
        }

        private string GetUserId()
        {
            return User.Claims.First(c => c.Type == "UserID").Value;
        }
    }
}