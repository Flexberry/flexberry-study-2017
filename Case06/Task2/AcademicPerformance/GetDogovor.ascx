<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GetDogovor.ascx.cs" Inherits="AcademicPerformance.GetDogovor" %>
<%@ Import Namespace="AcademicPerformance.DAL" %>
<%@ Import Namespace="AcademicPerformance.Objects" %>
<h2>Введите номер договора</h2>
<div>
    <asp:Label ID="LabelCode" runat="server" Text="Номер договора: "></asp:Label><asp:TextBox ID="TextBoxCode" runat="server"></asp:TextBox>
</div>
<div>
    <asp:Button ID="ButtonFind" runat="server" Text="Найти" OnClick="ButtonFind_OnClick" />
</div>

<h2>Информация о найденном договоре</h2>
<asp:Panel ID="PanelDogovor" runat="server">
    <style type="text/css">
	.ramka { 
            padding: 5px;
	        border: 2px solid #f0f0f0;
	        border-bottom: 3px solid #ccc;
	        -webkit-border-radius: 3px;
	        -moz-border-radius: 3px;
	        border-radius: 3px;
            width:80%;
            font: 14pt Calibri;
    }
    </style>
    <div>
        <div class="ramka">
           <b> Номер договора:</b> <br />
            <asp:Label ID="LabelNumber" runat="server" Text="" width="100%" ></asp:Label>
        </div>
        <div class="ramka">
          <b>  Информация о договоре:</b><br />
            <asp:Label ID="LabelInformation" runat="server" Text="" width="100%" ></asp:Label>
        </div>
    </div>
</asp:Panel>
<asp:Panel ID="PanelDogovorIsNotFound" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Договор не найден" ForeColor="red"></asp:Label>
    </div>
</asp:Panel>
