<%@ Page Title="Найти объект" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FindForm.aspx.cs" Inherits="Web.FindForm" %>
<%@ Register TagPrefix="ConsumerControls" TagName="GetConsumer" Src="~/forms/Find/GetConsumer.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <ConsumerControls:GetConsumer ID="GetConsumer1" runat="server" />
</asp:Content>  