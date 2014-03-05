<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UploadPicture.ascx.cs" Inherits="ImageGallery.Pages.Shared.UploadPicture" %>

<asp:Panel ID="UploadPanel" runat="server">
    <h2>Ladda upp bild</h2>
    <asp:FileUpload ID="ImageFileUpload" runat="server" />


    <asp:Label ID="NameLabel" runat="server" Text="Bildnamn:" />
    <asp:TextBox ID="Name" runat="server" MaxLength="35" />

    <asp:Label ID="CategoryLabel" runat="server" Text="Kategori:" />
    <asp:DropDownList ID="CategoryDropDownList" runat="server"
        ItemType="ImageGallery.Model.Category"
        SelectMethod="CategoryDropDownList_GetData"
        DataTextField="Value"
        DataValueField="CategoryID" />
    <p>
        <asp:CheckBoxList ID="AlbumCheckBoxList" runat="server"
            RepeatLayout="Flow"
            ItemType="ImageGallery.Model.Album"
            SelectMethod="AlbumCheckBoxList_GetData"
            DataTextField="Name"
            DataValueField="AlbumID" />
    </p>
    <asp:Button ID="UploadButton" runat="server" Text="Ladda upp" OnClick="UploadButton_Click" />
    <%--        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Insert" Text="Lägg till" />--%>
    <%--<asp:LinkButton ID="LinkButton2" runat="server" CommandName="Cancel" Text="Rensa" CausesValidation="false" />--%>
</asp:Panel>

<%-- Validering, tomt fält och REGEX --%>
<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ErrorMessage="Var god välj en bild" ControlToValidate="FileUploader" CssClass="error"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" ErrorMessage="Fel filändelse" ControlToValidate="FileUploader" ValidationExpression="^.*\.(jpg|gif|png)$" CssClass="error"></asp:RegularExpressionValidator>--%>
