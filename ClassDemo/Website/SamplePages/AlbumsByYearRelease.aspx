<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AlbumsByYearRelease.aspx.cs" Inherits="SamplePages_AlbumsByYearRelease" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Albums by Year Released</h1>

    <asp:Label ID="MinYearLabel" runat="server" Text="Enter minimum year: "></asp:Label>
    <asp:TextBox ID="MinYear" runat="server"></asp:TextBox>
    <asp:Label ID="MaxYearLabel" runat="server" Text="Enter maximum year: "></asp:Label>
    <asp:TextBox ID="MaxYear" runat="server"></asp:TextBox>
    <asp:Button ID="Submit" runat="server" Text="Submit" />
    <br />

    <asp:GridView ID="AlbumsList" runat="server"
        AutoGenerateColumns="False" DataSourceID="AlbumsListODS"
        AllowPaging="True">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Title"
                SortExpression="Title"></asp:BoundField>
            <asp:BoundField DataField="ReleaseYear" HeaderText="ReleaseYear"
                SortExpression="ReleaseYear"></asp:BoundField>
            <asp:BoundField DataField="ReleaseLabel" HeaderText="ReleaseLabel"
                SortExpression="ReleaseLabel"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="AlbumsListODS" runat="server"
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="Albums_ListByYearRelease" TypeName="ChinookSystem.BLL.AlbumController">
        <SelectParameters>
            <asp:ControlParameter ControlID="MinYear" PropertyName="Text"
                DefaultValue="0" Name="minYear" Type="Int32"></asp:ControlParameter>
            <asp:ControlParameter ControlID="MaxYear" PropertyName="Text"
                DefaultValue="99999" Name="maxYear" Type="Int32"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
