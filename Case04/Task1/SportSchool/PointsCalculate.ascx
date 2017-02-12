<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PointsCalculate.ascx.cs" Inherits="SportSchool.PointsCalculate" %>
<h2>Рассчет нагрузки</h2>

<div>
    <asp:Label ID="LabelM1" runat="server" Text="Минуты в первой зоне: "></asp:Label><asp:TextBox ID="TextBoxM1" runat="server"></asp:TextBox>
</div>
<div>
    <asp:Label ID="LabelS1" runat="server" Text="Секунды в первой зоне: "></asp:Label><asp:TextBox ID="TextBoxS1" runat="server"></asp:TextBox>
</div>
<div>
    <asp:Label ID="LabelM2" runat="server" Text="Минуты во второй зоне: "></asp:Label><asp:TextBox ID="TextBoxM2" runat="server"></asp:TextBox>
</div>
<div>
    <asp:Label ID="LabelS2" runat="server" Text="Секунды во второй зоне: "></asp:Label><asp:TextBox ID="TextBoxS2" runat="server"></asp:TextBox>
</div>
<div>
    <asp:Label ID="LabelM3" runat="server" Text="Минуты в третьей зоне: "></asp:Label><asp:TextBox ID="TextBoxM3" runat="server"></asp:TextBox>
</div>
<div>
    <asp:Label ID="LabelS3" runat="server" Text="Секунды в третьей зоне: "></asp:Label><asp:TextBox ID="TextBoxS3" runat="server"></asp:TextBox>
</div>
<div>
    <asp:Button ID="ButtonCalculatePoints" runat="server" Text="Посчитать" OnClick="ButtonCalculatePoints_OnClick" />
</div>

<h2>Информация о полученной нагрузке</h2>
<asp:Panel ID="PanelPoints" runat="server">
    <div>
        <div>
            Время в первой зоне:
            <asp:Label ID="LabelFirstZone" runat="server" Text=""></asp:Label>
        </div>
        <div>
            Время во второй зоне:
            <asp:Label ID="LabelSecondZone" runat="server" Text=""></asp:Label>
        </div>
        <div>
            Время в третьей зоне:
            <asp:Label ID="LabelThirdZone" runat="server" Text=""></asp:Label>
        </div>
        <div>
            Очки нагрузки:
            <asp:Label ID="LabelPoints" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Panel>
