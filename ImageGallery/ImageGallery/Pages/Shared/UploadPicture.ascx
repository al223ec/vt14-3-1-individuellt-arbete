<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UploadPicture.ascx.cs" Inherits="ImageGallery.Pages.Shared.UploadPicture" %>

<%-- Används i edit image --%>
<asp:Image ID="MainImage" runat="server" Visible="false" /> 
<h2>
    <asp:Literal ID="ImageNameLiteral" runat="server" Visible="false"></asp:Literal></h2>

<%-- UploadPanel --%>
<asp:Panel ID="UploadPanel" runat="server">
    <h2>Ladda upp bild</h2>
    <asp:FileUpload ID="ImageFileUpload" runat="server" />

    <asp:Label ID="NameLabel" runat="server" Text="Bildnamn:" />
    <asp:TextBox ID="NameTextBox" runat="server" MaxLength="35" />

    <asp:Label ID="CategoryLabel" runat="server" Text="Kategori:" />
    <asp:DropDownList ID="CategoryDropDownList" runat="server"
        ItemType="ImageGallery.Model.Category"
        SelectMethod="CategoryDropDownList_GetData"
        DataTextField="Value"
        DataValueField="CategoryID" />
    <p>
        <asp:RadioButtonList ID="AlbumRadioButtonList" runat="server"
            RepeatLayout="Flow"
            ItemType="ImageGallery.Model.Album"
            SelectMethod="AlbumRadioButtonList_GetData"
            DataTextField="Name"
            DataValueField="AlbumID" 
            OnDataBound="AlbumRadioButtonList_DataBound" 
            />
    </p>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="NameTextBox" />
    <asp:Button ID="UploadButton" runat="server" Text="Ladda upp" OnClick="UploadButton_Click" />
</asp:Panel>

<%-- Validering, tomt fält och REGEX --%>
<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ErrorMessage="Var god välj en bild" ControlToValidate="FileUploader" CssClass="error"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" ErrorMessage="Fel filändelse" ControlToValidate="FileUploader" ValidationExpression="^.*\.(jpg|gif|png)$" CssClass="error"></asp:RegularExpressionValidator>--%>
