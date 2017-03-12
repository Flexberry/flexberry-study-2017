<%@ Page Title="Тренировка" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Trainings.aspx.cs" Inherits="SportSchool.Trainings" %>
<%@ Register TagPrefix="SportsmenControls" TagName="GetSportsman" Src="~/GetSportsman.ascx" %>
<%@ Register TagPrefix="TrainingControls" TagName="PointsCalculate" Src="~/PointsCalculate.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Title %></h1>
    
    <h2><asp:Label runat="server" ID="Sportsmen" Text=""></asp:Label></h2>

    <TrainingControls:PointsCalculate ID="PointsCalculate1" runat="server" />
</asp:Content>
