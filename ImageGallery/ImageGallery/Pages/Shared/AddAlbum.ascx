<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddAlbum.ascx.cs" Inherits="ImageGallery.Pages.Shared.AddAlbum" %>
<asp:FormView ID="AddAlbumFormView" runat="server" ItemType="ImageGallery.Model.Album"
    InsertMethod="AddAlbumFormView_InsertItem"
    DefaultMode="Insert">
    <InsertItemTemplate>
        <div>
           <h2>Lägg till album</h2>
            <p>
                <asp:Label ID="AlbumNameLabel" runat="server" Text="Ange albumnamnet"></asp:Label>
                <asp:TextBox ID="NewAlbumNameTextBox" runat="server" MaxLength="35" Text='<%#: BindItem.Name %>' ValidationGroup="InsertAlbum" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="NewAlbumNameTextBox" Text="*" CssClass="error" Display="Dynamic" ValidationGroup="InsertAlbum"></asp:RequiredFieldValidator>

                <%-- "Commandknappar" --%>
                <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Insert" Text="Lägg till" />
                <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Cancel" Text="Rensa" CausesValidation="false" />
            </p>

        </div>
    </InsertItemTemplate>
</asp:FormView>
