<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/SiteTemplate.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="ImageGallery.Pages.Shared.Error" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="error">
        <h1>Serverfel!</h1>
        <p>
            Caosu, much errors!!
        </p>
        <p>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%$ RouteUrl:routename=Default %>'>Tillbaka till album</asp:HyperLink>
        </p>
    </div>
</asp:Content>
