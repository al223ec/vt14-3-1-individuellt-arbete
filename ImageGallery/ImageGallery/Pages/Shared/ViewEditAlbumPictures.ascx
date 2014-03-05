<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewEditAlbumPictures.ascx.cs" Inherits="ImageGallery.Pages.Shared.ViewEditAlbumPictures" %>

<%@ Register Src="~/Pages/Shared/UploadPicture.ascx" TagPrefix="uc1" TagName="UploadPicture" %>

<asp:Image ID="MainImage" runat="server" Visible="false" />
<h2>
    <asp:Literal ID="AlbumNameLiteral" runat="server"></asp:Literal></h2>

<asp:ListView ID="PictureListView" runat="server" ItemType="ImageGallery.Model.Picture" SelectMethod="PictureListView_GetData"
    UpdateMethod="PictureListView_UpdateItem" DeleteMethod="PictureListView_DeleteItem" InsertItemPosition="LastItem"
    DataKeyNames="PictureID">
    <LayoutTemplate>
        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
    </LayoutTemplate>
    <ItemTemplate>
        <dl>
            <dt><%#: Item.Name %></dt>
            <dd>
                <asp:HyperLink NavigateUrl='<%# string.Format("{0}?name={1}", 
                            GetRouteUrl("ViewAlbumPictures", 
                            new { ID = AlbumID, name = AlbumName} ), Item.Name) %>' runat="server">
                    <asp:Image runat="server" ImageUrl="~/Content/Images/Penguins.jpg"/>
                </asp:HyperLink>
            </dd>
            <dd><%#: Item.Date %></dd>
            <dd><%#: Item.GetTumbFileName %></dd>
            <dd>
                <%-- "Commandknappar" --%>
                <asp:LinkButton runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false"
                    OnClientClick='<%# String.Format("return confirm(\"Är du säker att du vill ta bort {0}?\")", Item.Name) %>' />
                <asp:LinkButton runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false" />
            </dd>
        </dl>
    </ItemTemplate>
    <EditItemTemplate>
        <%-- Redigera. --%>
        <dl>
            <dt>
                <asp:TextBox ID="Name" runat="server" MaxLength="35" Text='<%# BindItem.Name %>' /></dt>
            <dd>
                <img src="../../Content/Images/Penguins.jpg" /></dd>
            <dd><%#: Item.Date %></dd>
            <dd><%#: Item.GetTumbFileName %></dd>
            <dd>

                <%-- "Commandknappar" --%>
                <asp:LinkButton runat="server" CommandName="Update" Text="Spara" />
                <asp:LinkButton runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
            </dd>
        </dl>
    </EditItemTemplate>
    <InsertItemTemplate>
            <uc1:UploadPicture runat="server" ID="UploadPictureControl" AlbumID='<%$ RouteValue:id %>' AlbumName="<%$ RouteValue:name%>"/>
    </InsertItemTemplate>
    <EmptyDataTemplate>
        <p>
            Fail!! Inga bilder kan hittas vg försök igen
        </p>
    </EmptyDataTemplate>
</asp:ListView>
