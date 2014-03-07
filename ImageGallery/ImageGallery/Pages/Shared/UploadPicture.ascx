<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UploadPicture.ascx.cs" Inherits="ImageGallery.Pages.Shared.UploadPicture" %>

<%-- Används i edit image --%>
<asp:Panel ID="uploadPanel" runat="server">
    <asp:Image ID="MainImage" runat="server" Visible="false" />
    <h2>Ladda upp bild</h2>
    <%-- UploadPanel --%>
    <asp:FormView ID="UploadFormView" runat="server" ItemType="ImageGallery.Model.Picture"
        SelectMethod="UploadFormView_GetItem"
        UpdateMethod="UploadFormView_UpdateItem"
        InsertMethod="UploadFormView_InsertItem"
        DefaultMode="Insert"
        RenderOuterTable="false"
        DataKeyNames="pictureID">
        <EditItemTemplate>
            <asp:FileUpload ID="ImageFileUpload" runat="server" OnDataBinding="ImageFileUpload_DataBinding" />

            <asp:Label ID="NameLabel" runat="server" Text="Ange namn:" />
            <asp:TextBox ID="NameTextBox" runat="server" MaxLength="35" Text='<%#: BindItem.Name %>' />
            <asp:Label ID="CategoryLabel" runat="server" Text="Kategori:" />

            <asp:DropDownList ID="CategoryDropDownList" runat="server"
                ItemType="ImageGallery.Model.Category"
                SelectMethod="CategoryDropDownList_GetData"
                DataTextField="Value"
                DataValueField="CategoryID"
                SelectedValue='<%#: BindItem.CategoryID %>' />

            <p>
                <asp:RadioButtonList ID="AlbumRadioButtonList" runat="server"
                    RepeatLayout="Flow"
                    ItemType="ImageGallery.Model.Album"
                    SelectMethod="AlbumRadioButtonList_GetData"
                    DataTextField="Name"
                    DataValueField="AlbumID"
                    OnDataBound="AlbumRadioButtonList_DataBound" />
            </p>
            <asp:LinkButton runat="server" Text="Uppdatera bild" CommandName="Update" />
            <asp:HyperLink runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("ViewAlbumPictures", new { id = AlbumID, name = AlbumName })%>' />

        </EditItemTemplate>
        <InsertItemTemplate>
            <asp:FileUpload ID="ImageFileUpload" runat="server" OnDataBinding="ImageFileUpload_DataBinding" />

            <asp:Label ID="NameLabel" runat="server" Text="Ange name" />
            <asp:TextBox ID="NameTextBox" runat="server" MaxLength="35" Text='<%#: BindItem.Name %>' />
            <asp:Label ID="CategoryLabel" runat="server" Text="Kategori:" />

            <asp:DropDownList ID="CategoryDropDownList" runat="server"
                ItemType="ImageGallery.Model.Category"
                SelectMethod="CategoryDropDownList_GetData"
                DataTextField="Value"
                DataValueField="CategoryID"
                SelectedValue='<%#: BindItem.CategoryID %>' />
            <p>
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
<%-- Validering, tomt fält och REGEX --%>
<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ErrorMessage="Var god välj en bild" ControlToValidate="FileUploader" CssClass="error"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" ErrorMessage="Fel filändelse" ControlToValidate="FileUploader" ValidationExpression="^.*\.(jpg|gif|png)$" CssClass="error"></asp:RegularExpressionValidator>--%>
