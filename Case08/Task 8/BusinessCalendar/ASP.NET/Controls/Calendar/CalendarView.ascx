<%@ Control Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="CalendarView.ascx.cs" 
    Inherits="IIS.BusinessCalendar.Controls.Calendar.CalendarView" %>
<div id="CalendarControlContainer">
    <input type="hidden" id="CalendarDataSource" runat="server" value="" />
    <div id="CalendarView">

    </div>
</div>

<script>
    $('#CalendarView').CalendarView("init",document.getElementById('<%= CalendarDataSource.ClientID%>'));
</script>