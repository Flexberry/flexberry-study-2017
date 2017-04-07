<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ExceptionDayRedirecter.aspx.cs" Inherits="IIS.BusinessCalendar.forms.ExceptionDayRedirecter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitlePlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AddToHeadPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script>
            window.parent.closeEditForm();
        </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder0" runat="server">
        
</asp:Content>
