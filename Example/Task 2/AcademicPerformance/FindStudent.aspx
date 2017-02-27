<%@ Page Title="Найти студента" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FindStudent.aspx.cs" Inherits="AcademicPerformance.FindStudent" %>
<%@ Register TagPrefix="StudentControls" TagName="GetStudent" Src="~/GetStudent.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <StudentControls:GetStudent ID="GetStudent1" runat="server" />
</asp:Content>
