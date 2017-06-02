<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ErrorForm.aspx.cs"
    Inherits="ICSSoft.STORMNET.Web.ErrorForm" Title="Произошла ошибка" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ics-form ics-form-list">
        <h2>
            <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources: Resource, Error_Occurred %>"></asp:Literal></h2>
        <div class="ics-form-row">
            <asp:Label ID="MessageLabel" runat="server"></asp:Label>
        </div>
        <div class="ics-form-row">
            <asp:Label ID="ErrorNumCaption" CssClass="ics-form-label" runat="server" Text="<%$ Resources: Resource, Displayed_Error %>"></asp:Label>
            <div class="ics-form-controls">
                <select id="SelectErr" runat="server" class="span2"></select>
            </div>
        </div>
        <asp:Panel ID="Panel4Controls" runat="server">
        </asp:Panel>
    </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder0" ID="Content0" runat="server">
    <asp:Literal ID="ScriptHolder" runat="server" />
    <script type="text/javascript">
        function OnErrorChanged(ctrl, arr) {
            for (var i = 0; i < arr.length; i++) {
                if (i == ctrl.value) {
                    document.getElementById(arr[i]).style.display = "block";
                }
                else {
                    document.getElementById(arr[i]).style.display = "none";
                }
            }
        }
    </script>
</asp:Content>
