<%@ Page Title="Найти студента" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FindDogovor.aspx.cs" Inherits="ICSSoft.STORMNET.Web.FindDogovor" %>
<%@ Register TagPrefix="StudentControls" TagName="GetDogovor" Src="~/GetDogovor.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <StudentControls:GetDogovor ID="GetDogovor1" runat="server" />
</asp:Content>
