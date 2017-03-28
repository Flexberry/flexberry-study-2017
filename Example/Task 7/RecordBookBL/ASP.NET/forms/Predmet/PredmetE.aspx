﻿<%--flexberryautogenerated="true"--%>

<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PredmetE.aspx.cs" Inherits="NewPlatform.RecordBookBL.ПредметE" %>

<%@ Import Namespace="NewPlatform.Flexberry.Web.Page" %>
<%-- Autogenerated section start [Register] --%>
<%-- Autogenerated section end [Register] --%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="<%= Constants.FormCssClass %> <%= Constants.EditFormCssClass %>">
        <h2 class="<%= Constants.FormHeaderCssClass %> <%= Constants.EditFormHeaderCssClass %>">Предмет</h2>
        <div class="<%= Constants.FormToolbarCssClass %> <%= Constants.EditFormToolbarCssClass %> <%= Constants.StickyCssClass %>">
            <asp:ImageButton ID="SaveBtn" runat="server" SkinID="SaveBtn" OnClick="SaveBtn_Click" AlternateText="<%$ Resources: Resource, Save %>" ValidationGroup="savedoc" />
            <asp:ImageButton ID="SaveAndCloseBtn" runat="server" SkinID="SaveAndCloseBtn" OnClick="SaveAndCloseBtn_Click" AlternateText="<%$ Resources: Resource, Save_Close %>" ValidationGroup="savedoc" />
            <asp:ImageButton ID="CancelBtn" runat="server" SkinID="CancelBtn" OnClick="CancelBtn_Click" AlternateText="<%$ Resources: Resource, Cancel %>" />
        </div>
        <div class="<%= Constants.FormControlsCssClass %> <%= Constants.EditFormControlsCssClass %>">
            <%-- Autogenerated section start [Controls] --%>
<!-- autogenerated start -->
<div>
	<div class="clearfix">
  <asp:Label CssClass="descLbl" ID="ctrlДисциплинаLabel" runat="server" Text="Дисциплина" EnableViewState="False">
</asp:Label>
<ac:MasterEditorAjaxLookUp ID="ctrlДисциплина" CssClass="descTxt" runat="server" ShowInThickBox="True" Autocomplete="true" />

<asp:RequiredFieldValidator ID="ctrlДисциплинаValidator" runat="server" ControlToValidate="ctrlДисциплина"
ErrorMessage="Не указано: Дисциплина" EnableClientScript="true" ValidationGroup="savedoc">*</asp:RequiredFieldValidator>

</div>
<div class="clearfix">
  <asp:Label CssClass="descLbl" ID="ctrlСеместрLabel" runat="server" Text="Семестр" EnableViewState="False">
</asp:Label>
<ac:MasterEditorAjaxLookUp ID="ctrlСеместр" CssClass="descTxt" runat="server" ShowInThickBox="True" Autocomplete="true" />

<asp:RequiredFieldValidator ID="ctrlСеместрValidator" runat="server" ControlToValidate="ctrlСеместр"
ErrorMessage="Не указано: Семестр" EnableClientScript="true" ValidationGroup="savedoc">*</asp:RequiredFieldValidator>

</div>
<div class="clearfix">
  <asp:Label CssClass="descLbl" ID="ctrlПреподавательLabel" runat="server" Text="Преподаватель" EnableViewState="False">
</asp:Label>
<ac:MasterEditorAjaxLookUp ID="ctrlПреподаватель" CssClass="descTxt" runat="server" ShowInThickBox="True" Autocomplete="true" />

<asp:RequiredFieldValidator ID="ctrlПреподавательValidator" runat="server" ControlToValidate="ctrlПреподаватель"
ErrorMessage="Не указано: Преподаватель" EnableClientScript="true" ValidationGroup="savedoc">*</asp:RequiredFieldValidator>

</div>
<div class="clearfix">
  <asp:Label CssClass="descLbl" ID="ctrlПреподаватель_ФамилияLabel" runat="server" Text="Преподаватель.Фамилия" EnableViewState="False">
</asp:Label>
<asp:TextBox CssClass="descTxt" ID="ctrlПреподаватель_Фамилия" runat="server" ReadOnly="true">
</asp:TextBox>

</div>
<div class="clearfix">
  <asp:Label CssClass="descLbl" ID="ctrlПреподаватель_ИмяLabel" runat="server" Text="Преподаватель.Имя" EnableViewState="False">
</asp:Label>
<asp:TextBox CssClass="descTxt" ID="ctrlПреподаватель_Имя" runat="server" ReadOnly="true">
</asp:TextBox>

</div>
<div class="clearfix">
  <asp:Label CssClass="descLbl" ID="ctrlПреподаватель_ОтчествоLabel" runat="server" Text="Преподаватель.Отчество" EnableViewState="False">
</asp:Label>
<asp:TextBox CssClass="descTxt" ID="ctrlПреподаватель_Отчество" runat="server" ReadOnly="true">
</asp:TextBox>

</div>
<asp:ScriptManager ID="ScriptManager1" runat="server" >
</asp:ScriptManager>

<div style="clear: left">
	<ac:AjaxGroupEdit ID="ctrlОценка" runat="server" ReadOnly="false" />
</div>

</div>
<!-- autogenerated end -->
            <%-- Autogenerated section end [Controls] --%>
        </div>
    </div>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder0">
    <script type="text/javascript">
        var eventForHandler;
        var deferredForHandler;

        $(function () {
            $('#<%= ctrlОценка.ClientID %> select[id*="ctrlСостояние"]').prop('disabled', true);

            $('#<%= ctrlОценка.ClientID %>').on('rowadded.ajaxgroupedit', function (e, d) {
                $(d).find('select[id*="ctrlСостояние"]').prop('disabled', true);
            });

            $.icsEditForm.attachEventHandler(function (e) {
                deferredForHandler = $.Deferred();
                e.deferreds.push(deferredForHandler);
                eventForHandler = e;

                var data = $('#<%= ctrlОценка.ClientID %>').ajaxgroupedit('getDataRows');
                if (data.length !== 0) {
                    var marksForCheck = [];
                    $.each(data, function (index, value) {
                        var markValue = $(value).find('td:nth-child(3) select[id*="ctrlЗначение"]').val();
                        if (markValue === 'Нет оценки') {
                            markValue = 'НетОценки';
                        }

                        var markForCheck = {
                            PrimaryKey: $(value).children('td:first-child').text(),
                            Mark: markValue
                        };

                        marksForCheck.push(markForCheck);
                    });

                    NewPlatform.RecordBookBL.CheckExam.CheckChangedMarks(marksForCheck, onRequestComplete, onError);
                }
            }, 'onCheckSucceed');
        });

        function onRequestComplete(result) {
            if (result.length === 0) {
                deferredForHandler.resolve();
            } else {
                var data = $('#<%=ctrlОценка.ClientID%>').ajaxgroupedit('getDataRows');
                if (data.length !== 0) {
                    var students = [];
                    for (var i = 0; i < result.length; i++) {
                        var pkError = result[i];
                        for (var j = 0; j < data.length; j++) {
                            var value = data[j];
                            var pk = $(value).children('td:first-child').text();
                            if (pk === pkError) {
                                var student = $(value).find('td:nth-child(6) span[id*="ctrlСтудент"]').text();
                                students.push(student);
                                break;
                            }
                        }
                    }

                    var studentsNames = students.join(',');
                    $.ics.dialog.confirm({
                        message: 'У студентов ' +
                            studentsNames +
                            ' оценка уже была ранее исправлена. Всё равно сохранить?',
                        title: 'Сохранение объекта данных',
                        callback: function(res) {
                            if (!res) {
                                eventForHandler.stop = true;
                            }

                            deferredForHandler.resolve();
                        }
                    });
                } else {
                    deferredForHandler.resolve();
                }
            }
        }

        function onError(result) {
                $.ics.dialog.alert({
                    message: result.get_message(),
                    title: 'Ошибка сохранения объекта данных',
                    callback: function () {
                        eventForHandler.stop = true;
                        deferredForHandler.resolve();
                    }
                });
            }
    </script>
</asp:Content>