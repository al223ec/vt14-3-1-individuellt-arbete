<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UploadPicture.ascx.cs" Inherits="ImageGallery.Pages.Shared.UploadPicture" %>

<asp:Panel ID="Panel1" runat="server">
    <h2>Ladda upp bild</h2>
    <asp:FileUpload ID="FileUploader" runat="server" />
    <asp:Button ID="UploadButton" runat="server" Text="Ladda upp" />
</asp:Panel>
<%-- Validering, tomt fält och REGEX --%>
<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ErrorMessage="Var god välj en bild" ControlToValidate="FileUploader" CssClass="error"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" ErrorMessage="Fel filändelse" ControlToValidate="FileUploader" ValidationExpression="^.*\.(jpg|gif|png)$" CssClass="error"></asp:RegularExpressionValidator>--%>
