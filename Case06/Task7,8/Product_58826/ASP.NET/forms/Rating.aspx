<%@ Page Title="Найти студента" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Rating.aspx.cs" Inherits="ICSSoft.STORMNET.Web.Rating" %>
<%@ Register TagPrefix="StudentControls" TagName="GetRating" Src="~/GetRating.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <StudentControls:GetRating ID="GetRating1" runat="server" />
</asp:Content>
