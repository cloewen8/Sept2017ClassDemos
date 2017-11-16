using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using ChinookSystem.BLL;
using Chinook.Data.POCOs;

#endregion
public partial class SamplePages_ManagePlaylist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Request.IsAuthenticated)
        {
            Response.Redirect("~/Account/Login.aspx");
        }
        else
        {
            TracksSelectionList.DataSource = null;
        }
    }

    protected void CheckForException(object sender, ObjectDataSourceStatusEventArgs e)
    {
        MessageUserControl.HandleDataBoundException(e);
    }

    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
        //PreRenderComplete occurs just after databinding page events
        //load a pointer to point to your DataPager control
        DataPager thePager = TracksSelectionList.FindControl("DataPager1") as DataPager;
        if (thePager !=null)
        {
            //this code will check the StartRowIndex to see if it is greater that the
            //total count of the collection
            if (thePager.StartRowIndex > thePager.TotalRowCount)
            {
                thePager.SetPageProperties(0, thePager.MaximumRows, true);
            }
        }
    }

    protected void ArtistFetch_Click(object sender, EventArgs e)
    {
        TracksBy.Value = "Artist";
        SearchArgID.Value = ArtistDDL.SelectedValue;
        TracksSelectionList.DataBind();
    }

    protected void MediaTypeFetch_Click(object sender, EventArgs e)
    {
        TracksBy.Value = "MediaType";
        SearchArgID.Value = MediaTypeDDL.SelectedValue;
        TracksSelectionList.DataBind();
    }

    protected void GenreFetch_Click(object sender, EventArgs e)
    {
        TracksBy.Value = "Genre";
        SearchArgID.Value = GenreDDL.SelectedValue;
        TracksSelectionList.DataBind();
    }

    protected void AlbumFetch_Click(object sender, EventArgs e)
    {
        TracksBy.Value = "Album";
        SearchArgID.Value = AlbumDDL.SelectedValue;
        TracksSelectionList.DataBind();
    }

    protected void PlayListFetch_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(PlaylistName.Text))
        {
            MessageUserControl.TryRun(() =>
            {
                PlaylistTracksController controller = new PlaylistTracksController();
                List<UserPlaylistTrack> tracks = controller.List_TracksForPlaylist(PlaylistName.Text, User.Identity.Name);
                PlayList.DataSource = tracks;
                PlayList.DataBind();
            }, "Playlist Found", "Your playlist was succesfully found.");
        }
        else
        {
            MessageUserControl.ShowInfo("Warning", "The playlist name is required.");
        }
    }

    protected void TracksSelectionList_ItemCommand(object sender,
        ListViewCommandEventArgs e)
    {
        if (!string.IsNullOrEmpty(PlaylistName.Text))
        {
            MessageUserControl.TryRun(() =>
            {
                // FIXME: May be setting the datasource for the wrong control. Check what was uploaded by the instructor.
                PlaylistTracksController controller = new PlaylistTracksController();
                List<UserPlaylistTrack> tracks = controller.Add_TrackToPLaylist(
                    PlaylistName.Text,
                    User.Identity.Name,
                    int.Parse(e.CommandArgument.ToString()));
                PlayList.DataSource = tracks;
                PlayList.DataBind();
            });
        }
        else
        {
            MessageUserControl.ShowInfo("Warning", "The playlist name is required.");
        }
    }

    protected void MoveUp_Click(object sender, EventArgs e)
    {
        if (PlayList.Rows.Count == 0)
        {
            MessageUserControl.ShowInfo("Unable to move tracks in an empty playlist.");
        }
        else if (string.IsNullOrEmpty(PlaylistName.Text))
        {
            MessageUserControl.ShowInfo("The playlist name is empty.");
        }
        else
        {
            MessageUserControl.TryRun(() =>
            {
                MoveTrack(GetMovingTrack(), "up");
            }, "Success", "The track has been moved up.");
        }
    }

    protected void MoveDown_Click(object sender, EventArgs e)
    {
        if (PlayList.Rows.Count == 0)
        {
            MessageUserControl.ShowInfo("Unable to move tracks in an empty playlist.");
        }
        else if (string.IsNullOrEmpty(PlaylistName.Text))
        {
            MessageUserControl.ShowInfo("The playlist name is empty.");
        }
        else
        {
            MessageUserControl.TryRun(() =>
            {
                MoveTrack(GetMovingTrack(), "down");
            }, "Success", "The track has been moved down.");
        }
    }

    private int GetMovingTrack()
    {
        CheckBox box;
        int trackId = 0;
        int rowsSelected = 0;
        for (int i = 0; i < PlayList.Rows.Count; i++) {
            box = PlayList.Rows[i].FindControl("Selected") as CheckBox;
            if (box.Checked)
            {
                trackId = int.Parse((PlayList.Rows[i].FindControl("TrackId") as Label).Text);
                rowsSelected++;
            }
        }
        if (rowsSelected > 1)
        {
            throw new Exception("Select only one track.");
        }
        return trackId;
    }

    private void MoveTrack(int trackid, string direction)
    {
        PlaylistTracksController controller = new PlaylistTracksController();
        controller.MoveTrack(User.Identity.Name, PlaylistName.Text, trackid, direction);
        PlayList.DataSource = controller.List_TracksForPlaylist(PlaylistName.Text, User.Identity.Name);
        PlayList.DataBind();
    }

    protected void DeleteTrack_Click(object sender, EventArgs e)
    {
        //code to go here
    }
}
