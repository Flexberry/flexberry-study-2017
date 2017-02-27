<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GetStudent.ascx.cs" Inherits="AcademicPerformance.GetStudent" %>

<h2>Введите информацию о студенте</h2>
<div class="form-group">
    <asp:Label ID="LabelCode" runat="server" Text="Код зачетки: " CssClass="col-xs-2 control-label"></asp:Label>
    <div class="col-xs-3">
        <asp:TextBox ID="TextBoxCode" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
</div>
<div class="form-group">
    <div class="col-xs-2"></div>
    <div class="col-xs-10">
        <asp:Button ID="ButtonFind" runat="server" Text="Найти" OnClick="ButtonFind_OnClick" CssClass="btn btn-primary" />
    </div>
</div>

<h2>Информация о найденном студенте</h2>
<asp:Panel ID="PanelStudent" runat="server">
    <div class="form-group">
        <label class="control-label col-xs-2">ФИО:</label>
        <div class="col-xs-10">
            <p class="form-control-static">
                <asp:Label ID="LabelFIO" runat="server" Text=""></asp:Label>
            </p>
        </div>
    </div>
    <div class="form-group">
        <label class="control-label col-xs-2">Номер группы:</label>
        <div class="col-xs-10">
            <p class="form-control-static">
                <asp:Label ID="LabelGroup" runat="server" Text=""></asp:Label>
            </p>
        </div>
    </div>
    <div class="form-group">
        <label class="control-label col-xs-2">Дата рождения:</label>
        <div class="col-xs-10">
            <p class="form-control-static">
                <asp:Label ID="LabelDateBirth" runat="server" Text=""></asp:Label>
            </p>
        </div>
    </div>
    <div class="form-group">
        <label class="control-label col-xs-2">Код специальности:</label>
        <div class="col-xs-10">
            <p class="form-control-static">
                <asp:Label ID="LabelCodeSpeciality" runat="server" Text=""></asp:Label>
            </p>
        </div>
    </div>
</asp:Panel>
<asp:Panel ID="PanelStudentIsNotFound" runat="server">
    <p class="text-danger">Студент не найден</p>
</asp:Panel>
