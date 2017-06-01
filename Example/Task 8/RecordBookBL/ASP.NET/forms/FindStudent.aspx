<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FindStudent.aspx.cs" Inherits="NewPlatform.RecordBookBL.forms.FindStudent" %>
<%@ Register TagPrefix="StudentControls" Namespace="AcademicPerformance" Assembly="RecordBookBL(ASP.NET Application)" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitlePlaceholder" runat="server">
    Поиск студента
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="AddToHeadPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <StudentControls:GetStudent ID="GetStudent1" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder0" runat="server">
</asp:Content>
