<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GetZodiak.ascx.cs" Inherits="ICSSoft.STORMNET.Web.GetZodiak" %>



<%--<div>
    <asp:Button ID="ButtonFind" runat="server" Text="Студенты по знаку Зодиака" OnClick="ButtonFind_OnClick" />
</div>--%>

<h2>Знаки Зодиака.</h2>
<asp:Panel ID="PanelStudent" runat="server">
    <div>
        <div>
            
            <asp:Label  ID="LabelFIO" runat="server" Text=""></asp:Label>
        </div>
        <%--<div>
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
        </div>--%>
    </div>
</asp:Panel>
<asp:Panel ID="PanelStudentIsNotFound" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Студент не найден" ForeColor="red"></asp:Label>
    </div>
</asp:Panel>