<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewEditAlbumPictures.ascx.cs" Inherits="ImageGallery.Pages.Shared.ViewEditAlbumPictures" %>

<%@ Register Src="~/Pages/Shared/UploadPicture.ascx" TagPrefix="uc1" TagName="UploadPicture" %>

<asp:Image ID="MainImage" runat="server" Visible="false" />
<h2>
    <asp:Literal ID="AlbumNameLiteral" runat="server"></asp:Literal></h2>
<%--UpdateMethod="PictureListView_UpdateItem"--%>
<asp:ListView ID="PictureListView" runat="server" ItemType="ImageGallery.Model.Picture" SelectMethod="PictureListView_GetData"
     DeleteMethod="PictureListView_DeleteItem" 
    OnItemDataBound="PictureListView_ItemDataBound" DataKeyNames="PictureID">
    <LayoutTemplate>
        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
    </LayoutTemplate>

    <ItemTemplate>
        <dl>
            <dt><%#: Item.Name %></dt>
            <dd>
                <asp:HyperLink NavigateUrl='<%# string.Format("{0}?name={1}", 
                            GetRouteUrl("ViewAlbumPictures", 
                            new { ID = AlbumID, name = AlbumName} ), Item.Name) %>'
                    runat="server">
                    <asp:Image runat="server" ImageUrl="~/Content/Images/Penguins.jpg"/>
                </asp:HyperLink>
            </dd>
            <dd>
                <asp:Label ID="CategoryValueLabel" runat="server" />
            </dd>
            <dd><%#: Item.Date %></dd>
            <dd><%#: Item.GetTumbFileName %></dd>
            <dd>
                <%-- "Commandknappar" --%>
                <asp:LinkButton runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false"
                    OnClientClick='<%# String.Format("return confirm(\"Är du säker att du vill ta bort {0}?\")", Item.Name) %>' />

                <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("EditPicture", new { id = AlbumID, name = AlbumName, pictureId = Item.PictureID }) %>' Text="Redigera"/>
<%--                <asp:LinkButton runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false" />--%>
            </dd>
        </dl>
    </ItemTemplate>

 <%--   <EditItemTemplate>
        <%-- Redigera. --%>
<%--        <dl>
            <dt>
                <asp:TextBox ID="Name" runat="server" MaxLength="35" Text='<%# BindItem.Name %>' /></dt>
            <dd>
                <img src="../../Content/Images/Penguins.jpg" />

            </dd>
            <dd>
                <asp:DropDownList ID="CategoryDropDownList" runat="server" ItemType="ImageGallery.Model.Category"
                    SelectMethod="CategoryDropDownList_GetData"
                    DataTextField="Value"
                    DataValueField="CategoryID"
                    SelectedValue='<%# BindItem.CategoryID %>' />
            </dd>
            <dd><%#: Item.Date %></dd>
            <dd><%#: Item.GetTumbFileName %></dd>
            <dd>
                <%-- "Commandknappar" --%>
<%--                <asp:LinkButton runat="server" CommandName="Update" Text="Spara" />
                <asp:LinkButton runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
            </dd>
        </dl>
    </EditItemTemplate>--%>
    <EmptyDataTemplate>
        <p>
            Fail!! Inga bilder kan hittas vg försök igen
        </p>
    </EmptyDataTemplate>

</asp:ListView>
<uc1:UploadPicture runat="server" AlbumID='<%$ RouteValue:id %>' AlbumName="<%$ RouteValue:name%>" />
