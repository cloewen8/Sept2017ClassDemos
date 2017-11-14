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
    public class PlaylistTracksController
    {
        public List<UserPlaylistTrack> List_TracksForPlaylist(
            string playlistname, string username)
        {
            using (var context = new ChinookContext())
            {
                List<UserPlaylistTrack> tracks;

                Playlist result = (from playlist in context.Playlists
                           where playlist.UserName.Equals(username) &&
                               playlist.Name.Equals(playlistname)
                           select playlist).FirstOrDefault();
                if (result == null)
                {
                    tracks = null;
                }
                else
                {
                    tracks = (from track in context.PlaylistTracks
                              where track.PlaylistId.Equals(result.PlaylistId)
                              orderby track.TrackNumber
                              select new UserPlaylistTrack
                              {
                                  TrackID = track.TrackId,
                                  TrackNumber = track.TrackNumber,
                                  TrackName = track.Track.Name,
                                  Milliseconds = track.Track.Milliseconds,
                                  UnitPrice = track.Track.UnitPrice
                              }).ToList();
                }

                return tracks;
            }
        }//eom
        public List<UserPlaylistTrack> Add_TrackToPLaylist(string playlistname, string username, int trackid)
        {
            using (var context = new ChinookContext())
            {
                Playlist existing = (from playlist in context.Playlists
                                 where playlist.UserName.Equals(username) &&
                                     playlist.Name.Equals(playlistname)
                                 select playlist).FirstOrDefault();
                int trackNumber;
                PlaylistTrack track = null;

                if (existing == null)
                {
                    trackNumber = 1;
                    // Create the playlist.
                    existing = new Playlist();
                    existing.Name = playlistname;
                    existing.UserName = username;
                    existing = context.Playlists.Add(existing);
                }
                else
                {
                    trackNumber = existing.PlaylistTracks.Count() + 1;
                    // Check for the track (must not already exist).
                    track = existing.PlaylistTracks.SingleOrDefault(othePlaylistTrack =>
                    othePlaylistTrack.TrackId == trackid);
                    if (track != null)
                    {
                        throw new Exception("The track already exists");
                    }
                }

                // Add the track.
                track = new PlaylistTrack();
                track.TrackId = trackid;
                track.TrackNumber = trackNumber;
                existing.PlaylistTracks.Add(track);

                context.SaveChanges();
                return List_TracksForPlaylist(playlistname, username);
            }
        }//eom
        public void MoveTrack(string username, string playlistname, int trackid, int tracknumber, string direction)
        {
            using (var context = new ChinookContext())
            {
                //code to go here 

            }
        }//eom


        public void DeleteTracks(string username, string playlistname, List<int> trackstodelete)
        {
            using (var context = new ChinookContext())
            {
               //code to go here


            }
        }//eom
    }
}
