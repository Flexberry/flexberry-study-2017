<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GetConsumer.ascx.cs" Inherits="Web.GetConsumer" %>
<%@ Import namespace="NewPlatform.Flexberry.Web.Page" %>

<h2>Введите информацию о теплопотребителе</h2>
<div>
    <asp:Label ID="LabelCode" runat="server" Text="Код объекта: "></asp:Label>  <asp:TextBox ID="TextBoxCode" runat="server" CssClass="input-small"></asp:TextBox>
</div>
<div>
    <asp:Button ID="ButtonFind" runat="server" Text="Найти" OnClick="ButtonFind_OnClick" CssClass="btn"/>
</div>

<h2>Информация о найденном объекте</h2>
<asp:Panel ID="PanelConsumer" runat="server">
    <div>
        <div>
            Наименование:
            <asp:Label ID="LabelName" runat="server" Text=""></asp:Label>
        </div>

        <div>
            Дата регистрации:
            <asp:Label ID="LabelDateReg" runat="server" Text=""></asp:Label>
        </div>
        <div>
            Номер лицевого счета:
            <asp:Label ID="LabelAccount" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Panel>
<asp:Panel ID="PanelConsumerNotFound" runat="server">
    <div>
        <asp:Label ID="ErrorLabel" runat="server" Text="Объект не найден" ForeColor="red"></asp:Label>
    </div>
    <ac:WebObjectListView ID="WebObjectListView1" runat="server" Visible="true" />
    
</asp:Panel>

