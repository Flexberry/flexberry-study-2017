<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="IIS.BusinessCalendar.WebForm1" %>
<%@ Register TagPrefix="cc" TagName="TimeSpanView" Src="~/Controls/TimeSpanView.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <cc:TimeSpanView id="TimeSpanView1" runat="server"></cc:TimeSpanView>
    </div>
    </form>
</body>
</html>
