using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Chinook.Data.Entities;
using Chinook.Data.DTOs;
using Chinook.Data.POCOs;
using ChinookSystem.DAL;
using System.ComponentModel;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class TrackController
    {
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<TrackList> List_TracksForPlaylistSelection(string tracksby, int argid)
        {
            using (var context = new ChinookContext())
            {
                IEnumerable<TrackList> results = null;

                switch (tracksby)
                {
                    case "Artist":
                        results = from track in context.Tracks
                                  orderby track.Name
                                  where track.Album.Artist.ArtistId == argid
                                  select new TrackList
                                  {
                                      TrackID = track.TrackId,
                                      Name = track.Name,
                                      Title = track.Album.Title,
                                      MediaName = track.MediaType.Name,
                                      GenreName = track.Genre.Name,
                                      Composer = track.Composer,
                                      Milliseconds = track.Milliseconds,
                                      Bytes = track.Bytes,
                                      UnitPrice = track.UnitPrice
                                  };
                        break;
                    case "MediaType":
                        results = from track in context.Tracks
                                  orderby track.Name
                                  where track.MediaType.MediaTypeId == argid
                                  select new TrackList
                                  {
                                      TrackID = track.TrackId,
                                      Name = track.Name,
                                      Title = track.Album.Title,
                                      MediaName = track.MediaType.Name,
                                      GenreName = track.Genre.Name,
                                      Composer = track.Composer,
                                      Milliseconds = track.Milliseconds,
                                      Bytes = track.Bytes,
                                      UnitPrice = track.UnitPrice
                                  };
                        break;
                    case "Genre":
                        results = from track in context.Tracks
                                  orderby track.Name
                                  where track.Genre.GenreId == argid
                                  select new TrackList
                                  {
                                      TrackID = track.TrackId,
                                      Name = track.Name,
                                      Title = track.Album.Title,
                                      MediaName = track.MediaType.Name,
                                      GenreName = track.Genre.Name,
                                      Composer = track.Composer,
                                      Milliseconds = track.Milliseconds,
                                      Bytes = track.Bytes,
                                      UnitPrice = track.UnitPrice
                                  };
                        break;
                    default: // Album
                        results = from track in context.Tracks
                                  orderby track.Name
                                  where track.Album.AlbumId == argid
                                  select new TrackList
                                  {
                                      TrackID = track.TrackId,
                                      Name = track.Name,
                                      Title = track.Album.Title,
                                      MediaName = track.MediaType.Name,
                                      GenreName = track.Genre.Name,
                                      Composer = track.Composer,
                                      Milliseconds = track.Milliseconds,
                                      Bytes = track.Bytes,
                                      UnitPrice = track.UnitPrice
                                  };
                        break;
                }

                return results.ToList();
            }
        }//eom

       
    }//eoc
}
