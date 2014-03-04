<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/SiteTemplate.Master" AutoEventWireup="true" CodeBehind="ListAlbums.aspx.cs" Inherits="ImageGallery.Pages.ImageGalleryPages.ListAlbums" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:ListView ID="AlbumListView" runat="server" ItemType="ImageGallery.Model.Album" SelectMethod="AlbumListView_GetData" DataKeyNames="AlbumID">
        <LayoutTemplate>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
        </LayoutTemplate>
        <ItemTemplate>
            <dl>
                <dt><%#: Item.Name %></dt>
                <dd>
                    <dd>
                        <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("ViewAlbumPictures", new { id = Item.AlbumID, name = Item.Name }) %>'>
                            <img src="../../Content/Images/Penguins.jpg" /></asp:HyperLink>
                    </dd>
                    <dd><%#: Item.Date %></dd>
                </dd>
            </dl>
        </ItemTemplate>
        <EmptyDataTemplate>
            <p>
                Fail!! Inga album kunde hittas. 
            </p>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
