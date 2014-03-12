<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navigation.ascx.cs" Inherits="ImageGallery.Pages.Shared.Navigation" %>
<nav>
    <ul>
        <li runat="server">
            <asp:HyperLink runat="server" NavigateUrl='<%$ RouteUrl:routename=Default %>'>Album</asp:HyperLink></li>
        <li runat="server">
            <asp:HyperLink runat="server" NavigateUrl='<%$ RouteUrl:routename=ViewCategories %>'>Kategorier</asp:HyperLink></li>
    </ul>
</nav>
