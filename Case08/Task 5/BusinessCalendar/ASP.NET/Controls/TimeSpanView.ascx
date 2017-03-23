<%@ Control Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="TimeSpanView.ascx.cs" 
    Inherits="IIS.BusinessCalendar.Controls.TimeSpanView" %>

<div>
    <input type="hidden" id="TimeSpansJson" name="name" runat="server" value=" " />
    <div class=".TimeSpanView"></div>

    <script>
        $(document).ready(function () {
            $('TimeSpanView').TimeSpans("init", '<%TimeSpansJson.ClientID%>');
            var formID = $('TimeSpanView').closest('form').attr('id');
            $('#' + formID).submit(function () {
                $('TimeSpanView').TimeSpans("store")
            })
        })
        
    </script>
</div>
