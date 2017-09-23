<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FirstLinqSample.aspx.cs" Inherits="SamplePages_FirstLinqSample" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Albums for Artist</h1>
    <asp:Label ID="Label1" runat="server" Text="Select an artist: "></asp:Label>
    <asp:DropDownList ID="ArtistList" runat="server"></asp:DropDownList>
    <asp:Button ID="Button2" runat="server" Text="Submit" />
    <br />

    <asp:GridView ID="ArtistAlbumList" runat="server"></asp:GridView>
    <asp:ObjectDataSource ID="ArtistListODS" runat="server"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ArtistAlbumListODS" runat="server"></asp:ObjectDataSource>
</asp:Content>

