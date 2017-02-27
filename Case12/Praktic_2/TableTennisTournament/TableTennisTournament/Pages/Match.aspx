<%@ Page Title="Match" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Match.aspx.cs" Inherits="TableTennisTournament.Pages.Match" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
            <div>
                <label>
                    Player A
                    <asp:DropDownList ID="A_PlayerList" runat="server"></asp:DropDownList>
                </label>
                <label>
                    Player B
                    <asp:DropDownList ID="B_PlayerList" runat="server"></asp:DropDownList>
                </label>
            </div>
        </div>

        <div class="calendar">
            <asp:DropDownList ID="Day" runat="server"></asp:DropDownList>/
            <asp:DropDownList ID="Month" runat="server" OnSelectedIndexChanged="Month_OnSelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>/
            <asp:DropDownList ID="Year" runat="server"></asp:DropDownList>

            <asp:DropDownList ID="Hour" runat="server"></asp:DropDownList>:
            <asp:DropDownList ID="Minutes" runat="server"></asp:DropDownList>
        </div>



        <div>
            <div>
                <label for="GameType">
                    Играем до:
                    <asp:DropDownList ID="GameType" runat="server">
                        <asp:ListItem Value="0" Selected="True">11</asp:ListItem>
                        <asp:ListItem Value="1" Selected="False">21</asp:ListItem>
                    </asp:DropDownList>
                </label>

            </div>
            <div>
                <label for="RoundCount">
                    Кол-во партий:
                    <asp:TextBox ID="RoundCount" runat="server" TextMode="Number" MaxLength="2">1</asp:TextBox>
                </label>

            </div>
            <div>
                <label for="GameFactorTB">
                    Коэффицент:
                    <asp:TextBox ID="GameFactorTB" runat="server" TextMode="Number" MaxLength="2">16</asp:TextBox>
                </label>

            </div>
        </div>
        <div>
            <asp:Button ID="addMatch" runat="server" OnClick="addMatch_OnClick" Text="Создать матч" />
            <asp:Button ID="clearAllMatch" runat="server" Text="Очистить" />
        </div>
    </div>
    <div>
        <asp:PlaceHolder ID="RoundHolder" runat="server"></asp:PlaceHolder>
    </div>
    <div>
        <h1>
            <asp:Button ID="Button1" runat="server" Text="посчитать результат" OnClick="Button1_OnClick" />

            <asp:TextBox ID="newRatingA" runat="server"></asp:TextBox>
            <asp:TextBox ID="newRatingB" runat="server"></asp:TextBox>
        </h1>
        <div>Winner==>LoginName</div>
        <div>Match Result</div>
    </div>
    <div>
        <asp:Repeater ID="MatchRepeater" runat="server">
            <HeaderTemplate>
                <table border="1">
                    <tr>
                        <th>Player 1</th>
                        <th>Player 2</th>
                        <th>Date</th>
                        <th>Score</th>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td><%# DataBinder.Eval(Container.DataItem, "PlayerOne.Login") %> </td>
                    <td><%# DataBinder.Eval(Container.DataItem, "PlayerTwo.Login") %> </td>
                    <td><%# DataBinder.Eval(Container.DataItem, "PlayDateTime") %> </td>
                    <td><%--<%# DataBinder.Eval(Container.DataItem, "RoundsList.Count()") %>--%> </td>
                    <td>
                        <%--<asp:LinkButton ID="PlayerDelete" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PlayerGuid") %>' OnClick="PlayerDelete_OnClick">LinkButton</asp:LinkButton>--%>
                    </td>
                </tr>
            </ItemTemplate>

            <FooterTemplate>
                </table>
            </FooterTemplate>

        </asp:Repeater>
    </div>
</asp:Content>


