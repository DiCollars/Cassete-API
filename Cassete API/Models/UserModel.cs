using Cassete_API.Models.Album;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Cassete_API.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Login { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public string Role { get; set; }

        [JsonIgnore]
        public List<AlbumModel> Albums { get; set; }
    }
}
