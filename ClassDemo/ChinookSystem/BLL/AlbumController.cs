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
        public List<Album> Albums_List()
        {
            using (var context = new ChinookContext())
            {
                return context.Albums.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public Album Album_Get(int albumId)
        {
            using (var context = new ChinookContext())
            {
                return context.Albums.Find(albumId);
            }
        }
        
        public int Albums_Add(Album item)
        {
            using (var context = new ChinookContext())
            {
                item = context.Albums.Add(item);
                context.SaveChanges();
                return item.AlbumId;
            }
        }

        public int Albums_Update(Album item)
        {
            using (var context = new ChinookContext())
            {
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                return context.SaveChanges();
            }
        }

        public int Albums_Delete(int albumid)
        {
            using (var context = new ChinookContext())
            {
                var existingItem = context.Albums.Find(albumid);
                context.Albums.Remove(existingItem);
                return context.SaveChanges();

            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
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

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Album> Albums_ListByYearRelease(int minYear, int maxYear)
        {
            using (var context = new ChinookContext())
            {
                return (from album in context.Albums
                        where album.ReleaseYear >= minYear &&
                            album.ReleaseYear <= maxYear
                        orderby album.ReleaseYear, album.Title
                        select album).ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Album> Albums_ListByTitle(string title)
        {
            using (var context = new ChinookContext())
            {
                var results = from x in context.Albums
                              where x.Title.Contains(title)
                              orderby x.Title, x.ReleaseYear
                              select x;
                return results.ToList();
            }
        }//eom
    }
}
