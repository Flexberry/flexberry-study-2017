<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FoundControl.ascx.cs" Inherits="AjaxCorporation.LostFound.FoundControl" %>

<div title="Правила заполнения сообщений">
    <p>
        Правила заполнения сообщений:
            <ul>
                <li>Информация в поле должна соответствовать его названию (в дате - дата, в размере - размер и т.д.).</li>
                <li>Адрес следует указывать как можно точнее.</li>
                <li>Описание должно быть кратким, без лишних подробностей.</li>
                <li>Чтобы проверить соответствие, нажмите кнопку "Сравнить".</li>
            </ul>
    </p>
</div>
<table>
    <tr>
        <td colspan="2" align="center" >Информация о потерянном объекте</td>
        <td colspan="2" align="center">Информация о найденном объекте</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="TypeMessageLostLabel" runat="server" Text="Тип сообщения"></asp:Label></td>
        <td>
            <asp:TextBox ID="TypeMessageLost" runat="server" ReadOnly="True" Text="Потеряно"></asp:TextBox></td>
        <td>
            <asp:Label ID="TypeMessageFoundLabel" runat="server" Text="Тип сообщения"></asp:Label></td>
        <td>
            <asp:TextBox ID="TypeMessageFound" runat="server" ReadOnly="True" Text="Найдено"></asp:TextBox></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="NameLostLabel" runat="server" Text="Название"></asp:Label></td>
        <td>
            <asp:TextBox ID="NameLost" runat="server" Text=""></asp:TextBox></td>
        <td>
            <asp:Label ID="NameFoundLabel" runat="server" Text="Название"></asp:Label></td>
        <td>
            <asp:TextBox ID="NameFound" runat="server" Text=""></asp:TextBox></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="AdressLostLabel" runat="server" Text="Адрес находки"></asp:Label></td>
        <td>
            <asp:TextBox ID="AdressLost" runat="server" Text=""></asp:TextBox></td>
        <td>
            <asp:Label ID="AdressFoundLabel" runat="server" Text="Адрес находки"></asp:Label></td>
        <td>
            <asp:TextBox ID="AdressFound" runat="server" Text=""></asp:TextBox></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="DateLostLabel" runat="server" Text="Дата находки"></asp:Label></td>
        <td>
            <asp:TextBox ID="DateLost" runat="server" Text=""></asp:TextBox></td>
        <td>
            <asp:Label ID="DateFoundLabel" runat="server" Text="Дата находки"></asp:Label></td>
        <td>
            <asp:TextBox ID="DateFound" runat="server" Text=""></asp:TextBox></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="TypeLostLabel" runat="server" Text="Тип находки"></asp:Label></td>
        <td>
            <asp:TextBox ID="TypeLost" runat="server" Text=""></asp:TextBox></td>
        <td>
            <asp:Label ID="TypeFoundLabel" runat="server" Text="Тип находки"></asp:Label></td>
        <td>
            <asp:TextBox ID="TypeFound" runat="server" Text=""></asp:TextBox></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="ColorLostLabel" runat="server" Text="Цвет"></asp:Label></td>
        <td>
            <asp:TextBox ID="ColorLost" runat="server" Text=""></asp:TextBox></td>
        <td>
            <asp:Label ID="ColorFoundLabel" runat="server" Text="Цвет"></asp:Label></td>
        <td>
            <asp:TextBox ID="ColorFound" runat="server" Text=""></asp:TextBox></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="SizeLostLabel" runat="server" Text="Размер"></asp:Label></td>
        <td>
            <asp:TextBox ID="SizeLost" runat="server" Text=""></asp:TextBox></td>
        <td>
            <asp:Label ID="SizeFoundLabel" runat="server" Text="Размер"></asp:Label></td>
        <td>
            <asp:TextBox ID="SizeFound" runat="server" Text=""></asp:TextBox></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="BreedLostLabel" runat="server" Text="Порода"></asp:Label></td>
        <td>
            <asp:TextBox ID="BreedLost" runat="server" Text=""></asp:TextBox></td>
        <td>
            <asp:Label ID="BreedFoundLabel" runat="server" Text="Порода"></asp:Label></td>
        <td>
            <asp:TextBox ID="BreedFound" runat="server" Text=""></asp:TextBox></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="DescriptionLostLabel" runat="server" Text="Описание"></asp:Label></td>
        <td>
            <asp:TextBox ID="DescriptionLost" runat="server" Text=""></asp:TextBox></td>
        <td>
            <asp:Label ID="DescriptionFoundLabel" runat="server" Text="Описание"></asp:Label></td>
        <td>
            <asp:TextBox ID="DescriptionFound" runat="server" Text=""></asp:TextBox></td>
    </tr>
    <tr>
        <td colspan="4"></td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Button ID="Compare" runat="server" Text="Сравнить" OnClick="Compare_OnClick" /></td>
        <td>
            <asp:Label ID="ResultLabel" runat="server" Text="Результаты сравнения"></asp:Label></td>
        <td>
            <asp:TextBox ID="Result" runat="server" ReadOnly="True" Text=""></asp:TextBox></td>
    </tr>
</table>
<asp:ModelErrorMessage ID="ExeptionBlock" runat="server" ForeColor="Red"/>
