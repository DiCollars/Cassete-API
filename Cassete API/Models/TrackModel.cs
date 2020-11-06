using Cassete_API.Models.Others;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Cassete_API.Models.User
{
    public class TrackModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        [JsonIgnore]
        public string Path { get; set; }

        [JsonIgnore]
        public List<AlbumTrackModel> AlbumTrackModels { get; set; }
    }
}
