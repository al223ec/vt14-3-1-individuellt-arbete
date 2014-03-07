<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/SiteTemplate.Master" AutoEventWireup="true" CodeBehind="EditPicture.aspx.cs" Inherits="ImageGallery.Pages.ImageGalleryPages.EditPicture" %>
<%@ Register Src="~/Pages/Shared/UploadPicture.ascx" TagPrefix="uc1" TagName="UploadPicture" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <uc1:UploadPicture runat="server" AlbumID='<%$ RouteValue:id %>' AlbumName="<%$ RouteValue:name%>" PictureID="<%$ RouteValue:pictureId%>" />
</asp:Content>
