<%@ Page Title="Контакты" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="AjaxCorporation.LostFound.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Наши контакты:</h3>
    <address>
        г. Хороший<br />
        ул. Счастливая, 7<br />
        <abbr title="Телефон">Тел:</abbr>
        8(342)255-55-01
    </address>

    <address>
        <strong>Служба поддержки:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Слуюба качества:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>
</asp:Content>
