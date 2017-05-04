<%@ Page Title="Проверить находку" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Information.aspx.cs" Inherits="AjaxCorporation.LostFound.Information" %>
<%@ Register tagPrefix="controlLostFound" tagName="foundControl" Src="~/FoundControl.ascx"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <controlLostFound:foundControl ID="lostFound" runat="server"/>
</asp:Content>
