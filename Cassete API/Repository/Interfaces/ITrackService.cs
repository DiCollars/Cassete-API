using Cassete_API.Models.User;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Cassete_API.Repository.Interfaces
{
    public interface ITrackService
    {
        List<TrackModel> GetAll();

        TrackModel Get(int id);

        string GetPath(int id);

        List<TrackModel> GetRandom();

        TrackModel Search(string name);

        void Add(string name, string author, IFormFile file);

        void Update(TrackModel trackModel);

        void Delete(int id);
    }
}
