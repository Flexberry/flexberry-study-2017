<%@ Page Title="Найти договор" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FindDogovor.aspx.cs" Inherits="AcademicPerformance.FindDogovor" %>

<%@ Register TagPrefix="DogovorControls" TagName="GetDogovor" Src="~/GetDogovor.ascx" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <DogovorControls:GetDogovor ID="GetDogovor1" runat="server" />
</asp:Content>
