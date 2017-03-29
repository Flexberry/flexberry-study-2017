﻿<%--flexberryautogenerated="false"--%>
<%@ Page Language="C#" 
    MasterPageFile="~/Site1.Master"  
    AutoEventWireup="true" 
    CodeBehind="ExceptionDayE.aspx.cs" 
    Inherits="IIS.BusinessCalendar.ExceptionDayE" %>
<%@ Import namespace="NewPlatform.Flexberry.Web.Page" %>
<%@ Register TagPrefix="ac" 
    TagName="TimeSpanView" 
    Src="~/Controls/TimeSpanView/TimeSpanView.ascx" %>
<%-- Autogenerated section start [Register] --%>
<%-- Autogenerated section end [Register] --%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="<%= Constants.FormCssClass %> <%= Constants.EditFormCssClass %>">
        <h2 class="<%= Constants.FormHeaderCssClass %> <%= Constants.EditFormHeaderCssClass %>">День-исключение</h2>
        <div class="<%= Constants.FormToolbarCssClass %> <%= Constants.EditFormToolbarCssClass %> <%= Constants.StickyCssClass %>">
            <asp:ImageButton ID="SaveBtn" runat="server" SkinID="SaveBtn" OnClick="SaveBtn_Click" AlternateText="<%$ Resources: Resource, Save %>" ValidationGroup="savedoc" />
            <asp:ImageButton ID="SaveAndCloseBtn" runat="server" SkinID="SaveAndCloseBtn" OnClick="SaveAndCloseBtn_Click" AlternateText="<%$ Resources: Resource, Save_Close %>" ValidationGroup="savedoc" />
            <asp:ImageButton ID="CancelBtn" runat="server" SkinID="CancelBtn" OnClick="CancelBtn_Click" AlternateText="<%$ Resources: Resource, Cancel %>" />
        </div>
        <div class="<%= Constants.FormControlsCssClass %> <%= Constants.EditFormControlsCssClass %>">
            <%-- Autogenerated section start [Controls] --%>
<!-- autogenerated start -->
            <div>
                <div class="clearfix">
                    <asp:Label CssClass="descLbl" ID="ctrlNameLabel" runat="server" Text="Название" EnableViewState="False">
                    </asp:Label>
                    <asp:TextBox CssClass="descTxt" ID="ctrlName" runat="server">
                    </asp:TextBox>

                </div>
                <div class="clearfix">
                    <asp:Label CssClass="descLbl" ID="ctrlDayTypeLabel" runat="server" Text="Тип дня" EnableViewState="False">
                    </asp:Label>
                    <asp:DropDownList ID="ctrlDayType" CssClass="descTxt" runat="server">
                        <asp:ListItem>Выходной</asp:ListItem>
                        <asp:ListItem>Рабочий</asp:ListItem>

                    </asp:DropDownList>
                </div>
                <div class="clearfix">
                    <asp:Label CssClass="descLbl" ID="ctrlRecurrenceTypeLabel" runat="server" Text="Тип повторения" EnableViewState="False">
                    </asp:Label>
                    <asp:DropDownList ID="ctrlRecurrenceType" CssClass="descTxt" runat="server">
                        <asp:ListItem>Ежедневно</asp:ListItem>
                        <asp:ListItem>Еженедельно</asp:ListItem>
                        <asp:ListItem>Ежемесячно</asp:ListItem>
                        <asp:ListItem>Ежегодно</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="clearfix">
                    <asp:Label CssClass="descLbl" ID="ctrlRepeatStepLabel" runat="server" Text="Шаг повторения" EnableViewState="False">
                    </asp:Label>
                    <ac:AlphaNumericTextBox CssClass="descTxt" ID="ctrlRepeatStep" Type="Numeric" runat="server">
                    </ac:AlphaNumericTextBox>

                </div>
                <div class="clearfix">
                    <asp:Label CssClass="descLbl" ID="ctrlStartDateLabel" runat="server" Text="Дата начала" EnableViewState="False">
                    </asp:Label>
                    <div class="descTxt">
                        <ac:DatePicker ID="ctrlStartDate" runat="server" />
                    </div>
                </div>
                <div class="clearfix">
                    <asp:Label CssClass="descLbl" ID="ctrlEndDateLabel" runat="server" Text="Дата окончания" EnableViewState="False">
                    </asp:Label>
                    <div class="descTxt">
                        <ac:DatePicker ID="ctrlEndDate" runat="server" />
                    </div>
                </div>
                <div class="clearfix">
                    <asp:Label CssClass="descLbl" ID="ctrlRecurrenceCountLabel" runat="server" Text="Количество повторений" EnableViewState="False">
                    </asp:Label>
                    <ac:AlphaNumericTextBox CssClass="descTxt" ID="ctrlRecurrenceCount" Type="Numeric" runat="server">
                    </ac:AlphaNumericTextBox>

                </div>
                <div class="clearfix">
                    <asp:Label CssClass="descLbl" ID="ctrlCalendarLabel" runat="server" Text="Календарь" EnableViewState="False">
                    </asp:Label>
                    <ac:MasterEditorAjaxDropDown ID="ctrlCalendar" CssClass="descTxt" runat="server" EnablePostBack="false" />

                    <asp:RequiredFieldValidator ID="ctrlCalendarValidator" runat="server" ControlToValidate="ctrlCalendar"
                        ErrorMessage="Не указано: Calendar" EnableClientScript="true" ValidationGroup="savedoc">*</asp:RequiredFieldValidator>

                </div>
                <div class="clearfix">
                    <asp:Label CssClass="descLbl" ID="ctrlCalendar_NameLabel" runat="server" Text="Название календаря" EnableViewState="False">
                    </asp:Label>
                    <asp:TextBox CssClass="descTxt" ID="ctrlCalendar_Name" runat="server" ReadOnly="true">
                    </asp:TextBox>

                </div>
                <div class="clearfix">
                    <asp:Label CssClass="descLbl" ID="ctrlWorkTimeDefinitionLabel" runat="server" Text="Определение рабочего времени" EnableViewState="False">
                    </asp:Label>
                    <ac:MasterEditorAjaxLookUp ID="ctrlWorkTimeDefinition" CssClass="descTxt" runat="server" ShowInThickBox="True" Autocomplete="true" />

                </div>
                <div class="clearfix">
                    <ac:TimeSpanView runat="server" ID="ctrlWorkTimeSpans"></ac:TimeSpanView>
                </div>
                <br />

            </div>
<!-- autogenerated end -->
            <%-- Autogenerated section end [Controls] --%>
        </div>
    </div>
</asp:Content>
