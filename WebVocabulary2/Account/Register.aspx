<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebVocabulary2.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <div class="data-container">
        <div class="col-md-8 col-md-offset-2" id="divEdit">
            <div class="col-xs-12 panel panel-info margin-after">
                <div class="panel-heading">
                    <asp:Label runat="server" ID="lblPanelTitle" meta:resourcekey="lblPanelTitle"></asp:Label>
                </div>
                <asp:Panel ID="pnlRegister" runat="server" DefaultButton="btnRegister" class="panel-body">

                    <div class="input-form">
                        <asp:Label runat="server" AssociatedControlID="tbUserName" CssClass="col-md-2" meta:resourcekey="lblUserName"></asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="tbUserName" MaxLength="30" meta:resourcekey="tbUserName" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="tbUserName" ValidationGroup="Register" ForeColor="Red" Display="Dynamic" meta:resourcekey="requiredFieldValidator" />
                        </div>
                    </div>

                    <div class="col-md-12">
                        <hr />
                    </div>

                    <div class="input-form">
                        <asp:Label ID="lblPassword" runat="server" AssociatedControlID="tbPassword" CssClass="col-md-2" meta:resourcekey="lblPassword"></asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="tbPassword" TextMode="Password" MaxLength="20" CssClass="form-control" meta:resourcekey="tbPassword" />
                            <asp:RequiredFieldValidator runat="server" ValidationGroup="Register" ControlToValidate="tbPassword" meta:resourcekey="requiredFieldValidator" ForeColor="Red" Display="Dynamic" />
                        </div>
                    </div>

                    <div class="col-md-12">
                        <hr />
                    </div>

                    <div class="input-form">
                        <asp:Label runat="server" AssociatedControlID="tbConfirmPassword" CssClass="col-md-2" meta:resourcekey="lblConfirmPassword" ID="lblConfirmPassword"></asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="tbConfirmPassword" TextMode="Password" MaxLength="20" CssClass="form-control" meta:resourcekey="tbConfirmPassword" />
                            <asp:RequiredFieldValidator runat="server" ValidationGroup="Register" ControlToValidate="tbConfirmPassword" Display="Dynamic" meta:resourcekey="requiredFieldValidator" ForeColor="Red" />
                            <asp:CompareValidator runat="server" ValidationGroup="Register" ControlToCompare="tbPassword" ControlToValidate="tbConfirmPassword" Display="Dynamic" ForeColor="Red" meta:resourcekey="compareValidator" />
                        </div>
                    </div>
                </asp:Panel>
            </div>

            <div class="col-xs-12 align-center">
                <asp:Button ID="btnRegister" runat="server" ValidationGroup="Register" OnClick="btnRegister_Click" CssClass="ui-button ui-state-default ui-corner-all ui-button-text-only" meta:resourcekey="btnRegister" />
            </div>

        </div>
    </div>
    <div class="clear"></div>

    <asp:HiddenField runat="server" ID="hfResult" />
    <asp:Panel ID="pnlDialog" runat="server" meta:resourcekey="pnlDialog">
        <p><asp:Literal runat="server" ID="litResult"></asp:Literal></p>
    </asp:Panel>
    <script>
        $(function () {
            var result = $('#<%= hfResult.ClientID %>').val();
            if (result == 1) {
                $('#<%= hfResult.ClientID %>').val("");
                $('#<%= pnlDialog.ClientID %>').dialog({

                    open: function () {
                        $(this).closest(".ui-dialog")
                        .find(".ui-dialog-titlebar-close")
                        .removeClass("ui-dialog-titlebar-close")
                        .addClass("ui-button ui-widget ui-state-default ui-corner-all ui-button-icon-only ui-dialog-titlebar-close")
                        .html('<span class="ui-button-icon-primary ui-icon ui-icon-closethick"></span><span class="ui-button-text">Close</span>');
                    }
                });

            }
            if (result == 0) {
                $('#<%= hfResult.ClientID %>').val("");
                $('#<%= pnlDialog.ClientID %>').dialog();
            }
        });
    </script>
</asp:Content>
