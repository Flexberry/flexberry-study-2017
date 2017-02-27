<%@ Page Title="FindByGroup" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FindByGroup.aspx.cs" Inherits="Task1.FindByGroup" %>
<%@ Import Namespace="Task1.DAL" %>
<%@ Import Namespace="Task1.Objects" %>
<%@ Import Namespace="CostCalculator" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Списки групп</h3>
    <table>
        <tr>
            <td>
                <asp:DropDownList ID="GroupList" runat="server" OnSelectedIndexChanged="GroupList_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Стоимость общежития"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="CampusCostBox" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>

        <asp:Button ID="ShowByGroupBtn" runat="server" OnClick="ShowByGroupBtn_Click" Text="Показать список" Width="148px" />

    <p><strong>Список группы</strong></p>
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
                
            </tr>
        </ItemTemplate>

        <FooterTemplate>
            </table>
        </FooterTemplate>

    </asp:Repeater>

</asp:Content>
