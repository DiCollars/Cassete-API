using Cassete_API.Models.User;
using Cassete_API.Repository.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cassete_API.Repository.Services
{
    public class TrackService : ITrackService
    {
        private ApplicationContext _context;

        IWebHostEnvironment _appEnvironment;

        public TrackService(ApplicationContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        public void Add(string name, string author, IFormFile file)
        {
            var currentTrack = new TrackModel()
            {
                Author = author,
                Name = name
            };

            if (file != null)
            {
                string path = "/Files/" + file.FileName;

                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                currentTrack.Path = path;
                _context.Tracks.Add(currentTrack);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var user = _context.Tracks.First(user => user.Id == id);
            _context.Tracks.Remove(user);
            _context.SaveChangesAsync();
        }

        public List<TrackModel> GetAll()
        {
            var alltracks = (from track in _context.Tracks select track).ToList();
            return alltracks;
        }

        public TrackModel Get(int id)
        {
            var alltracks = _context.Tracks.First(t => t.Id == id);
            return alltracks;
        }

        public List<TrackModel> GetRandom()
        {
            var allTracks = (from track in _context.Tracks select track).ToArray();

            var rand = new Random();
            for (int i = allTracks.Length - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);

                var tmp = allTracks[j];
                allTracks[j] = allTracks[i];
                allTracks[i] = tmp;
            }

            return allTracks.ToList();
        }

        public TrackModel Search(string name)
        {
            var currentTrack = (from track in _context.Tracks
                                where track.Name.ToLower().Contains(name.ToLower()) || track.Author.ToLower().Contains(name.ToLower())
                                select track).FirstOrDefault();

            return currentTrack;
        }

        public void Update(TrackModel trackModel)
        {
            _context.Tracks.Update(trackModel);
            _context.SaveChanges();
        }

        public string GetPath(int id)
        {
            return Path.Combine(_appEnvironment.ContentRootPath, "wwwroot" + Get(id).Path);
        }
    }
}
