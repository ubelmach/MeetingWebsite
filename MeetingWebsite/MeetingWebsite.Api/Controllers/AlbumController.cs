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

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }
        
        //GET: api/album/GetAllAlbumCurrentUser
        [HttpGet, Route("GetAllAlbum")]
        public IActionResult Get()
        {
            var userId = User.Claims.First(c => c.Type == "UserID").Value;
            var albums = _albumService.FindAllAlbumsCurrentUser(userId);

            var showAlbumCurrentUser = albums.Select(item => new ShowCurrentUserAlbumViewModel
            {
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
                PathPhoto = album.Files.Where(x => x.AlbumId == id).Select(x =>x.Path)
            };

            return Ok(showAlbumPhotos);
        }

        //POST: api/album/CreateAlbum
        [HttpPost, Route("CreateAlbum")]
        public IActionResult Post([FromForm] CreateAlbumViewModel createAlbum)
        {
            if (createAlbum == null)
                return BadRequest();

            var userId = User.Claims.First(c => c.Type == "UserID").Value;
            createAlbum.UserId = userId;

            var newAlbum = _albumService.CreateAlbum(createAlbum);
            if (newAlbum == null)
                return BadRequest(new {message = "Error creating album"});
            return Ok(newAlbum);
        }

        //POST: api/album/AddPhotoInAlbum
        [HttpPost, Route("AddPhotoInAlbum")]
        public IActionResult AddPhoto([FromForm] AddPhotoInAlbumViewModel addPhoto)
        {
            return null;
        } 

    }
}