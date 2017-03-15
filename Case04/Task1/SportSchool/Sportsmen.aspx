<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sportsmen.aspx.cs" Inherits="SportSchool.Sportsmen" %>
<%@ Import Namespace="SportSchool.DAL" %>
<%@ Import Namespace="SportSchool.Objects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Title %></h1>
    <h2>Добавить спортсмена</h2>
    <ul class="add-sportsman" style="list-style-type:none">
        <li class="last-name">
            <asp:Label ID="label1" runat="server" Text="Фамилия:"></asp:Label>
            <asp:TextBox ID="TextBoxLastName" runat="server"></asp:TextBox>
        </li>
        <li class="first-name">
            <asp:Label ID="label2" runat="server" Text="Имя:"></asp:Label>
            <asp:TextBox ID="TextBoxFirstName" runat="server"></asp:TextBox>
        </li>
        <li class="Patronymic">
            <asp:Label ID="label3" runat="server" Text="Отчество:"></asp:Label>
            <asp:TextBox ID="TextBoxPatronymic" runat="server"></asp:TextBox>
        </li>
        <li class="code-group">
            <asp:Label ID="label4" runat="server" Text="Код группы:"></asp:Label>
            <asp:TextBox ID="TextBoxCodeGroup" runat="server"></asp:TextBox>
        </li>
        <li>
           <asp:Button ID="ButtonAdd" runat="server" Text="Добавить" OnClick="ButtonAdd_Click"/>
        </li>
    </ul>

    <h2>Список спортсменов</h2>

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
                <td><a href="<%= Request.Url.AbsoluteUri + "?sportsman="%><%# ((Sportsman)DataBinder.GetDataItem(Container)).LastName + ";"%><%# ((Sportsman)DataBinder.GetDataItem(Container)).FirstName + ";"%><%# ((Sportsman)DataBinder.GetDataItem(Container)).Patronymic + ";"%><%# ((Sportsman)DataBinder.GetDataItem(Container)).CodeGroup + ";"%> ">Удалить</a></td>
            </tr>
        </ItemTemplate>

        <FooterTemplate>
            </table>
        </FooterTemplate>

    </asp:Repeater>
    <asp:Button ID="ButtonClear" runat="server" Text="Очистить" OnClick="ButtonClear_Click"/>
</asp:Content>
