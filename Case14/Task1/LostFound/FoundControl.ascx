<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FoundControl.ascx.cs" Inherits="LostFound.FoundControl" %>

<h2>Находка</h2>
    <p>С помощью приложения "Находка" можно найти все!</p>
    <div title="Правила заполнения сообщений">
        <p>Правила заполнения сообщений:
            <ul>
                <li>Тип сообщения должен быть указан как "Потеряно" или "Найдено".</li>
                <li>Информация в поле должна соответствовать его названию (в дате - дата, в размере - размер и т.д.).</li>
                <li>Адрес следует указывать как можно точнее.</li>
                <li>Описание должно быть кратким, без лишних подробностей.</li>
            </ul>
        </p>
    </div>
    <br/>
    <h3>Первое сообщение</h3>
    <div title="Первое сообщение">
        <asp:Label ID="TypeMessageFirstLabel" runat="server" Text="Тип сообщения"></asp:Label>
        <asp:TextBox ID="TypeMessageFirst" runat="server"  Text=""></asp:TextBox><br />
        <br/>
        <asp:Label ID="NameFirstLabel" runat="server" Text="Название"></asp:Label>
        <asp:TextBox ID="NameFirst" runat="server" Text=""></asp:TextBox><br />
        <br/>
        <asp:Label ID="AdressFirstLabel" runat="server" Text="Адрес находки"></asp:Label>
        <asp:TextBox ID="AdressFirst" runat="server" Text=""></asp:TextBox><br />
        <br/>
        <asp:Label ID="DateFirstLabel" runat="server" Text="Дата находки"></asp:Label>
        <asp:TextBox ID="DateFirst" runat="server" Text=""></asp:TextBox><br />
        <br/>
        <asp:Label ID="TypeFirstLabel" runat="server" Text="Тип находки"></asp:Label>
        <asp:TextBox ID="TypeFirst" runat="server" Text=""></asp:TextBox><br />
        <br/>
        <asp:Label ID="ColorFirstLabel" runat="server" Text="Цвет"></asp:Label>
        <asp:TextBox ID="ColorFirst" runat="server" Text=""></asp:TextBox><br />
        <br/>
        <asp:Label ID="SizeFirstLabel" runat="server" Text="Размер"></asp:Label>
        <asp:TextBox ID="SizeFirst" runat="server" Text=""></asp:TextBox><br />
        <br/>
        <asp:Label ID="BreedFirstLabel" runat="server" Text="Порода"></asp:Label>
        <asp:TextBox ID="BreedFirst" runat="server" Text=""></asp:TextBox><br />
        <br/>
        <asp:Label ID="DescriptionFirstLabel" runat="server" Text="Описание"></asp:Label>
        <asp:TextBox ID="DescriptionFirst" runat="server" Text=""></asp:TextBox>
    </div>
    <br/>
    <h3>Второе сообщение</h3>
    <div title="Второе сообщение">
        <asp:Label ID="TypeMessageSecondLabel" runat="server" Text="Тип сообщения"></asp:Label>
        <asp:TextBox ID="TypeMessageSecond" runat="server" Text=""></asp:TextBox><br />
        <br/>
        <asp:Label ID="NameSecondLabel" runat="server" Text="Название"></asp:Label>
        <asp:TextBox ID="NameSecond" runat="server" Text=""></asp:TextBox><br />
        <br/>
        <asp:Label ID="AdressSecondLabel" runat="server" Text="Адрес находки"></asp:Label>
        <asp:TextBox ID="AdressSecond" runat="server" Text=""></asp:TextBox><br />
        <br/>
        <asp:Label ID="DateSecondLabel" runat="server" Text="Дата находки"></asp:Label>
        <asp:TextBox ID="DateSecond" runat="server" Text=""></asp:TextBox><br />
        <br/>
        <asp:Label ID="TypeSecondLabel" runat="server" Text="Тип находки"></asp:Label>
        <asp:TextBox ID="TypeSecond" runat="server" Text=""></asp:TextBox><br />
        <br/>
        <asp:Label ID="ColorSecondLabel" runat="server" Text="Цвет"></asp:Label>
        <asp:TextBox ID="ColorSecond" runat="server" Text=""></asp:TextBox><br />
        <br/>
        <asp:Label ID="SizeSecondLabel" runat="server" Text="Размер"></asp:Label>
        <asp:TextBox ID="SizeSecond" runat="server" Text=""></asp:TextBox><br />
        <br/>
        <asp:Label ID="BreedSecondLabel" runat="server" Text="Порода"></asp:Label>
        <asp:TextBox ID="BreedSecond" runat="server" Text=""></asp:TextBox><br />
        <br/>
        <asp:Label ID="DescriptionSecondLabel" runat="server" Text="Описание"></asp:Label>
        <asp:TextBox ID="DescriptionSecond" runat="server" Text=""></asp:TextBox>
    </div>
    <br/>
    <div title="Проверка совпадение данных">
        <asp:Button ID="Compare" runat="server" Text="Сравнить" BackColor="green" OnClick="Compare_OnClick"/><br/>
        <br/>
        <asp:Label ID="ResultLabel" runat="server" Text="Результаты сравнения"></asp:Label>
        <asp:TextBox ID="Result" runat="server" ReadOnly="True" Text=""></asp:TextBox>
    </div>
