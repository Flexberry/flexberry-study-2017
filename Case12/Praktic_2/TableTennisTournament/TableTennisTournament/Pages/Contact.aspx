<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="TableTennisTournament.Contact" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <asp:Label ID="nameLabel" runat="server" Text="Имя">
            <asp:TextBox ID="NameTB" runat="server"></asp:TextBox>
        </asp:Label>
    </div>
    <div>
        <asp:Label ID="middleLabel" runat="server" Text="Отчество">
            <asp:TextBox ID="middleTB" runat="server"></asp:TextBox>
        </asp:Label>
    </div>
    <div>
        <asp:Label ID="familyLabel" runat="server" Text="Фамилия">
            <asp:TextBox ID="familyTB" runat="server"></asp:TextBox>
        </asp:Label>
    </div>
    <div>
        <asp:Label ID="loginLabel" runat="server" Text="Логин">
            <asp:TextBox ID="loginTB" runat="server"></asp:TextBox>
        </asp:Label>
    </div>
    <div>
        <asp:Button ID="AddPlayer" runat="server" Text="Добавить" OnClick="AddPlayer_OnClick" />
    </div>

    <asp:Repeater ID="PlayersRepeater" runat="server">
        <HeaderTemplate>
            <table border="1">
                <tr>
                    <th>nickname</th>
                    <th>рейтинг</th>
                </tr>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td><%# DataBinder.Eval(Container.DataItem, "Login") %> </td>
                <td><%# DataBinder.Eval(Container.DataItem, "Rating") %> </td>
                <td>
                    <asp:LinkButton ID="PlayerDelete" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PlayerGuid") %>' OnClick="PlayerDelete_OnClick">LinkButton</asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>

        <FooterTemplate>
            </table>
        </FooterTemplate>

    </asp:Repeater>
</asp:Content>
<%--<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>
    <address>
        One Microsoft Way<br />
        Redmond, WA 98052-6399<br />
        <abbr title="Phone">P:</abbr>
        425.555.0100
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>
</asp:Content>--%>
