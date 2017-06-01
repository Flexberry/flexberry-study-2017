<%@ Page Title="Найти студента" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FindStudent.aspx.cs" Inherits="ICSSoft.STORMNET.Web.FindStudent" %>
<%@ Register TagPrefix="StudentControls" TagName="GetStudent" Src="~/GetStudent.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <StudentControls:GetStudent ID="GetStudent1" runat="server" />
</asp:Content>
