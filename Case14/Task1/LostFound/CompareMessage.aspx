<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompareMessage.aspx.cs" Inherits="LostFound.CompareMessage" %>
<%@ Register tagPrefix="controlLostFound" tagName="foundControl" Src="~/FoundControl.ascx"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <controlLostFound:foundControl ID="lostFound" runat="server"/>
</asp:Content>
