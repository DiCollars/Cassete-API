using Cassete_API.Models.Album;
using Cassete_API.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cassete_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController
    {
        private IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        //GET api/album
        [HttpGet]
        public List<AlbumModel> GetAll()
        {
            return _albumService.GetAll();
        }

        //GET api/album/5
        [HttpGet("{id}")]
        public AlbumModel Get(int id)
        {
            return _albumService.Get(id);
        }

        //POST api/album
        [Authorize]
        [HttpPost]
        public void CreateAlbum(AlbumModel album)
        {
            _albumService.Create(album);
        }

        //POST api/album
        [Route("add-track-to-album")]
        [Authorize]
        [HttpPost]
        public void AddTrackToAlbum([FromForm]int trackId, [FromForm]int albumId)
        {
            _albumService.AddTrack(trackId, albumId);
        }

        //PUT api/album
        [Authorize]
        [HttpPut]
        public void UpdateAlbum(AlbumModel album)
        {
            _albumService.Update(album);
        }

        //DELETE api/album/5
        [Authorize]
        [HttpDelete("{id}")]
        public void DeleteAlbum(int id)
        {
            _albumService.Delete(id);
        }

        //DELETE api/album/5
        [Authorize]
        [HttpDelete]
        public void DeleteTrackFromAlbum([FromForm] int trackId, [FromForm] int albumId)
        {
            _albumService.DeleteTrack(albumId, trackId);
        }
    }
}
