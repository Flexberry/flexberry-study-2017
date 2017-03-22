<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="ICSSoft.STORMNET.Web.LoginForm" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head ID="Head1" runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Вход в систему</title>
    <asp:PlaceHolder ID="FlexberryStyles" runat="server" />
</head>
<body class="login-form">
    <form ID="form" runat="server">
        <div class="container">
            <div class="login-form-header">
                <div>
                    <asp:Localize ID="Localize2" runat="server" Text="<%$ Resources: Resource, Master_Page_Header_Title %>" />
                </div>
            </div>
            <div class="login-form-inner">
                <h2>
                    <asp:Localize ID="Localize1" runat="server" Text="<%$ Resources: Resource, Log_In %>" />
                </h2>
                <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false">
                    <LayoutTemplate>
                        <asp:Label CssClass="login-from-failure-text" ID="FailureText" runat="server" />
                        <asp:ValidationSummary CssClass="failureNotification" ID="LoginUserValidationSummary" runat="server" ValidationGroup="LoginUserValidationGroup" Visible="False" />
                        
                        <%-- User name. --%>
                        <asp:Label AssociatedControlID="UserName" CssClass="login-form-label" ID="UserNameLabel" runat="server">
                            <asp:Localize ID="Localize2" runat="server" Text="<%$ Resources: Resource, Login %>" />
                        </asp:Label>
                        <asp:RequiredFieldValidator
                            ControlToValidate="UserName"
                            CssClass="failureNotification"
                            ErrorMessage="<%$ Resources: Resource, Required %>"
                            ID="UserNameRequired"
                            runat="server"
                            ToolTip="<%$ Resources: Resource, Required %>"
                            ValidationGroup="LoginUserValidationGroup"/>
                        <asp:TextBox CssClass="login-form-input input-block-level" ID="UserName" Placeholder="Логин" runat="server" />
                        
                        <%-- Password. --%>
                        <asp:Label AssociatedControlID="Password" CssClass="login-form-label" ID="PasswordLabel" runat="server">
                            <asp:Localize ID="Localize3" runat="server" Text="<%$ Resources: Resource, Password %>" />
                        </asp:Label>
                        <asp:RequiredFieldValidator
                            ControlToValidate="Password"
                            CssClass="failureNotification"
                            ErrorMessage="<%$ Resources: Resource, Required %>"
                            ID="PasswordRequired"
                            runat="server"
                            ToolTip="<%$ Resources: Resource, Required %>"
                            ValidationGroup="LoginUserValidationGroup"/>
                        <asp:TextBox CssClass="login-form-input input-block-level" ID="Password" Placeholder="Пароль" runat="server" TextMode="Password" />
                        
                        <%--
                        <span class="login-form-remember">
                             <asp:CheckBox ID="RememberMe" runat="server" Text="Запомнить меня" />
                        </span>
                        <span class="login-form-forgot">
                            <a href="#"><asp:Literal ID="RemindPassword" runat="server" Text="Забыли пароль?" /></a>
                         </span>
                        --%>
                        <asp:Button CommandName="Login" CssClass="ics-btn login-form-btn" ID="LoginButton" runat="server" Text="<%$ Resources: Resource, Enter %>" ValidationGroup="LoginUserValidationGroup" />
                    </LayoutTemplate>
                </asp:Login>
            </div>
        </div>
    </form>
    <asp:PlaceHolder ID="FlexberryScripts" runat="server" />
    <asp:PlaceHolder ID="FlexberryRawHtml" runat="server"/>
</body>
</html>
