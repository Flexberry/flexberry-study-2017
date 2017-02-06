<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GetStudent.ascx.cs" Inherits="AcademicPerformance.GetStudent" %>

<h2>Введите информацию о студенте</h2>
<div>
    <asp:Label ID="LabelCode" runat="server" Text="Код зачетки: "></asp:Label><asp:TextBox ID="TextBoxCode" runat="server"></asp:TextBox>
</div>
<div>
    <asp:Button ID="ButtonFind" runat="server" Text="Найти" OnClick="ButtonFind_OnClick" />
</div>

<h2>Информация о найденном студенте</h2>
<asp:Panel ID="PanelStudent" runat="server">
    <div>
        <div>
            ФИО:
            <asp:Label ID="LabelFIO" runat="server" Text=""></asp:Label>
        </div>
        <div>
            Номер группы:
            <asp:Label ID="LabelGroup" runat="server" Text=""></asp:Label>
        </div>
        <div>
            Дата рождения:
            <asp:Label ID="LabelDateBirth" runat="server" Text=""></asp:Label>
        </div>
        <div>
            Код специальности:
            <asp:Label ID="LabelCodeSpeciality" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Panel>
<asp:Panel ID="PanelStudentIsNotFound" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Студент не найден" ForeColor="red"></asp:Label>
    </div>
</asp:Panel>
