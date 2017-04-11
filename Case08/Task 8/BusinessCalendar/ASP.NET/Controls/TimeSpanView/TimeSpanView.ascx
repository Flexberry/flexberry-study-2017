<%@ Control Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="TimeSpanView.ascx.cs" 
    Inherits="IIS.BusinessCalendar.Controls.TimeSpanView.TimeSpanView" %>

<div id="TSView" runat="server" class="TimeSpanView">
    <input type="hidden" id="TimeSpanViewMode" name="tsvMode" runat="server" value="0" />
    <input type="hidden" id="TimeSpanViewStatus" name="tsvStatus" runat="server" value="0" />
    <input type="hidden" id="TimeSpansJson" name="tsjArray" runat="server" value="" />
    <div id="TSVContainer" runat="server" data-source-control="" data-status-control="" class="TSVContainer"></div>
</div>

<script>
     $('#<%= TSVContainer.ClientID%>').TimeSpans("init", document.getElementById('<%= TimeSpansJson.ClientID%>'), document.getElementById('<%= TimeSpanViewStatus.ClientID%>'),document.getElementById('<%= TimeSpanViewMode.ClientID%>'));
</script>
