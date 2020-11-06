using Cassete_API.Models.Album;
using Cassete_API.Models.User;
using System.Text.Json.Serialization;

namespace Cassete_API.Models.Others
{
    public class AlbumTrackModel
    {
        public int TrackId { get; set; }

        [JsonIgnore]
        public TrackModel TrackModel { get; set; }

        public int AlbumId { get; set; }

        [JsonIgnore]
        public AlbumModel AlbumModel { get; set; }
    }
}
