<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FoundControl.ascx.cs" Inherits="LostFound.FoundControl" %>

<h2>Находка</h2>
    <p>С помощью приложения "Находка" можно найти все!</p>
    <div title="Правила заполнения сообщений">
        <p>Правила заполнения сообщений:
            <ul>
                <li>Информация в поле должна соответствовать его названию (в дате - дата, в размере - размер и т.д.).</li>
                <li>Адрес следует указывать как можно точнее.</li>
                <li>Описание должно быть кратким, без лишних подробностей.</li>
            </ul>
        </p>
    </div>
    <br/>
    <h3>Информация о потерянном объекте</h3>
    <div title="Первое сообщение (потеряно)">
        <asp:Label ID="TypeMessageLostLabel" runat="server" Text="Тип сообщения"></asp:Label>
        <asp:TextBox ID="TypeMessageLost" runat="server"  ReadOnly="True" Text="Потеряно"></asp:TextBox><br />
        <br/>
        <asp:Label ID="NameLostLabel" runat="server" Text="Название"></asp:Label>
        <asp:TextBox ID="NameLost" runat="server" Text=""></asp:TextBox><br />
        <br/>
        <asp:Label ID="AdressLostLabel" runat="server" Text="Адрес находки"></asp:Label>
        <asp:TextBox ID="AdressLost" runat="server" Text=""></asp:TextBox><br />
        <br/>
        <asp:Label ID="DateLostLabel" runat="server" Text="Дата находки"></asp:Label>
        <asp:TextBox ID="DateLost" runat="server" Text=""></asp:TextBox><br />
        <br/>
        <asp:Label ID="TypeLostLabel" runat="server" Text="Тип находки"></asp:Label>
        <asp:TextBox ID="TypeLost" runat="server" Text=""></asp:TextBox><br />
        <br/>
        <asp:Label ID="ColorLostLabel" runat="server" Text="Цвет"></asp:Label>
        <asp:TextBox ID="ColorLost" runat="server" Text=""></asp:TextBox><br />
        <br/>
        <asp:Label ID="SizeLostLabel" runat="server" Text="Размер"></asp:Label>
        <asp:TextBox ID="SizeLost" runat="server" Text=""></asp:TextBox><br />
        <br/>
        <asp:Label ID="BreedLostLabel" runat="server" Text="Порода"></asp:Label>
        <asp:TextBox ID="BreedLost" runat="server" Text=""></asp:TextBox><br />
        <br/>
        <asp:Label ID="DescriptionLostLabel" runat="server" Text="Описание"></asp:Label>
        <asp:TextBox ID="DescriptionLost" runat="server" Text=""></asp:TextBox>
    </div>
    <br/>
    <h3>Информация о найденном объекте:</h3>
    <div title="Второе сообщение (найдено)">
        <asp:Label ID="TypeMessageFoundLabel" runat="server" Text="Тип сообщения"></asp:Label>
        <asp:TextBox ID="TypeMessageFound" runat="server" ReadOnly="True" Text="Найдено"></asp:TextBox><br />
        <br/>
        <asp:Label ID="NameFoundLabel" runat="server" Text="Название"></asp:Label>
        <asp:TextBox ID="NameFound" runat="server" Text=""></asp:TextBox><br />
        <br/>
        <asp:Label ID="AdressFoundLabel" runat="server" Text="Адрес находки"></asp:Label>
        <asp:TextBox ID="AdressFound" runat="server" Text=""></asp:TextBox><br />
        <br/>
        <asp:Label ID="DateFoundLabel" runat="server" Text="Дата находки"></asp:Label>
        <asp:TextBox ID="DateFound" runat="server" Text=""></asp:TextBox><br />
        <br/>
        <asp:Label ID="TypeFoundLabel" runat="server" Text="Тип находки"></asp:Label>
        <asp:TextBox ID="TypeFound" runat="server" Text=""></asp:TextBox><br />
        <br/>
        <asp:Label ID="ColorFoundLabel" runat="server" Text="Цвет"></asp:Label>
        <asp:TextBox ID="ColorFound" runat="server" Text=""></asp:TextBox><br />
        <br/>
        <asp:Label ID="SizeFoundLabel" runat="server" Text="Размер"></asp:Label>
        <asp:TextBox ID="SizeFound" runat="server" Text=""></asp:TextBox><br />
        <br/>
        <asp:Label ID="BreedFoundLabel" runat="server" Text="Порода"></asp:Label>
        <asp:TextBox ID="BreedFound" runat="server" Text=""></asp:TextBox><br />
        <br/>
        <asp:Label ID="DescriptionFoundLabel" runat="server" Text="Описание"></asp:Label>
        <asp:TextBox ID="DescriptionFound" runat="server" Text=""></asp:TextBox>
    </div>
    <br/>
    <div title="Проверка совпадение данных">
        <asp:Button ID="Compare" runat="server" Text="Сравнить" BackColor="green" OnClick="Compare_OnClick"/><br/>
        <br/>
        <asp:Label ID="ResultLabel" runat="server" Text="Результаты сравнения"></asp:Label>
        <asp:TextBox ID="Result" runat="server" ReadOnly="True" Text=""></asp:TextBox>
    </div>
