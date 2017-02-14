<%@ Page Title="Match" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Match.aspx.cs" Inherits="TableTennisTournament.Pages.Match" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
            <div>
                <label>
                    <asp:DropDownList ID="A_PlayerList" runat="server"></asp:DropDownList>
                </label>
                <label>
                    <asp:DropDownList ID="B_PlayerList" runat="server"></asp:DropDownList>
                </label>
            </div>
        </div>
        <div>
            <asp:DropDownList ID="Day" runat="server"></asp:DropDownList>/
            <asp:DropDownList ID="Month" runat="server" OnSelectedIndexChanged="Month_OnSelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>/
            <asp:DropDownList ID="Year" runat="server"></asp:DropDownList>

            <asp:DropDownList ID="Hour" runat="server"></asp:DropDownList>:
            <asp:DropDownList ID="Minutes" runat="server"></asp:DropDownList>
        </div>
        <div>
            <asp:Button ID="addMatch" runat="server" OnClick="addMatch_OnClick" Text="Создать" />
            <asp:Button ID="clearAllMatch" runat="server" Text="Очистить" />
        </div>
    </div>
    <div>table</div>
</asp:Content>


