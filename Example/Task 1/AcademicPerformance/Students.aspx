<%@ Page Title="Студенты" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="AcademicPerformance.Students" %>
<%@ Import Namespace="AcademicPerformance.DAL" %>
<%@ Import Namespace="AcademicPerformance.Objects" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Добавление студента</h3>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Фамилия:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxSurname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Имя:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Отчество:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxPatronymic" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Номер группы:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxGroup" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Дата рождения:"></asp:Label>
            </td>
            <td>
                <asp:Calendar ID="CalendarDateBirth" runat="server"></asp:Calendar>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Код специальности:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownListSpecialityCode" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="ButtonAdd" runat="server" Text="Добавить" OnClick="ButtonAdd_Click" />
            </td>
            <td>
                <asp:Button ID="ButtonClear" runat="server" Text="Очистить" OnClick="ButtonClear_OnClick"/>
            </td>
        </tr>
    </table>

    <h3>Список студентов</h3>
    <asp:Repeater ID="StudentsRepeater" runat="server">
        <HeaderTemplate>
            <table border="1">
                <tr>
                    <th>ФИО</th>
                    <th>Номер группы</th>
                    <th>Дата рождения</th>
                    <th>Код специальности</th>
                    <th>Номер зачетки</th>
                </tr>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td><%# DataBinder.Eval(Container.DataItem, "Фамилия") %> <%# DataBinder.Eval(Container.DataItem, "Имя") %> <%# DataBinder.Eval(Container.DataItem, "Отчество") %></td>
                <td><%# DataBinder.Eval(Container.DataItem, "НомерГруппы") %> </td>
                <td><%# ((DateTime)DataBinder.Eval(Container.DataItem, "ДатаРождения")).ToString("D") %> </td>
                <td><%# DataBinder.Eval(Container.DataItem, "КодСпециальности") %> </td>
                <td><%# CodeGenerator.CodeGenerator.GetCodeForRecordBook((Студент)DataBinder.GetDataItem(Container)) %> </td>
                <td>
                    <a href="<%= Request.Url.AbsoluteUri + "?code="%><%# CodeGenerator.CodeGenerator.GetCodeForRecordBook((Студент)DataBinder.GetDataItem(Container)) %>">Удалить</a></td>
            </tr>
        </ItemTemplate>

        <FooterTemplate>
            </table>
        </FooterTemplate>

    </asp:Repeater>
</asp:Content>
