<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
         <style>         
        .table_blur {
          background: #f5ffff;
          border-collapse: collapse;
          text-align: left;
        }
        .table_blur th {
          border-top: 1px solid #777777;	
          border-bottom: 1px solid #777777; 
          box-shadow: inset 0 1px 0 #999999, inset 0 -1px 0 #999999;
          background: linear-gradient(#9595b6, #5a567f);
          color: white;
          padding: 10px 15px;
          position: relative;
        }
        .table_blur th:after {
          content: "";
          display: block;
          position: absolute;
          left: 0;
          top: 25%;
          height: 25%;
          width: 100%;
          background: linear-gradient(rgba(255, 255, 255, 0), rgba(255,255,255,.08));
        }
        .table_blur tr:nth-child(odd) {
          background: #ebf3f9;
        }
        .table_blur th:first-child {
          border-left: 1px solid #777777;	
          border-bottom:  1px solid #777777;
          box-shadow: inset 1px 1px 0 #999999, inset 0 -1px 0 #999999;
        }
        .table_blur th:last-child {
          border-right: 1px solid #777777;
          border-bottom:  1px solid #777777;
          box-shadow: inset -1px 1px 0 #999999, inset 0 -1px 0 #999999;
        }
        .table_blur td {
          border: 1px solid #e3eef7;
          padding: 10px 15px;
          position: relative;
          transition: all 0.5s ease;
        }
        .table_blur tbody:hover td {
          color: transparent;
          text-shadow: 0 0 3px #a09f9d;
        }
        .table_blur tbody:hover tr:hover td {
          color: #444444;
          text-shadow: none;
        }
        .bot8 {
          background-color: #FFFFFF;
            border: 1px solid #CCCCCC;
            box-shadow: 0 1px 1px rgba(0, 0, 0, 0.075) inset;
            transition: border 0.2s linear 0s, box-shadow 0.2s linear 0s;
                border-radius: 4px;
            color: #555555;
            display:block;
                width:120px;
                margin: 20px auto;
            font-size: 14px;
                text-align:center;
            height: 20px;
            line-height: 20px;
            margin-bottom: 10px;
            padding: 4px 6px;
            vertical-align: middle;
                text-decoration:none;
        }
        .bot8:hover, a.bot8:focus {
             border-color: rgba(82, 168, 236, 0.8);
        }
    </style>
    <div class="lab1">
        <asp:TextBox ID="firstTextBox" runat="server" Height="220px" Width="300px" TextMode="MultiLine"></asp:TextBox>
        <asp:TextBox ID="secondTextBox" runat="server" Height="220px" Width="300px" TextMode="MultiLine"></asp:TextBox><br>
        <asp:Button ID="compareButton" runat="server" Height="77px" Width="193px" Text="Сравнить" OnClick="compareButton_Click" CssClass="bot8"/><br>
        <asp:Label ID="anserLabel" runat="server"></asp:Label>
    </div>
    <asp:Table ID="Table1" runat="server" Height="235px" HorizontalAlign="Center" Width="977px" CssClass="table_blur">
    </asp:Table>
</asp:Content>
