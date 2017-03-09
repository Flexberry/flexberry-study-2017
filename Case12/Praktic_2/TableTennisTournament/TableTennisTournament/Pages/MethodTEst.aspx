<%@ Page Title="Elo_Rating" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MethodTEst.aspx.cs" Inherits="TableTennisTournament.Pages.MethodTEst" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%" style="text-align: center">
        <tr>
            <td style="width: 45%">
                <asp:Label ID="PlayerA" runat="server" Width="100%">Игрок 1
                    <p>
                        <asp:TextBox ID="NameA" runat="server" Width="80%"></asp:TextBox></p>
                      <p>  <asp:TextBox ID="RatingA" runat="server" TextMode="Number" MaxLength="4" OnTextChanged="RatingA_OnTextChanged">1400</asp:TextBox>
                    </p>
                </asp:Label>
            </td>
            <td style="width: 10%">
                <asp:Label ID="Label1" runat="server" Width="100%">Коэфицент игры
                    <asp:TextBox ID="MagicK" runat="server" Width="100%" TextMode="Number" MaxLength="3">16</asp:TextBox>
                </asp:Label>
            </td>
            <td style="width: 45%">
                <asp:Label ID="PlayerB" runat="server" Width="100%">Игрок 2
                    <p>
                        <asp:TextBox ID="NameB" runat="server" Width="80%"></asp:TextBox></p>
                     <p>  <asp:TextBox ID="RatingB" runat="server" TextMode="Number" MaxLength="4" OnTextChanged="RatingB_OnTextChanged">1400</asp:TextBox>
                    </p>
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td >
                <asp:RadioButton GroupName="Winner" ID="WinA" Text="Первый выиграл" runat="server" />
            </td>
            <td>
                <asp:RadioButton GroupName="Winner" ID="WinAB" Text="Ничья" runat="server" Checked="True" />
            </td>
            <td >
                <asp:RadioButton GroupName="Winner" ID="WinB" Text="Второй выиграл" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 50%">
                <asp:TextBox ID="newRatingA" runat="server" TextMode="Number" Enabled="False" MaxLength="4">0000</asp:TextBox>
            </td>
            <td>Новый рейтинг</td>
            <td style="width: 50%">
                <asp:TextBox ID="newRatingB" runat="server" TextMode="Number" Enabled="False" MaxLength="4">0000</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="GetRating" runat="server" Text="Посчитать" OnClick="GetRating_OnClick" />
            </td>
            <td></td>
        </tr>
    </table>
</asp:Content>

