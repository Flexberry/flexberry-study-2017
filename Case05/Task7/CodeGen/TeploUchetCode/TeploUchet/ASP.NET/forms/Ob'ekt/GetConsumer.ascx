<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GetConsumer.ascx.cs" Inherits="Web.GetConsumer" %>

<h2>Введите информацию о теплопотребителе</h2>
<div>
    <asp:Label ID="LabelCode" runat="server" Text="Код объекта: "></asp:Label>  <asp:TextBox ID="TextBoxCode" runat="server" CssClass="input-small"></asp:TextBox>
</div>
<div style="margin: 10px 0px">
    <asp:Button ID="ButtonFind" runat="server" Text="Найти" OnClick="ButtonFind_OnClick" CssClass="btn"/>
</div>


<asp:Panel ID="PanelConsumer" runat="server">
    <h2>Информация о найденном объекте</h2>
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
    
</asp:Panel>

