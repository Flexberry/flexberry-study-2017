<%@ Page Title="Студенты" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="AcademicPerformance.Students" %>

<%@ Import Namespace="AcademicPerformance.DAL" %>
<%@ Import Namespace="AcademicPerformance.Objects" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Добавление студента</h3>
    <div class="form-group">
        <asp:Label ID="Label1" runat="server" Text="Фамилия:" CssClass="col-xs-2 control-label"></asp:Label>
        <div class="col-xs-3">
            <asp:TextBox ID="TextBoxSurname" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <asp:Label ID="Label2" runat="server" Text="Имя:" CssClass="col-xs-2 control-label"></asp:Label>
        <div class="col-xs-3">
            <asp:TextBox ID="TextBoxName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <asp:Label ID="Label3" runat="server" Text="Отчество:" CssClass="col-xs-2 control-label"></asp:Label>
        <div class="col-xs-3">
            <asp:TextBox ID="TextBoxPatronymic" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <asp:Label ID="Label4" runat="server" Text="Номер группы:" CssClass="col-xs-2 control-label"></asp:Label>
        <div class="col-xs-3">
            <asp:TextBox ID="TextBoxGroup" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <asp:Label ID="Label5" runat="server" Text="Дата рождения:" CssClass="col-xs-2 control-label"></asp:Label>
        <div class="col-xs-3">
            <div class='input-group date' id='datetimepicker1'>
                <input type='text' id="calendartext" name="calendartext" class="form-control" />
                <span class="input-group-addon">
                    <span class="glyphicon glyphicon-calendar"></span>
                </span>
            </div>
        </div>
        <script type="text/javascript">
            $(function () {
                $('#datetimepicker1').datetimepicker({
                    locale: 'ru',
                    format: 'DD.MM.YYYY'
                });
            });
        </script>
    </div>

    <div class="form-group">
        <asp:Label ID="Label6" runat="server" Text="Код специальности:" CssClass="col-xs-2 control-label"></asp:Label>
        <div class="col-xs-3">
            <asp:DropDownList ID="DropDownListSpecialityCode" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
    </div>

    <div class="form-group">
        <div class="col-xs-2"></div>
        <div class="col-xs-1">
            <asp:Button ID="ButtonAdd" runat="server" Text="Добавить" OnClick="ButtonAdd_Click" CssClass="btn btn-primary" />
        </div>
        <div class="col-xs-1"></div>
        <div class="col-xs-8">
            <asp:Button ID="ButtonClear" runat="server" Text="Очистить" OnClick="ButtonClear_OnClick" CssClass="btn btn-warning" />
        </div>
    </div>

    <h3>Список студентов</h3>
    <asp:Repeater ID="StudentsRepeater" runat="server">
        <HeaderTemplate>
            <div class="table-responsive" id="students_table">
                <table class="table">
                    <tr>
                        <th>ФИО</th>
                        <th>Номер группы</th>
                        <th>Дата рождения</th>
                        <th>Код специальности</th>
                        <th>Номер зачетки</th>
                    </tr>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td><%# DataBinder.Eval(Container.DataItem, "Фамилия") %> <%# DataBinder.Eval(Container.DataItem, "Имя") %> <%# DataBinder.Eval(Container.DataItem, "Отчество") %></td>
                <td><%# DataBinder.Eval(Container.DataItem, "НомерГруппы") %> </td>
                <td><%# ((DateTime)DataBinder.Eval(Container.DataItem, "ДатаРождения")).ToString("D") %> </td>
                <td><%# DataBinder.Eval(Container.DataItem, "КодСпециальности") %> </td>
                <td><%# CodeGenerator.CodeGenerator.GetCodeForRecordBook((Студент)DataBinder.GetDataItem(Container)) %> </td>
                <td>
                    <a href="<%= Request.Url.AbsoluteUri + "?code="%><%# CodeGenerator.CodeGenerator.GetCodeForRecordBook((Студент)DataBinder.GetDataItem(Container)) %>">Удалить</a></td>
            </tr>
        </ItemTemplate>

        <FooterTemplate>
            </table>
            </div>
        </FooterTemplate>

    </asp:Repeater>
</asp:Content>
