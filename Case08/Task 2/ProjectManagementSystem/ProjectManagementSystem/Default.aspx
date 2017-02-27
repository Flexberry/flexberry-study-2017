<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProjectManagementSystem.Calendar" %>
<asp:Content ID="mainContainer" ContentPlaceHolderID="MainContent" runat="server">

    <link href="Content/bootstrap-datepicker.css" rel="stylesheet" />
    <script src="Scripts/bootstrap-datepicker.js"></script>
    <script src="Scripts/CalendarInitial.js"></script>
    <script src="Scripts/timeSpans.js"></script>
    <script src="Scripts/CalendarEditLogic.js"></script>


    <div class="page-header">
        <div class="container">
        <div class="row">
            <div class="col-lg-6">
                <label for="MonthDropDownList">Укажите месяц:</label>
                <asp:DropDownList ID="MonthDropDownList" runat="server" AutoPostBack="False" CssClass="form-control"></asp:DropDownList>
                <asp:Button ID="Button1" runat="server" Text="Расчитать" OnClick="Button1_Click" CssClass="btn"/>
            </div>
        </div>
        <div class="row">
            <div id="calendarBlock" runat="server" class="col-lg-8"></div>
        </div> 
    </div>
    </div>
    
    <!-- Modal -->
    <div id="myModal" class="modal fade" data-focus-on="input:first" role="dialog">
    <div class="modal-dialog modal-lg">

        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">
                    <label for="dayTitle">Название:</label>
                    <input type="text" class="form-control" id="dayTitle"/>
                </h4>
            </div>
            <div class="modal-body" style="max-height:400px; overflow-y:scroll;">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="radio">
                                <label><input id="noWorkTimeCheck" type="radio" name="choiseDayTipe" value="0" />Нерабочее время</label>
                            </div>
                            <div class="radio">
                                <label><input id="workTimeCheck" type="radio" name="choiseDayTipe" checked="checked" value="1"/>Рабочее время</label>
                            </div>
                            <div class="panel-body text-center">
                                <table class="table table-bordered table-hover" id="tableAddRow">
                                  <thead>
                                      <tr>
                                          <th>Время начала</th>
                                          <th>Время окончания</th>
                                          <th style="width:10px"><span class="glyphicon glyphicon-plus addBtn" id="addBtn_0"></span></th>
                                      </tr>
                                  </thead>
                                  <tbody>
                                  </tbody>
                              </table>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <label for="startDate">Дата начала:</label>
                            <input id="startDate" type="text" value="" data-date-format="dd/mm/yyyy" class="datepicker" >
                            <div class="radio">
                                <p><label><input type="radio" name="iterType" checked="checked" value="0"/>Ежедневно</label></p>
                                <p><label><input type="radio" name="iterType" value="1"/>Еженедельно</label></p>
                                <p><label><input type="radio" name="iterType" value="2"/>Ежемесячно</label></p>
                                <p><label><input type="radio" name="iterType" value="3"/>Ежегодно</label></p>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="radio">
                                <label for="repeatCount">Переодичность:</label>
                                <input type="number" id="repeatCount" min="0"/>
                            </div>  
                            <div class="radio">
                                <label for="repeatCountEnd"><input id="repeatCounterCheck" type="radio" name="choiseMethod" value="0"/>Окончание после:</label>
                                <input type="number" id="repeatCountEnd" min="0" />
                            </div>
                            <div class="radio">
                                <label for="endDateInput"><input id="endDateCheck" type="radio" name="choiseMethod" value="1"/>Дата окончания:</label>
                                <input id="endDateInput" type="text" value="" data-date-format="dd/mm/yyyy" class="datepicker" >
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <button id="btnDeleteDay" type="button" class="btn btn-danger" data-dismiss="modal" disabled="disabled" onclick="DeleteCalendarDay();">Удалить</button>
                <button type="button" class="btn btn-success" data-dismiss="modal"  onclick="AddCalendarDay();">Сохранить</button>
                <button type="button" class="btn btn-default" data-dismiss="modal">Закрыть</button>
            </div>
        </div>
    </div>

    </div>
</asp:Content>
