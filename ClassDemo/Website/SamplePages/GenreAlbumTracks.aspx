<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="GenreAlbumTracks.aspx.cs" Inherits="SamplePages_GenreAlbumTracks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Genre Album Tracks</h1>

    <asp:Repeater ID="GenreAlbumTrackList" runat="server"
        DataSourceID="GenreAlbumTrackListODS"
        ItemType="Chinook.Data.DTOs.GenreDTO">
        <ItemTemplate>
            <h2>Genre: <%# Eval("Genre") %></h2>
            <asp:Repeater ID="AlbumsTrackList" runat="server"
                DataSource='<%# Eval("Albums") %>'
                ItemType="Chinook.Data.DTOs.AlbumDTO">
                <ItemTemplate>
                    <h4>Album: <%# string.Format("{0} ({1}) Tracks: {2}",
                        Eval("Title"), Eval("ReleaseYear"), Eval("TracksCount")) %></h4>
                    <asp:Repeater ID="TrackList" runat="server"
                        DataSource='<%# Item.Tracks %>'
                        ItemType="Chinook.Data.POCOs.TrackPOCO">
                        <HeaderTemplate>
                            <table>
                                <tr>
                                    <th>Song</th>
                                    <th>Length</th>
                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%# Item.Name %></td>
                                <td><%# Item.Milliseconds %></td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </ItemTemplate>
                <SeparatorTemplate>
                    <hr style="height: 3px; border: none; color: aqua; background-color: aliceblue" />
                </SeparatorTemplate>
            </asp:Repeater>
        </ItemTemplate>
    </asp:Repeater>

    <asp:ObjectDataSource ID="GenreAlbumTrackListODS" runat="server"
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="Genre_GenreAlbumTracks" TypeName="ChinookSystem.BLL.GenreController"></asp:ObjectDataSource>
</asp:Content>
