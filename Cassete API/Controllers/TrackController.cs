using Cassete_API.Models.User;
using Cassete_API.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cassete_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : Controller
    {
        private ITrackService _trackService;
        public TrackController(ITrackService trackService)
        {
            _trackService = trackService;
        }

        //GET api/track/send
        [HttpGet]
        [Authorize]
        [Route("send")]
        public IActionResult Send([FromForm]int id)
        {
            return PhysicalFile(_trackService.GetPath(id), "application/mp3");
        }

        //GET api/track
        [HttpGet]
        public List<TrackModel> GetAll()
        {
            return _trackService.GetAll();
        }

        //GET api/track/random
        [Route("random")]
        [HttpGet]
        public List<TrackModel> GetRandom()
        {
            return _trackService.GetRandom();
        }

        //GET api/track/name
        [Authorize]
        [HttpGet("{name}")]
        public TrackModel Search(string name)
        {
            return _trackService.Search(name);
        }

        //POST api/track
        [Route("add")]
        [Authorize]
        [HttpPost]
        public void AddTrack([FromForm]string name, [FromForm] string author, [FromForm] IFormFile file)
        {
            _trackService.Add(name, author, file);
        }

        //PUT api/track
        [Authorize]
        [HttpPut]
        public void UpdateTrack([FromBody] TrackModel trackModel)
        {
            _trackService.Update(trackModel);
        }

        //DELETE api/track/5
        [Authorize]
        [HttpDelete("{id}")]
        public void DeleteTrack(int id)
        {
            _trackService.Delete(id);
        }
    }
}
