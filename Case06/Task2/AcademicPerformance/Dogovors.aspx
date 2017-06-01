<%@ Page Title="Договоры" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dogovors.aspx.cs" Inherits="AcademicPerformance.Dogovors" %>
<%@ Import Namespace="AcademicPerformance.DAL" %>
<%@ Import Namespace="AcademicPerformance.Objects" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Добавление договора</h3>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Номер договора:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxNumber" runat="server" MaxLength="15"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                 <asp:Label ID="Label2" runat="server" Text="Информация:"></asp:Label>
            </td>
            <td>
                 <asp:TextBox ID="TextBoxName" runat="server" Columns = "70" Rows="6" TextMode="MultiLine"></asp:TextBox>
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

    <h3>Список договоров</h3>
    <asp:Repeater ID="DogovorsRepeater" runat="server">
        <HeaderTemplate>
            <table border="1"width="80%" style="word-wrap: break-word;">
                <style>
   
   td {
    vertical-align: top; /* Выравнивание по верхнему краю ячеек */
   }
  </style>
                <tr>
                    <th>Номер договора</th>
                     <th>Информация</th>
                </tr>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td width="15"><%# DataBinder.Eval(Container.DataItem, "номерДоговора") %></td>
                 <td width="80%"><wbr><%# DataBinder.Eval(Container.DataItem, "Информация") %> </td>
                <td width="15">
                    <a href="<%= Request.Url.AbsoluteUri + "?code="%><%# DataBinder.Eval(Container.DataItem, "номерДоговора") %>">Удалить</a></td>
            </tr>
        </ItemTemplate>

        <FooterTemplate>
            </table>
        </FooterTemplate>

    </asp:Repeater>
</asp:Content>
