<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GetSportsman.ascx.cs" Inherits="SportSchool.GetSportsman" %>

<h2>Введите ФИО спортсмена и номер группы</h2>
<div>
    <asp:Label ID="LabelLastName" runat="server" Text="Фамилия: "></asp:Label><asp:TextBox ID="TextBoxLastName" runat="server"></asp:TextBox>
</div>
<div>
    <asp:Label ID="LabelFirstName" runat="server" Text="Имя: "></asp:Label><asp:TextBox ID="TextBoxFirstName" runat="server"></asp:TextBox>
</div>
<div>
    <asp:Label ID="LabelPatronymic" runat="server" Text="Отчество: "></asp:Label><asp:TextBox ID="TextBoxPatronymic" runat="server"></asp:TextBox>
</div>
<div>
    <asp:Label ID="LabelCodeGroup" runat="server" Text="Код группы: "></asp:Label><asp:TextBox ID="TextBoxCodeGroup" runat="server"></asp:TextBox>
</div>
<div>
    <asp:Button ID="ButtonFind" runat="server" Text="Найти" OnClick="ButtonFind_OnClick"/>
</div>

<h2>Информация о найденных спортсменах</h2>

<asp:Repeater ID="SportsmenRepeater" runat="server">
        <HeaderTemplate>
            <table border="1">
                <tr>
                    <th>Фамилия</th>
                    <th>Имя</th>
                    <th>Отчество</th>
                    <th>Код группы</th>
                </tr>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td><%# DataBinder.Eval(Container.DataItem, "LastName") %> </td>
                <td><%# DataBinder.Eval(Container.DataItem, "FirstName") %> </td>
                <td><%# DataBinder.Eval(Container.DataItem, "Patronymic") %> </td>
                <td><%# DataBinder.Eval(Container.DataItem, "CodeGroup") %> </td>
            </tr>
        </ItemTemplate>

        <FooterTemplate>
            </table>
        </FooterTemplate>

    </asp:Repeater>
