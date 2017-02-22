<%@ Page Title="Найти объект" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Find.aspx.cs" Inherits="Web.Find" %>
<%@ Register TagPrefix="ConsumerControls" TagName="GetConsumer" Src="~/GetConsumer.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <ConsumerControls:GetConsumer ID="GetConsumer1" runat="server" />
</asp:Content>