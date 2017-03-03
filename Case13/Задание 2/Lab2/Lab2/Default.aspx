<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lab2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <style>

        </style>
        <br>
        <asp:Label ID="CountLable" runat="server" Text="Label"></asp:Label>
        <br>
        <asp:Table ID="DataTable" runat="server" Width="100%"></asp:Table>
    </div>
</asp:Content>
