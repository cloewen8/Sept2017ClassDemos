<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FirstLinqSample.aspx.cs" Inherits="SamplePages_FirstLinqSample" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Albums for Artist</h1>
    <asp:Label ID="Label1" runat="server" Text="Select an artist: "></asp:Label>
    <asp:DropDownList ID="ArtistList" runat="server"
        DataSourceID="ArtistListODS"
        DataTextField="Name" DataValueField="ArtistId"></asp:DropDownList>
    <asp:Button ID="Button2" runat="server" Text="Submit" />
    <br />

    <asp:GridView ID="ArtistAlbumList" runat="server"
        AutoGenerateColumns="False" DataSourceID="ArtistAlbumListODS"
        AllowPaging="True">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title"></asp:BoundField>
            <asp:BoundField DataField="ReleaseYear" HeaderText="ReleaseYear" SortExpression="ReleaseYear"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ArtistListODS" runat="server"
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="Artists_List" TypeName="ChinookSystem.BLL.ArtistController"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ArtistAlbumListODS" runat="server"
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="ListForArtists" TypeName="ChinookSystem.BLL.AlbumController">
        <SelectParameters>
            <asp:ControlParameter ControlID="ArtistList"
                PropertyName="SelectedValue" DefaultValue="0"
                Name="artistId" Type="Int32"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
