<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/SiteTemplate.Master" AutoEventWireup="true" CodeBehind="ListPictures.aspx.cs" Inherits="ImageGallery.Pages.ImageGalleryPages.ListPictures" %>

<%@ Register Src="~/Pages/Shared/ViewDeleteAlbumPictures.ascx" TagPrefix="uc" TagName="ViewDeleteAlbumPictures" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <asp:Panel ID="OutputPanel" runat="server" Visible="false" CssClass="success">
        <h4>
            <asp:Literal ID="HeaderOutputLiteral" runat="server" /></h4>
        <p>
            <asp:Literal ID="OutputLiteral" runat="server" />
        </p>
        <p>
            <asp:Button ID="Button" runat="server" Text="Stäng" CausesValidation="false" />
        </p>
    </asp:Panel>

    <uc:ViewDeleteAlbumPictures runat="server" ID="ViewDeleteAlbumPictures" AlbumID="<%$ RouteValue:id %>" />
</asp:Content>
