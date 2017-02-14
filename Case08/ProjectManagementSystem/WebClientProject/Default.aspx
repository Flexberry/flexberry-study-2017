<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebClientProject._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Календарь</h1>
        <p class="lead"></p>
    </div>

    <div id="mainContainer" runat="server" class="row" style=" width:100%; float:left;">
        <table style="margin-left: 50px;">
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Дата начала промежутка:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxStartDate" runat="server" TextMode="Date" Width="98%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Выделенное количество часов:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxHour" runat="server" TextMode="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="dateFiniLabel" runat="server" Text="Дата окончания промежутка:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="finishDate" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center">
                    <asp:Label ID="ErrorLabel" runat="server" Text="Введены неккоректные данные" Visible="false" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Расчитать" CssClass="ButtonSubmit" OnClick="Button1_Click"/>
                </td>
            </tr>
        </table>
                
                
                
     </div>
            <div id="">
            
        <div class="col-md-4" >
            
        </div>
        <div class="col-md-4">
            
        </div>
    </div>

</asp:Content>
