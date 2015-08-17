<%@ Page Title="New message" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewMessage.aspx.cs" Inherits="WebVocabulary2.NewMessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="data-container">
        
        <div class="col-md-8 col-md-offset-2" id="divEdit">
            <div class="col-xs-12 panel panel-info margin-after">
                <div class="panel-heading">
                    <asp:Label runat="server" ID="lblPanelTitle" meta:resourcekey="lblPanelTitle"></asp:Label>
                </div>
                <asp:Panel ID="pnlSendMessage" runat="server" DefaultButton="btnSend" class="panel-body">
                    <div class="input-form">
                        <asp:Label ID="lblRecipient" runat="server" AssociatedControlID="tbRecipient" CssClass="col-md-2" meta:resourcekey="lblRecipient"></asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="tbRecipient" MaxLength="30" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvRecipient" runat="server" ValidationGroup="SendMessage" ControlToValidate="tbRecipient" meta:resourcekey="requiredFieldValidator" ForeColor="Red" Display="Dynamic"/>
                            
                        </div>
                    </div>
                    <div class="col-md-12">
                        <hr />
                    </div>
                    <div class="input-form">
                        <div class="col-md-12">
                            <asp:TextBox runat="server" ID="tbMessageText" TextMode="MultiLine" MaxLength="2000" CssClass="form-control" meta:resourcekey="tbMessageText" />
                            <asp:RequiredFieldValidator ID="rfvMessageText" runat="server" ValidationGroup="SendMessage" ControlToValidate="tbMessageText" meta:resourcekey="requiredFieldValidator" ForeColor="Red" Display="Dynamic"/>
                        </div>
                    </div>
                                       
                </asp:Panel>
            </div>
            
            <div class="col-xs-12 align-center">
                <asp:Button ID="btnSend" runat="server" ValidationGroup="SendMessage" OnClick="btnSend_Click" CssClass="ui-button ui-state-default ui-corner-all ui-button-text-only" meta:resourcekey="btnSend" />
            </div>                    

        </div>

    </div>
    <div class="clear"></div>
</asp:Content>
