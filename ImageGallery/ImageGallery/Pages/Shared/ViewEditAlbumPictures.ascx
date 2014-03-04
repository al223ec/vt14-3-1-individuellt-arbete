<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewEditAlbumPictures.ascx.cs" Inherits="ImageGallery.Pages.Shared.ViewEditAlbumPictures" %>
<h2>
    <asp:Literal ID="AlbumNameLiteral" runat="server"></asp:Literal></h2>
<asp:ListView ID="PictureListView" runat="server" ItemType="ImageGallery.Model.Picture" SelectMethod="PictureListView_GetData"
    DataKeyNames="PictureID">
    <LayoutTemplate>
        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
    </LayoutTemplate>
    <ItemTemplate>
        <dl>
            <dt><%#: Item.Name %></dt>
            <dd>
                <dd>
                    <img src="../../Content/Images/Penguins.jpg" /></dd>
                <dd><%#: Item.Date %></dd>
                <dd><%#: Item.GetTumbFileName %></dd>
                <dd>
                    <asp:Button ID="Button1" runat="server" Text="Ta bort" />
                    <asp:Button ID="Button2" runat="server" Text="redigera" /></dd>
            </dd>
        </dl>
    </ItemTemplate>
    <EmptyDataTemplate>
        <p>
            Fail!! Inga bilder kan hittas vg försök igen
        </p>
    </EmptyDataTemplate>
</asp:ListView>
