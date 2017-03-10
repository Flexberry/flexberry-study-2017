<%@ Page Title="Объекты" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Web.AddConsumers" %>
<%@ Import Namespace="Task1.DAL" %>
<%@ Import Namespace="Task1.Objects" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h3>Добавить объект</h3>
        
        <h3><asp:Label ID="TextBoxNameError1" runat="server" CssClass ="hidden" Text="Невозможно добавить объект с такими данными, т.к. код 1 для него не будет уникальным!"></asp:Label> </h3>
        <h3><asp:Label ID="TextBoxNameError2" runat="server" CssClass ="hidden" Text="Невозможно добавить объект с такими данными, т.к. код 2 для него не будет уникальным!"></asp:Label> </h3>
        
        <table class="table">
            <tr>
                <td><p>Наименование</p></td>
                <td><p><asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
                    
                    </p>
                    </td>
            </tr>
            <tr>
                <td><p>Дата регистрации</p></td>
                <td><p> <asp:Calendar ID="CalendarReg" runat="server"></asp:Calendar></p></td>
            </tr>
            <tr>
                <td><p>Лицевой счет (не более 19 цифр)</p></td>
                <td><p><asp:TextBox ID="TextBoxAccount" MaxLength="19" runat="server"></asp:TextBox>
                        <asp:Label ID="TextBoxAccountError" runat="server" CssClass ="hidden" Text="Проверьте введённое значение!"></asp:Label>
                    </p>
                    </td>
            </tr>
            <tr>
                <td><asp:Button ID="ButtonAdd" class="btn btn-primary btn-lg" runat="server" Text="Добавить" OnClick="ButtonAdd_Click" />
                    
                </td>
                <td><asp:Button ID="ButtonClear" class="btn btn-primary btn-lg" runat="server" Text="Очистить" OnClick="ButtonClear_OnClick"/></td>
            </tr>
        </table>

    <h3>Список объектов</h3>
    <asp:Repeater ID="ConsumersRepeater" runat="server">
        <HeaderTemplate>
            <table  class="table">
                <tr>
                    <th>Наименование</th>
                    <th>Дата регистрации</th>
                    <th>Лицевой счет</th>
                    <th><abbr title="Код состоит из 18 символов, в таком пордяке: 
                        8 - ГГГГММДД
                        5 - название пересчитанное в хэш и переведённое в 36 алф.  
                        5 - хэш лицевого счет переведённый в 36 афл.">Код объекта по алг. 1 </abbr></th>
                    <th><abbr title=" Код состоит из 18 символов, в таком пордяке:
                        3 - первые буквы названия
                        2 - цифры лиц счета
                        6 - ГГ, ММ, ДД
                        2 - год в 36 алф.
                        3 - хэш названия
                        2 - хэш лс">Код объекта по алг. 2</th>
                    <!--<th>Действие</th> -->
                </tr>
        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td><%# DataBinder.Eval(Container.DataItem, "Name") %></td>
                <td><%# ((DateTime)DataBinder.Eval(Container.DataItem, "DateReg")).ToString("D") %> </td>
                <td><%# DataBinder.Eval(Container.DataItem, "Account") %> </td>
                <td><%# Logic.Logic1.GenerateCode((Consumer)DataBinder.GetDataItem(Container)) %> </td>
                <td><%# Logic.Logic2.GenerateCode((Consumer)DataBinder.GetDataItem(Container)) %> </td>
                <td>
                   <!-- <a href="<%= Request.Url.AbsoluteUri + "?code="%><%# Logic.Logic1.GenerateCode((Consumer)DataBinder.GetDataItem(Container)) %>">Удалить</a></td> -->
            </tr>
        </ItemTemplate>

        <FooterTemplate>
            </table>
        </FooterTemplate>

    </asp:Repeater>
    </div>
</asp:Content>
