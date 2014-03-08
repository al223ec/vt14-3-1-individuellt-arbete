<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/SiteTemplate.Master" AutoEventWireup="true" CodeBehind="ListPictures.aspx.cs" Inherits="ImageGallery.Pages.ImageGalleryPages.ListPictures" %>

<%@ Register Src="~/Pages/Shared/ViewDeleteAlbumPictures.ascx" TagPrefix="uc" TagName="ViewDeleteAlbumPictures" %>


<asp:Content ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h2>
    <asp:Literal ID="ImageNameLiteral" runat="server"></asp:Literal></h2>
    <asp:Image ID="MainImage" runat="server" Visible="false" />

    <uc:ViewDeleteAlbumPictures runat="server" ID="ViewDeleteAlbumPictures" AlbumID="<%$ RouteValue:id %>" AlbumName="<%$ RouteValue:name%>" />
    <%-- Skulle kunna ha upload templaten här --%>
</asp:Content>
