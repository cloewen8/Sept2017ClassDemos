using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Data.DTOs
{
    public class GenreDTO
    {
        public string Genre { get; set; }

        public IEnumerable<AlbumDTO> Albums { get; set; }
    }
}
