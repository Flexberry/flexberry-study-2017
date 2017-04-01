<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="UchastokSetiMove.aspx.cs" Inherits="Web.UchastokSetiMove" %>
<%@ Register TagPrefix="UchastokSetiControls" TagName="Move" Src="~/Controls/UchastokSetiM.ascx" %>
<%@ Import namespace="NewPlatform.Flexberry.Web.Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="<%= Constants.FormCssClass %> <%= Constants.ListFormCssClass %>">
        <h2 class="<%= Constants.FormHeaderCssClass %> <%= Constants.ListFormHeaderCssClass %>">Участок сети</h2>
        <UchastokSetiControls:Move ID="UchastokSetiM1" runat="server" />
    </div>

</asp:Content>


