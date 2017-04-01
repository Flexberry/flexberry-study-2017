<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="Find.aspx.cs" Inherits="Web.Find" %>
<%@ Register TagPrefix="ConsumerControls" TagName="GetConsumer" Src="~/Controls/GetConsumer.ascx" %>
<%@ Import namespace="NewPlatform.Flexberry.Web.Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="<%= Constants.FormCssClass %> <%= Constants.ListFormCssClass %>" style="margin-left: 20px">
        <ConsumerControls:GetConsumer ID="GetConsumer1" runat="server" />
    </div>
</asp:Content>

