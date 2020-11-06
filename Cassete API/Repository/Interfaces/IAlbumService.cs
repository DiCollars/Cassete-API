using Cassete_API.Models.Album;
using System.Collections.Generic;

namespace Cassete_API.Repository.Interfaces
{
    public interface IAlbumService
    {
        List<AlbumModel> GetAll();

        AlbumModel Get(int id);

        void Create(AlbumModel album);

        void Update(AlbumModel album);

        void Delete(int id);

        void AddTrack(int trackId, int albumId);

        void DeleteTrack(int trackId, int albumId);
    }
}
