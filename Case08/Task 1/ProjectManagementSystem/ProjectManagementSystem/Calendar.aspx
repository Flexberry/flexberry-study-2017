<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="ProjectManagementSystem.Calendar" %>
<asp:Content ID="mainContainer" ContentPlaceHolderID="MainContent" runat="server">
    <table class="calendar">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Укажите месяц: "></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="MonthDropDownList" runat="server" AutoPostBack="False"></asp:DropDownList>
            </td>
            <td >
                <asp:Button ID="Button1" runat="server" Text="Расчитать" CssClass="ButtonSubmit" OnClick="Button1_Click"/>
            </td>
        </tr>
        </table>
    <div id="calendarBlock" runat="server">
    </div>
</asp:Content>
