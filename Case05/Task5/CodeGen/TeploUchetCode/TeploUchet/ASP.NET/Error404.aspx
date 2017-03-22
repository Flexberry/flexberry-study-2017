<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Error404.aspx.cs"
    Inherits="ICSSoft.STORMNET.Web.Error404" Title="Произошла ошибка" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Image SkinID="404Image" runat="server"/>
    <br>
    <asp:Label runat="server" Text="По этому адресу ничего не найдено"></asp:Label>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder0" ID="Content0" runat="server">
    
</asp:Content>
