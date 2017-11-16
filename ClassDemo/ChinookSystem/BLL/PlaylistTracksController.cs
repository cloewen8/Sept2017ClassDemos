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
        public void MoveTrack(string username, string playlistname, int trackid, string direction)
        {
            using (var context = new ChinookContext())
            {
                // Get playlist id
                Playlist existing = (from playlist in context.Playlists
                                     where playlist.UserName.Equals(username) &&
                                         playlist.Name.Equals(playlistname)
                                     select playlist).FirstOrDefault();
                PlaylistTrack track = null;
                PlaylistTrack other = null;

                if (existing == null)
                {
                    throw new Exception("The playlist is missing.");
                }
                else
                {
                    int tracknumber;
                    track = existing.PlaylistTracks.Where(checking =>
                        checking.TrackId == trackid).FirstOrDefault();
                    tracknumber = track.TrackNumber;
                    
                    // FIXME: Messed up the directions. Check them later (username: AAdams, playlist: name2).
                    if (direction == "up")
                    {
                        // up
                        if (tracknumber > 1)
                        {
                            other = existing.PlaylistTracks.Where(checking =>
                                checking.TrackNumber == track.TrackNumber - 1).FirstOrDefault();

                            if (other == null)
                            {
                                throw new Exception("The track above is missing.");
                            }
                            else
                            {
                                other.TrackNumber++;
                                track.TrackNumber--;
                            }
                        }
                        else
                        {
                            throw new Exception("Unable to move the track up.");
                        }
                    }
                    else if (direction == "down")
                    {
                        // down
                        if (tracknumber < existing.PlaylistTracks.Count)
                        {
                            other = existing.PlaylistTracks.Where(checking =>
                                checking.TrackNumber == track.TrackNumber + 1).FirstOrDefault();

                            if (other == null)
                            {
                                throw new Exception("The track below is missing.");
                            }
                            else
                            {
                                other.TrackNumber--;
                                track.TrackNumber++;
                            }
                        }
                        else
                        {
                            throw new Exception("Unable to move the track up.");
                        }
                    }
                }
                context.Entry(track).Property(entity => entity.TrackNumber).IsModified = true;
                context.Entry(other).Property(entity => entity.TrackNumber).IsModified = true;
                context.SaveChanges();
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
