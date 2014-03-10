<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewDeleteAlbumPictures.ascx.cs" Inherits="ImageGallery.Pages.Shared.ViewEditAlbumPictures" %>

<%@ Register Src="~/Pages/Shared/UploadEditPicture.ascx" TagPrefix="uc1" TagName="UploadEditPicture" %>
<asp:Image ID="MainImage" runat="server" Visible="false" />
<h2>
    <asp:Literal ID="AlbumNameLiteral" runat="server"></asp:Literal></h2>
<%--UpdateMethod="PictureListView_UpdateItem"--%>
<asp:ListView ID="PictureListView" runat="server" ItemType="ImageGallery.Model.Picture" SelectMethod="PictureListView_GetData"
    DeleteMethod="PictureListView_DeleteItem"
    OnItemDataBound="PictureListView_ItemDataBound"
    DataKeyNames="PictureID">
    <LayoutTemplate>
        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
    </LayoutTemplate>

    <ItemTemplate>
        <dl>
            <dt><%#: Item.Name %></dt>
            <dd>
                <asp:HyperLink NavigateUrl='<%# string.Format("{0}?name={1}", 
                            GetRouteUrl("ViewAlbumPicturesPictureID", 
                            new { ID = AlbumID, pictureID = Item.PictureID } ), Item.Name) %>'
                    runat="server">

                    <asp:Image runat="server" ImageUrl=<%#: Item.GetTumbFilePath %>/>
                </asp:HyperLink>
            </dd>
            <dd>
                <asp:Label ID="CategoryValueLabel" runat="server" />
            </dd>
            <dd><%#: Item.Date %></dd>
            <dd>
                <%-- "Commandknappar" --%>
                <asp:LinkButton runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false"
                    OnClientClick='<%# String.Format("return confirm(\"Är du säker att du vill ta bort {0}?\")", Item.Name) %>' />

                <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("EditPicture", new { id = AlbumID, pictureId = Item.PictureID }) %>' Text="Redigera" />
            </dd>
        </dl>
    </ItemTemplate>
    <EmptyDataTemplate>
        <p>
            Fail!! Inga bilder kan hittas vg försök igen
        </p>
    </EmptyDataTemplate>
</asp:ListView>
<uc1:UploadEditPicture runat="server" AlbumID='<%$ RouteValue:id %>' />
