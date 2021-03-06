﻿
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ManagePlaylist.aspx.cs" Inherits="SamplePages_ManagePlaylist" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
        <h1>Manage Playlists (UX TRX Sample)</h1>
    </div>
    <uc1:MessageUserControl runat="server" ID="MessageUserControl" />

    <div class="row">
        <div class="col-sm-2">
            <asp:Label ID="Label1" runat="server" Text="Artist"></asp:Label><br />
            <asp:DropDownList ID="ArtistDDL" runat="server" 
                DataSourceID="ArtistDDLODS" 
                DataTextField="DisplayText" 
                DataValueField="IDValueField"
                Width="150px">
            </asp:DropDownList><br />
            <asp:Button ID="ArtistFetch" runat="server" Text="Fetch" OnClick="ArtistFetch_Click" />
            <br /><br />
             <asp:Label ID="Label2" runat="server" Text="Media"></asp:Label><br />
            <asp:DropDownList ID="MediaTypeDDL" runat="server" 
                DataSourceID="MediaTypeDDLODS" 
                DataTextField="DisplayText" 
                DataValueField="IDValueField"
                Width="150px">
            </asp:DropDownList><br />
            <asp:Button ID="MediaTypeFetch" runat="server" Text="Fetch" OnClick="MediaTypeFetch_Click" />
            <br /><br />
             <asp:Label ID="Label3" runat="server" Text="Genre"></asp:Label><br />
            <asp:DropDownList ID="GenreDDL" runat="server" 
                DataSourceID="GenreDDLODS" 
                DataTextField="DisplayText" 
                DataValueField="IDValueField"
                Width="150px">
            </asp:DropDownList><br />
            <asp:Button ID="GenreFetch" runat="server" Text="Fetch" OnClick="GenreFetch_Click" />
            <br /><br />
             <asp:Label ID="Label4" runat="server" Text="Album"></asp:Label><br />
            <asp:DropDownList ID="AlbumDDL" runat="server" 
                DataSourceID="AlbumDDLODS" 
                DataTextField="DisplayText" 
                DataValueField="IDValueField"
                Width="150px">
            </asp:DropDownList><br />
            <asp:Button ID="AlbumFetch" runat="server" Text="Fetch" OnClick="AlbumFetch_Click" />
            <br /><br />
        </div>
        <div class="col-sm-10">
            <asp:Label ID="Label5" runat="server" Text="Tracks"></asp:Label>&nbsp;&nbsp;
            <asp:HiddenField ID="TracksBy" runat="server" ></asp:HiddenField>&nbsp;&nbsp;
            <asp:HiddenField ID="SearchArgID" runat="server" ></asp:HiddenField><br />
            <asp:ListView ID="TracksSelectionList" runat="server" 
                DataSourceID="TrackSelectionListODS"
                 OnItemCommand="TracksSelectionList_ItemCommand">
                <AlternatingItemTemplate>
                    <tr style="background-color: #FFFFFF; color: #284775;">
                        <td>
                            <asp:LinkButton ID="AddtoPlaylist" runat="server"
                                 CssClass="btn" CommandArgument='<%# Eval("TrackID") %>'>
                                <span aria-hidden="true" class="glyphicon glyphicon-plus"></span>
                            </asp:LinkButton>
                            </td>
                        <td>
                            <asp:Label Text='<%# Eval("Name") %>' runat="server" ID="NameLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("Title") %>' runat="server" ID="TitleLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("MediaName") %>' runat="server" ID="MediaNameLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("GenreName") %>' runat="server" ID="GenreNameLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("Composer") %>' runat="server" ID="ComposerLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("Milliseconds") %>' runat="server" ID="MillisecondsLabel" /></td>
                        <td>
                            <asp:Label Text='<%# string.Format("{0:0.00}",(int)Eval("Bytes") / 1000000m) %>' 
                                runat="server" ID="BytesLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("UnitPrice") %>' runat="server" ID="UnitPriceLabel" /></td>
                    </tr>
                </AlternatingItemTemplate>
           
                <EmptyDataTemplate>
                    <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                 <ItemTemplate>
                    <tr style="background-color: #E0FFFF; color: #333333;">
                        <td><asp:LinkButton ID="AddtoPlaylist" runat="server"
                                 CssClass="btn" CommandArgument='<%# Eval("TrackID") %>'>
                                <span aria-hidden="true" class="glyphicon glyphicon-plus"></span>
                            </asp:LinkButton>
                            </td>
                        <td>
                        
                            <asp:Label Text='<%# Eval("Name") %>' runat="server" ID="NameLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("Title") %>' runat="server" ID="TitleLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("MediaName") %>' runat="server" ID="MediaNameLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("GenreName") %>' runat="server" ID="GenreNameLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("Composer") %>' runat="server" ID="ComposerLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("Milliseconds") %>' runat="server" ID="MillisecondsLabel" /></td>
                        <td>
                            <asp:Label Text='<%#string.Format("{0:0.00}",(int)Eval("Bytes") / 1000000m) %>' runat="server" ID="BytesLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Eval("UnitPrice") %>' runat="server" ID="UnitPriceLabel" /></td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table runat="server" id="itemPlaceholderContainer" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" border="1">
                                    <tr runat="server" style="background-color: #E0FFFF; color: #333333;">
                                        <th runat="server">TrackID</th>
                                        <th runat="server">Name</th>
                                        <th runat="server">Title</th>
                                        <th runat="server">Media</th>
                                        <th runat="server">Genre</th>
                                        <th runat="server">Composer</th>
                                        <th runat="server">Msec</th>
                                        <th runat="server">(MB)</th>
                                        <th runat="server">UnitPrice</th>
                                    </tr>
                                    <tr runat="server" id="itemPlaceholder"></tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="text-align: center; background-color: #5D7B9D; font-family: Verdana, Arial, Helvetica, sans-serif; color: #FFFFFF">
                                <asp:DataPager runat="server" ID="DataPager1" PageSize="5" PagedControlID="TracksSelectionList">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
                                        <asp:NumericPagerField></asp:NumericPagerField>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>

            </asp:ListView>
            <br /><br />
            <asp:Label ID="Label6" runat="server" Text="Playlist Name:"></asp:Label>
            <asp:TextBox ID="PlaylistName" runat="server"></asp:TextBox>
            <asp:Button ID="PlayListFetch" runat="server" Text="Fetch" 
                OnClick="PlayListFetch_Click" />

            <%--enter 3 linkbuttons for move up, move down and delete--%>
            <asp:LinkButton ID="MoveUp" runat="server"
                    CssClass="btn" OnClick="MoveUp_Click" >
                <span aria-hidden="true" class="glyphicon glyphicon-chevron-up"></span>
            </asp:LinkButton>&nbsp;&nbsp;
            <asp:LinkButton ID="MoveDown" runat="server"
                    CssClass="btn" OnClick="MoveDown_Click" >
                <span aria-hidden="true" class="glyphicon glyphicon-chevron-down"></span>
            </asp:LinkButton>&nbsp;&nbsp;
            <asp:LinkButton ID="DeleteTrack" runat="server"
                    CssClass="btn" OnClick="DeleteTrack_Click" >
                <span aria-hidden="true" class="glyphicon glyphicon-remove"
                     style="color:red"></span>
            </asp:LinkButton>
            <br /><br />
            <asp:GridView ID="PlayList" runat="server" AutoGenerateColumns="False"
                 Caption="PlayList" GridLines="Horizontal" BorderStyle="None">
                <Columns>
                    <asp:TemplateField >
                        <ItemTemplate>
                            <asp:CheckBox ID="Selected" runat="server" />
                            <asp:Label runat="server" ID="TrackId"
                                Text='<%# Eval("TrackID") %>' Visible="false"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Track">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="TrackNumber"
                                Text='<%# Eval("TrackNumber") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="TrachName"
                                Text='<%# Eval("TrackName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Time (m:s)">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="Milliseconds"
                                Text='<%# string.Format("{0:0.0}", (int)Eval("Milliseconds")/60000m)  %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="($)">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="UnitPrice"
                                Text='<%# Eval("UnitPrice") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    No data to view for the playlist.
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>

    <asp:ObjectDataSource ID="ArtistDDLODS" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="List_ArtistNames" 
        TypeName="ChinookSystem.BLL.ArtistController"
         OnSelected="CheckForException">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="MediaTypeDDLODS" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="List_MediaTypeNames" 
        TypeName="ChinookSystem.BLL.MediaTypeController"
         OnSelected="CheckForException">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="GenreDDLODS" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="List_GenreNames" 
        TypeName="ChinookSystem.BLL.GenreController"
         OnSelected="CheckForException">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="AlbumDDLODS" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="List_AlbumTitles" 
        TypeName="ChinookSystem.BLL.AlbumController"
         OnSelected="CheckForException">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="TrackSelectionListODS" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="List_TracksForPlaylistSelection" 
        TypeName="ChinookSystem.BLL.TrackController"
         OnSelected="CheckForException">
        <SelectParameters>
            <asp:ControlParameter ControlID="TracksBy" PropertyName="Value" Name="tracksby" Type="String"></asp:ControlParameter>
            <asp:ControlParameter ControlID="SearchArgID" PropertyName="Value" Name="argid" Type="Int32"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

