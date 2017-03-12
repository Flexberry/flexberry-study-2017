<%@ Page Title="Найти спортсмена" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FindSportsmen.aspx.cs" Inherits="SportSchool.FindSportsmen" %>
<%@ Register TagPrefix="SportsmenControls" TagName="GetSportsman" Src="~/GetSportsman.ascx" %>
<%@ Register TagPrefix="TrainingControls" TagName="PointsCalculate" Src="~/PointsCalculate.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Title %></h1>
    <SportsmenControls:GetSportsman ID="GetSportsman1" runat="server" />
</asp:Content>