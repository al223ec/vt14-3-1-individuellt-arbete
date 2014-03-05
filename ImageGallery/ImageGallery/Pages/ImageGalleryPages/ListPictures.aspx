<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/SiteTemplate.Master" AutoEventWireup="true" CodeBehind="ListPictures.aspx.cs" Inherits="ImageGallery.Pages.ImageGalleryPages.ListPictures" %>

<%@ Register Src="~/Pages/Shared/ViewEditAlbumPictures.ascx" TagPrefix="uc" TagName="ViewEditAlbumPictures" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <uc:ViewEditAlbumPictures runat="server" ID="ViewEditAlbumPictures" AlbumID="<%$ RouteValue:id %>" AlbumName="<%$ RouteValue:name%>" />
    <%-- Skulle kunna ha upload templaten här --%>
</asp:Content>
