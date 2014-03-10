<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/SiteTemplate.Master" AutoEventWireup="true" CodeBehind="ListPictures.aspx.cs" Inherits="ImageGallery.Pages.ImageGalleryPages.ListPictures" %>

<%@ Register Src="~/Pages/Shared/ViewDeleteAlbumPictures.ascx" TagPrefix="uc" TagName="ViewDeleteAlbumPictures" %>


<asp:Content ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h2>
    <asp:Literal ID="ImageNameLiteral" runat="server"></asp:Literal></h2>


    <uc:ViewDeleteAlbumPictures runat="server" ID="ViewDeleteAlbumPictures" AlbumID="<%$ RouteValue:id %>" />
</asp:Content>
