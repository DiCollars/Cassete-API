using Cassete_API.Models.Album;
using Cassete_API.Models.Others;
using Cassete_API.Models.User;
using Cassete_API.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Cassete_API.Repository.Services
{
    public class AlbumService : IAlbumService
    {
        private ApplicationContext _context;

        public AlbumService(ApplicationContext context)
        {
            _context = context;
        }

        public void AddTrack(int trackId, int albumId)
        {
            if (_context.Tracks.Any(t => t.Id == trackId) && _context.Albums.Any(a => a.Id == albumId))
            {
                var newAlbumTrack = new AlbumTrackModel() { AlbumId = albumId, TrackId = trackId };
                _context.AlbumTracks.Add(newAlbumTrack);
                _context.SaveChangesAsync();
            }
        }

        public void Create(AlbumModel album)
        {
            _context.Albums.Add(album);
            _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var album = _context.Albums.FirstOrDefault(album => album.Id == id);

            _context.Albums.Remove(album);
            _context.SaveChangesAsync();
        }

        public void DeleteTrack(int trackId, int albumId)
        {
            var album = _context.AlbumTracks.FirstOrDefault(at => at.AlbumId == albumId && at.TrackId == trackId);

            _context.AlbumTracks.Remove(album);
            _context.SaveChangesAsync();
        }

        public AlbumModel Get(int id)
        {
            return _context.Albums.FirstOrDefault(a => a.Id == id);
        }

        public List<AlbumModel> GetAll()
        {
            return _context.Albums.ToList();
        }

        public void Update(AlbumModel album)
        {
            if (_context.Albums.Any(_album => _album.Id == album.Id))
            {
                _context.Albums.Update(album);
                _context.SaveChangesAsync();
            }
        }
    }
}
