<%@ Page Title="Найти студента" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FindPreferences.aspx.cs" Inherits="ICSSoft.STORMNET.Web.FindPreferences" %>
<%@ Register TagPrefix="StudentControls" TagName="GetPreferences" Src="~/GetPreferences.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <StudentControls:GetPreferences ID="GetPreferences" runat="server" />
</asp:Content>

