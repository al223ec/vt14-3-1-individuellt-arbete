<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UploadEditPicture.ascx.cs" Inherits="ImageGallery.Pages.Shared.UploadPicture" %>

<%-- Används i edit image --%>
<asp:Panel ID="uploadPanel" runat="server">
    <asp:Image ID="MainImage" runat="server" Visible="false" />
    <h4>
        <asp:Literal runat="server" ID="titleLiteral" Text="Ladda upp bild"></asp:Literal></h4>
    <%-- UploadPanel --%>
    <asp:FormView ID="UploadFormView" runat="server" ItemType="ImageGallery.Model.Picture"
        SelectMethod="UploadFormView_GetItem"
        UpdateMethod="UploadFormView_UpdateItem"
        InsertMethod="UploadFormView_InsertItem"
        DefaultMode="Insert"
        RenderOuterTable="false"
        DataKeyNames="pictureID">
        <EditItemTemplate>
            <asp:Label ID="NameLabel" runat="server" Text="Ange namn:" />
            <asp:TextBox ID="NameTextBox" runat="server" MaxLength="35" Text='<%# BindItem.Name %>' />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Var god ange ett namn för bilden" ControlToValidate="NameTextBox" CssClass="error" Text="*" Display="Dynamic" />
            <asp:Label ID="CategoryLabel" runat="server" Text="Kategori:" />

            <asp:DropDownList ID="CategoryDropDownList" runat="server"
                ItemType="ImageGallery.Model.Category"
                SelectMethod="CategoryDropDownList_GetData"
                DataTextField="Value"
                DataValueField="CategoryID"
                SelectedValue='<%# BindItem.CategoryID %>' />
            <p>
                <h2>Välj album</h2>
                <asp:RadioButtonList ID="AlbumRadioButtonList" runat="server"
                    RepeatLayout="Flow"
                    ItemType="ImageGallery.Model.Album"
                    SelectMethod="AlbumRadioButtonList_GetData"
                    DataTextField="Name"
                    DataValueField="AlbumID"
                    OnDataBound="AlbumRadioButtonList_DataBound" />
            </p>
            <asp:LinkButton runat="server" Text="Uppdatera bild" CommandName="Update" />
            <asp:HyperLink runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("ViewAlbumPictures", new { id = AlbumID})%>' />
        </EditItemTemplate>
        <InsertItemTemplate>
            <asp:FileUpload ID="ImageFileUpload" runat="server" OnDataBinding="ImageFileUpload_DataBinding" />

            <%-- Validering FileUpload, tomt fält och REGEX --%>
            <asp:RequiredFieldValidator ID="FileUploadRequiredFieldValidator" runat="server" ErrorMessage="Var god välj en bild" ControlToValidate="ImageFileUpload" CssClass="error" Text="*" Display="Dynamic" />
            <asp:RegularExpressionValidator ID="FileUploadRegularExpressionValidator" runat="server" ErrorMessage="Fel filändelse" ControlToValidate="ImageFileUpload" ValidationExpression="^.*\.(jpg|gif|png)$" CssClass="error" Text="*" Display="Dynamic" />

            <asp:Label ID="NameLabel" runat="server" Text="Ange namn" />
            <asp:TextBox ID="NameTextBox" runat="server" MaxLength="35" Text='<%# BindItem.Name %>' />
            <%-- Validering NameTextBox --%>
            <asp:RequiredFieldValidator runat="server" ErrorMessage="Var god ange ett namn för bilden" ControlToValidate="NameTextBox" CssClass="error" Text="*" Display="Dynamic" />

            <asp:Label ID="CategoryLabel" runat="server" Text="Kategori:" />
            <asp:DropDownList ID="CategoryDropDownList" runat="server"
                ItemType="ImageGallery.Model.Category"
                SelectMethod="CategoryDropDownList_GetData"
                DataTextField="Value"
                DataValueField="CategoryID"
                SelectedValue='<%# BindItem.CategoryID %>' />
            <p>
                <h2>Välj album</h2>
                <asp:RadioButtonList ID="AlbumRadioButtonList" runat="server"
                    RepeatLayout="Flow"
                    ItemType="ImageGallery.Model.Album"
                    SelectMethod="AlbumRadioButtonList_GetData"
                    DataTextField="Name"
                    DataValueField="AlbumID"
                    OnDataBound="AlbumRadioButtonList_DataBound" />
            </p>
            <asp:LinkButton runat="server" Text="Ladda upp" CommandName="Insert" />

        </InsertItemTemplate>
    </asp:FormView>
</asp:Panel>
