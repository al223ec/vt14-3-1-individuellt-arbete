<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/SiteTemplate.Master" AutoEventWireup="true" CodeBehind="ListCategories.aspx.cs" Inherits="ImageGallery.Pages.ImageGalleryPages.ListCategories" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:ListView ID="CategoryListView" runat="server" ItemType="ImageGallery.Model.Category" SelectMethod="CategoryListView_GetData" DataKeyNames="CategoryID">
        <LayoutTemplate>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
        </LayoutTemplate>
        <ItemTemplate>
            <dl>
                <dt><%#: Item.Value %></dt>
                <dd>
                 <%--   <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# GetRouteUrl("ViewCategoryPictures", new { id = Item.CategoryID }) %>'>
                            <img src="../../Content/Images/Penguins.jpg" /></asp:HyperLink>--%>
                </dd>
                <dd></dd>
            </dl>
        </ItemTemplate>
        <EmptyDataTemplate>
            <p>
                Fail!! Inga kategorier kunde hittas. OMG!!!
            </p>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
