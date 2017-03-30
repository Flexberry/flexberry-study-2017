<%@ Control Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="TimeSpanView.ascx.cs" 
    Inherits="IIS.BusinessCalendar.Controls.TimeSpanView.TimeSpanView" %>

<div id="TSView" runat="server" class="TimeSpanView">
    <input type="hidden" id="TimeSpanViewStatus" name="tsvStatus" runat="server" value="0" />
    <input type="hidden" id="TimeSpansJson" name="tsjArray" runat="server" value="" />
    <div id="TSVContainer" runat="server"></div>
</div>
<script>
    var tsvContainer = document.getElementById('<%= TSVContainer.ClientID%>');
    var hidden = document.getElementById('<%Response.Write(TimeSpansJson.ClientID);%>');
    var inputStatus = document.getElementById('<%Response.Write(TimeSpanViewStatus.ClientID);%>');
</script>
