<%@ Page Title="Студенты (клиентский вариант)" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentsClient.aspx.cs" Inherits="AcademicPerformance.StudentsClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Добавление студента</h3>
    <div class="form-group">
        <div class="col-xs-2 control-label">
            <asp:Label ID="Label1" runat="server" Text="Фамилия:"></asp:Label>
        </div>
        <div class="col-xs-3">
            <asp:TextBox ID="TextBoxSurname" runat="server" CssClass="form-control text-surname"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <div class="col-xs-2 control-label">
            <asp:Label ID="Label2" runat="server" Text="Имя:"></asp:Label>
        </div>
        <div class="col-xs-3">
            <asp:TextBox ID="TextBoxName" runat="server" CssClass="form-control text-name"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <div class="col-xs-2 control-label">
            <asp:Label ID="Label3" runat="server" Text="Отчество:"></asp:Label>
        </div>
        <div class="col-xs-3">
            <asp:TextBox ID="TextBoxPatronymic" runat="server" CssClass="form-control text-patronymic"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <div class="col-xs-2 control-label">
            <asp:Label ID="Label4" runat="server" Text="Номер группы:"></asp:Label>
        </div>
        <div class="col-xs-3">
            <asp:TextBox ID="TextBoxGroup" runat="server" CssClass="form-control text-group"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <div class="col-xs-2 control-label">
            <asp:Label ID="Label5" runat="server" Text="Дата рождения:"></asp:Label>
        </div>
        <div class="col-xs-3">
            <div class='input-group date' id='datetimepicker1'>
                <input type='text' id="calendartext" name="calendartext" class="form-control text-calendar" />
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
        <div class="col-xs-2 control-label">
            <asp:Label ID="Label6" runat="server" Text="Код специальности:"></asp:Label>
        </div>
        <div class="col-xs-3">
            <asp:DropDownList ID="DropDownListSpecialityCode" runat="server" CssClass="form-control text-spec"></asp:DropDownList>
        </div>
    </div>

    <div class="form-group">
        <div class="col-xs-2"></div>
        <div class="col-xs-9">
            <asp:Button ID="ButtonAdd" runat="server" Text="Добавить" CssClass="btn btn-primary button-add" />
            <asp:Button ID="ButtonClear" runat="server" Text="Очистить" CssClass="btn btn-warning button-clear" />
        </div>
    </div>

    <h3>Список студентов</h3>
    <div class="table-responsive" id="students-table">
        <table class="table">
            <thead>
                <tr>
                    <th>ФИО</th>
                    <th>Номер группы</th>
                    <th>Дата рождения</th>
                    <th>Код специальности</th>
                    <th>Номер зачетки</th>
                </tr>
            </thead>
            <tbody id="students-list">
            </tbody>
        </table>
    </div>

    <div id="error-dialog" class="modal fade" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Ошибка при вводе данных о студенте</h4>
                </div>
                <div class="modal-body">
                    <div class="container-fluid alert alert-danger">
                        <div class="row">
                            <div class="col-xs-3">
                                <span class="glyphicon glyphicon-warning-sign error-icon"></span>
                            </div>
                            <div class="col-xs-9">
                                <p class="text-danger">
                                    <span class="error-text"></span>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->

    <script type="text/javascript">
        function clearInputs() {
            var surname = $('.text-surname').val('');
            var name = $('.text-name').val('');
            var patronymic = $('.text-patronymic').val('');
            var group = $('.text-group').val('');
            var dateBirth = $('.text-calendar').val('');
            var specCode = $('.text-spec option:nth-child(1)').prop('selected', true);
        }

        $(function () {
            $('.main-form').submit(function (event) {
                event.preventDefault();
            });
            $('.button-add').click(function (event) {
                var surname = $('.text-surname').val();
                var name = $('.text-name').val();
                var patronymic = $('.text-patronymic').val();
                var group = $('.text-group').val();
                var dateBirth = $('.text-calendar').val();
                var specCode = $('.text-spec option:selected').text();
                try {
                    addStudent(surname, name, patronymic, group, dateBirth, specCode);
                    clearInputs();
                } catch (e) {
                    $('#error-dialog .modal-body p span.error-text').html(e.message);
                    $('#error-dialog').modal('show');
                }
            });
            $('.button-clear').click(function (event) {
                removeAllStudents();
                clearInputs();
            });

            loadStudentsFromLocalStore();
            displayAllStudents();
        });
    </script>
</asp:Content>
