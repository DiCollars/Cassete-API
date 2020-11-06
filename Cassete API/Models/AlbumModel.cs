using Cassete_API.Models.Others;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Cassete_API.Models.Album
{
    public class AlbumModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public List<AlbumTrackModel> AlbumTrackModels { get; set; }

        public int UserModelId { get; set; }

        [JsonIgnore]
        public UserModel UserModel { get; set; }
    }
}
