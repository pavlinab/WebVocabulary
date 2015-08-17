<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebVocabulary2.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
    <div class="data-container">
        
        <div class="col-md-8 col-md-offset-2" id="divEdit">
            <div class="col-xs-12 panel panel-info margin-after">
                <div class="panel-heading">
                    <asp:Label runat="server" ID="lblPanelTitle" meta:resourcekey="lblPanelTitle"></asp:Label>
                </div>
                <asp:Panel ID="pnlLogin" runat="server" DefaultButton="btnLogin" class="panel-body">
                    <div class="input-form">
                        <asp:Label runat="server" ID="lblFail" Visible="false" ></asp:Label>
                        <asp:Label ID="lblUserName" runat="server" AssociatedControlID="tbUserName" CssClass="col-md-2" meta:resourcekey="lblUserName"></asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="tbUserName" MaxLength="30" meta:resourcekey="tbUserName" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ValidationGroup="Login" ControlToValidate="tbUserName" meta:resourcekey="requiredFieldValidator" ForeColor="Red" Display="Dynamic"/>
                            
                        </div>
                    </div>
                    <div class="col-md-12">
                        <hr />
                    </div>
                    <div class="input-form">
                        <asp:Label ID="lblPassword" runat="server" AssociatedControlID="tbPassword" CssClass="col-md-2" meta:resourcekey="lblPassword"></asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="tbPassword" TextMode="Password" MaxLength="20" CssClass="form-control" meta:resourcekey="tbPassword" />
                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ValidationGroup="Login" ControlToValidate="tbPassword" meta:resourcekey="requiredFieldValidator" ForeColor="Red" Display="Dynamic"/>
                        </div>
                    </div>
                                        
                </asp:Panel>
            </div>
                        
            <div class="col-xs-12 align-center">
                <asp:Button ID="btnLogin" runat="server" ValidationGroup="Login" OnClick="btnLogin_Click" CssClass="ui-button ui-state-default ui-corner-all ui-button-text-only" meta:resourcekey="btnLogin" />
            </div>                    

        </div>
    </div>
    <div class="clear"></div>
</asp:Content>
