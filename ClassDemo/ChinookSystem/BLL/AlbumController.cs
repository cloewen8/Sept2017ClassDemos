using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Chinook.Data.Entities;
using ChinookSystem.DAL;
using System.ComponentModel;
using Chinook.Data.POCOs;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class AlbumController
    {
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public List<ArtistAlbumByReleaseYear> ListForArtists(int artistId)
        {
            using (var context = new ChinookContext())
            {
                return (from album in context.Albums
                       where album.ArtistId.Equals(artistId)
                       select new ArtistAlbumByReleaseYear
                       {
                           Title = album.Title,
                           ReleaseYear = album.ReleaseYear
                       }).ToList();
            }
        }
    }
}
