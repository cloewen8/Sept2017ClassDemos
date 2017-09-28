using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Chinook.Data.Entities;
using ChinookSystem.DAL;
using System.ComponentModel;
using Chinook.Data.DTOs;
using Chinook.Data.POCOs;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class GenreController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<GenreDTO> Genre_GenreAlbumTracks()
        {
            using (var context = new ChinookContext())
            {
                return (from genre in context.Genres
                        select new GenreDTO
                        {
                            Genre = genre.Name,
                            Albums = from track in genre.Tracks
                                     group track by track.Album into gResults
                                     select new AlbumDTO
                                     {
                                         Title = gResults.Key.Title,
                                         ReleaseYear = gResults.Key.ReleaseYear,
                                         TracksCount = gResults.Count(),
                                         Tracks = from track in gResults
                                                  select new TrackPOCO
                                                  {
                                                      Name = track.Name,
                                                      Milliseconds = track.Milliseconds
                                                  }
                                     }
                        }).ToList();
            }
        } 
    }
}
