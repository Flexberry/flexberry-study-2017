<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PointsCalculate.ascx.cs" Inherits="SportSchool.PointsCalculate" %>
<h3>Добавить зону</h3>

<ul class="add-zone" style="list-style-type:none">
        <li class="zone-number">
            <asp:Label ID="labelZoneNumber" runat="server" Text="Номер зоны:"></asp:Label>
            <asp:DropDownList ID="ZoneDropDownList" runat="server">
                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                <asp:ListItem Text="6" Value="6"></asp:ListItem>
                <asp:ListItem Text="7" Value="7"></asp:ListItem>
                <asp:ListItem Text="8" Value="8"></asp:ListItem>
                <asp:ListItem Text="9" Value="9"></asp:ListItem>
                <asp:ListItem Text="10" Value="10"></asp:ListItem>
            </asp:DropDownList>
        </li>
        <li class="zone-time">
            <asp:Label ID="labelZoneTime" runat="server" Text="Время в зоне:"></asp:Label>
            <asp:TextBox ID="TextBoxTime" runat="server" placeholder="HH:MM:SS"></asp:TextBox>
        </li>
        <li>
           <asp:Button ID="ButtonAdd" runat="server" Text="Добавить" OnClick="ButtonAdd_Click"/>
        </li>
    </ul>

<h3>Зоны тренировки</h3>
<asp:Repeater ID="ZoneRepeater" runat="server">
        <HeaderTemplate>
            <table border="1">
                <tr>
                    <th>Номер зоны</th>
                    <th>Время</th>
                </tr>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td><%# DataBinder.Eval(Container.DataItem, "Key") %> </td>
                <td><%# DataBinder.Eval(Container.DataItem, "Value") %> </td>
            </tr>
        </ItemTemplate>

        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>

<asp:Button ID="ButtonCalculatePoints" runat="server" Text="Посчитать нагрузку" OnClick="ButtonCalculatePoints_OnClick"/>

<h3>Нагрузка на тренировке</h3>
<asp:Label ID="loadLabel" runat="server" Text=""></asp:Label>