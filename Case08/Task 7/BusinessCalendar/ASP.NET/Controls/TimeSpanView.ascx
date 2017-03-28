<%@ Control Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="TimeSpanView.ascx.cs" 
    Inherits="IIS.BusinessCalendar.Controls.TimeSpanView" %>

<div>
    <input type="hidden" id="TimeSpanViewStatus" name="tsvStatus" runat="server" value="0" />
    <input type="hidden" id="TimeSpansJson" name="tsjArray" runat="server" value="" />
    <div class="TimeSpanView"></div>
</div>
<script>
    var hidden = document.getElementById('<%Response.Write(TimeSpansJson.ClientID);%>');
    var inputStatus = document.getElementById('<%Response.Write(TimeSpanViewStatus.ClientID);%>');
</script>
