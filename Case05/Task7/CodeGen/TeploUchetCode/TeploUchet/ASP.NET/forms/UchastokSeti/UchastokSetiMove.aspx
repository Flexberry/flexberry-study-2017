<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="UchastokSetiMove.aspx.cs" Inherits="Web.UchastokSetiMove" %>
<%@ Register TagPrefix="UchastokSetiControls" TagName="Move" Src="~/Controls/UchastokSetiM.ascx" %>
<%@ Import namespace="NewPlatform.Flexberry.Web.Page" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../shared/script/site.js"></script>
    <link rel="stylesheet" type="text/css" href="../../shared/css/site.css"/>
    <div class="<%= Constants.FormCssClass %> <%= Constants.ListFormCssClass %>" style="margin-left: 20px">
        <UchastokSetiControls:Move ID="Move" runat="server" />
    </div>
</asp:Content>

