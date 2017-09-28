using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Chinook.Data.POCOs;

namespace Chinook.Data.DTOs
{
    public class AlbumDTO
    {
        public string Title { get; set; }

        public int ReleaseYear { get; set; }

        public int TracksCount { get; set; }

        public IEnumerable<TrackPOCO> Tracks { get; set; }
    }
}
