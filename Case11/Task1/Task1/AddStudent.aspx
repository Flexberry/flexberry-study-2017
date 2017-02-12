<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="Task1.Contact" %>
<%@ Import Namespace="Task1.DAL" %>
<%@ Import Namespace="Task1.Objects" %>
<%@ Import Namespace="CostCalculator" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Добавление учащегося</h3>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="ФИО учащегося"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="NameBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Группа"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="GroupList" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Общежитие"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="CampusCheck" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Льготник"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="PrivelegeCheck" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="AddButton" runat="server" Text="Добавить" OnClick="AddButton_Click" />
            </td>
             <td>
                <asp:Button ID="ClearButon" runat="server" Text="Очистить" OnClick="ClearButon_Click" />
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Стоимость общежития"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="CampusCostBox" runat="server"></asp:TextBox>
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
                    <th>Общежитие</th>
                    <th>Льготник</th>
                    <th>Стоимость обучения + проживания</th>
                </tr>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td><%# DataBinder.Eval(Container.DataItem, "Name") %> </td>
                <td><%# DataBinder.Eval(Container.DataItem, "group.name") %> </td>
                <td><%# DataBinder.Eval(Container.DataItem, "campus") %> </td>
                <td><%# DataBinder.Eval(Container.DataItem, "privelege") %> </td>
                <td><%# CostCalc.Calc((Student)DataBinder.GetDataItem(Container), Double.Parse(CampusCostBox.Text)) %> </td>
                <td>
                    <a href="<%= Request.Url.AbsoluteUri + "?student="%><%# ((Student)DataBinder.GetDataItem(Container)).Name %>">Удалить</a></td>
            </tr>
        </ItemTemplate>

        <FooterTemplate>
            </table>
        </FooterTemplate>

    </asp:Repeater>

</asp:Content>
