<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/SiteTemplate.Master" AutoEventWireup="true" CodeBehind="ListAlbums.aspx.cs" Inherits="ImageGallery.Pages.ImageGalleryPages.ListAlbums" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:ListView ID="AlbumListView" runat="server" ItemType="ImageGallery.Model.Album" SelectMethod="AlbumListView_GetData" DataKeyNames="AlbumID"
        InsertMethod="AlbumListView_InsertItem"
        UpdateMethod="AlbumListView_UpdateItem"
        DeleteMethod="AlbumListView_DeleteItem"
        InsertItemPosition="LastItem">
        <LayoutTemplate>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
        </LayoutTemplate>
        <ItemTemplate>
            <dl>
                <dt><%#: Item.Name %></dt>
                <dd>
                    <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("ViewAlbumPictures", new { id = Item.AlbumID }) %>'>
                        Visa bilder
                    </asp:HyperLink>
                </dd>
                <dd><%#: Item.Date %></dd>
                <dd>
                    <asp:LinkButton ID="LinkButton5" runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false"
                        OnClientClick='<%# String.Format("return confirm(\"Är du säker att du vill ta bort {0}?\")", Item.Name) %>' />
                    <asp:LinkButton runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false" />
                </dd>
            </dl>
        </ItemTemplate>
        <EditItemTemplate>
            <dl>
                <dt>
                    <asp:TextBox ID="NameTextBox" runat="server" MaxLength="35" Text='<%# BindItem.Name %>'></asp:TextBox>
                </dt>
                <dd>
                     Visa bilder
                </dd>
                <dd><%#: Item.Date %></dd>
                <%-- "Commandknappar" --%>
                <dd>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" Text="Spara" />
                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
                </dd>
            </dl>
        </EditItemTemplate>
        <InsertItemTemplate>
            <div>
                <h2>Lägg till album</h2>
                <p>
                    <asp:Label ID="AlbumNameLabel" runat="server" Text="Ange albumnamnet"></asp:Label>
                    <asp:TextBox ID="NameTextBox" runat="server" MaxLength="35" Text='<%#: BindItem.Name %>'></asp:TextBox>
                    <%-- "Commandknappar" --%>
                    <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Insert" Text="Lägg till" />
                    <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Cancel" Text="Rensa" CausesValidation="false" />
                </p>
            </div>
        </InsertItemTemplate>
        <EmptyDataTemplate>
            <p>
                Fail!! Inga album kunde hittas. OMG!!!
            </p>
        </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
