using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cassete_API.Models.Track
{
    public class TrackViewModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public IFormFile Audio { get; set; }
    }
}
