<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PointsCalculate.ascx.cs" Inherits="SportSchool.PointsCalculate" %>
<h3>Добавить зону</h3>

<ul class="add-zone" style="list-style-type:none">
        <li class="zone-number">
            <asp:Label ID="labelZoneNumber" runat="server" Text="Номер зоны:"></asp:Label>
            <asp:TextBox ID="TextBoxZoneNumber" runat="server"></asp:TextBox>
        </li>
        <li class="zone-time">
            <asp:Label ID="labelZoneTime" runat="server" Text="Время в зоне:"></asp:Label>
            <asp:TextBox ID="TextBoxTime" runat="server" placeholder="HH:MM:SS"></asp:TextBox>
        </li>
        <li>
           <asp:Button ID="ButtonAdd" runat="server" Text="Добавить" OnClick="ButtonAdd_Click"/>
        </li>
    </ul>