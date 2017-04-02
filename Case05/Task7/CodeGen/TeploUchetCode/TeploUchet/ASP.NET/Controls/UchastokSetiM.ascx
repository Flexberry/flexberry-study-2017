<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UchastokSetiM.ascx.cs" Inherits="Web.UchastokSetiM" %>
<%@ Import namespace="NewPlatform.Flexberry.Web.Page" %>


<div class="clearfix">
  
  <asp:Label CssClass="descLbl" ID="ctrlОбъектLabel" runat="server" Text="Объект" EnableViewState="False">
    </asp:Label>
    
  <ac:MasterEditorAjaxLookUp ID="ctrlОбъект" CssClass="descTxt" runat="server" ShowInThickBox="True" Autocomplete="true" />

</div>

<asp:Panel ID="MainPanel" runat="server"></asp:Panel>
