<%@ Page Title="Review message" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DisplayMessage.aspx.cs" Inherits="WebVocabulary2.DisplayMessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="data-container">
        
        <div id="divEdit" class="col-md-8 col-md-offset-2">
            <asp:FormView ID="fvMessage" runat="server" RenderOuterTable="false" DataKeyNames="ID" ItemType="WebVocabulary2.Models.Message" 
                 SelectMethod="fvMessage_GetItem" OnDataBound="fvMessage_DataBound">
                <ItemTemplate>
                    <div class="col-xs-12 panel panel-info margin-after">
                        <div class="panel-heading">
                            <asp:Label runat="server" ID="lblPanelTitle" Text='<%#: Item.MessageDate %>'></asp:Label>
                            <asp:ImageButton ID="ibtnDeleteMessage" runat="server" CommandArgument='<%#: Item.ID %>' CssClass="ui-button ui-state-default ui-corner-all display-message-btns" OnCommand="ibtnDeleteMessage_Command" ImageUrl="~/Images/12_Delete-icon.png" />
                            <asp:HyperLink ID="hlAnswer" runat="server" NavigateUrl='<%#:"~/NewMessage.aspx?p=" + Item.ID %>' 
                                CssClass="ui-button ui-state-default ui-corner-all ui-button-text-only display-message-btns" meta:resourcekey="hlAnswer" />                        
                        </div>
                        <asp:Panel ID="pnlDisplayMessage" runat="server" class="panel-body">
                            <div class="input-form">
                                <asp:Label ID="lblSender" runat="server" CssClass="col-md-12"></asp:Label> <br />
                                <asp:Label ID="lblRecipient" runat="server" CssClass="col-md-12"></asp:Label>
                            </div>
                            <div class="col-md-12">
                                <hr />
                            </div>
                            <div class="input-form">
                                <div class="col-md-12">
                                    <asp:Label ID="lblMessageText" runat="server" Text='<%#: Item.Content %>'></asp:Label>
                                </div>
                            </div>
                                       
                        </asp:Panel>
                    </div>
                </ItemTemplate>
            </asp:FormView>
        </div>
        
    </div>     
   <div class="clear"></div>
</asp:Content>
