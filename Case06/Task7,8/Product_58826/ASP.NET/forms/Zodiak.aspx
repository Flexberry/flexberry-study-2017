<%@ Page Title="Найти студента" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Zodiak.aspx.cs" Inherits="ICSSoft.STORMNET.Web.Zodiak" %>
<%@ Register TagPrefix="StudentControls" TagName="GetZodiak" Src="~/GetZodiak.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <StudentControls:GetZodiak ID="GetZodiak" runat="server" />
</asp:Content>
