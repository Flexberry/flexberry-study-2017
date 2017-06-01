<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GetRating.ascx.cs" Inherits="ICSSoft.STORMNET.Web.GetRating" %>



<%--<div>
    <asp:Button ID="ButtonFind" runat="server" Text="Посчитать рейтинг организаций" OnClick="ButtonFind_OnClick" />
</div>--%>

<h2>Рейтинг организаций.</h2>
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
<h2>За приоритет=1 дается 3 балла. За приоритет=2 дается 2 балла. За приоритет=3 дается 1 балл. </h2>
<asp:Panel ID="PanelStudentIsNotFound" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Студент не найден" ForeColor="red"></asp:Label>
    </div>
</asp:Panel>