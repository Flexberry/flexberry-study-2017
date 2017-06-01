<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LostFound._Default" %>
<%@ Register tagPrefix="controlLostFound" tagName="foundControl" Src="~/FoundControl.ascx"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <controlLostFound:foundControl ID="lostFound" runat="server"/>
</asp:Content>
