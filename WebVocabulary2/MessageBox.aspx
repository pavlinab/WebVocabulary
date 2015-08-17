<%@ Page Title="Message box" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MessageBox.aspx.cs" Inherits="WebVocabulary2.MessageBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:MultiView runat="server" ID="mvMessageBox">
        
        <asp:View runat="server" ID="vSendedMessages">
            <div class="col-md-8 col-md-offset-2 container-border">
                <asp:ListView runat="server" ID="lvSendedMessages" OnItemDataBound="lvSendedMessages_ItemDataBound">
                    <LayoutTemplate>
                        <div class="row header-style align-center">
                            <h4 class="col-xs-12 ">
                                <asp:Literal runat="server" ID="litSendedMessages" meta:resourcekey="litSendedMessages"></asp:Literal></h4>
                        </div>

                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                        <br />
                    </LayoutTemplate>

                    <ItemTemplate>
                        
                         <div class='row <%# Convert.ToBoolean(Container.DataItemIndex % 2) ? "odd-row-style" : "even-row-style" %>'>
                            <asp:HyperLink runat="server" ID="hlSendedMessages" CssClass="col-xs-12" NavigateUrl='<%# "DisplayMessage.aspx?p=" + Eval("ID") %>'>
                                <asp:Label runat="server" ID="lblMessageDate" CssClass="col-md-2" Text='<%# Eval("MessageDate", "{0:d}") %>'></asp:Label>
                                <asp:Label runat="server" ID="lblContent" CssClass="col-md-7" Text='<%# Eval("Content") %>'></asp:Label>
                                <asp:Label runat="server" ID="lblRecipient" CssClass="col-md-3"></asp:Label>
                            </asp:HyperLink>
                         </div>
                        
                    </ItemTemplate>

                    <EmptyDataTemplate>
                        <div class="row formview-container-style">
                            <asp:Label runat="server" ID="lblNoData" CssClass="col-xs-12" meta:resourcekey="lblSendedMessagesNoData"></asp:Label>
                        </div>
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>
            <div class="clear"></div>
        </asp:View>

        <asp:View runat="server" ID="vReceivedMessages">
            <div class="col-md-8 col-md-offset-2 container-border">
                <asp:ListView runat="server" ID="lvReceivedMessages" OnItemDataBound="lvReceivedMessages_ItemDataBound">
                    <LayoutTemplate>
                        <div  class="row header-style align-center">
                            <h4 class="col-xs-12 "><asp:Literal runat="server" ID="litReceivedMessages" meta:resourcekey="litReceivedMessages"></asp:Literal></h4>
                        </div>

                        <asp:PlaceHolder ID="itemPlaceholder" runat="server">                
                        </asp:PlaceHolder>
                        <br />
                    </LayoutTemplate>
                
                    <ItemTemplate>
                        <div class='row <%# Convert.ToBoolean(Container.DataItemIndex % 2) ? "odd-row-style" : "even-row-style" %>'>
                            <asp:HyperLink runat="server" ID="hlReceivedMessages" CssClass="col-xs-12" NavigateUrl='<%# "DisplayMessage.aspx?p=" + Eval("ID") %>'>                                
                                <asp:Label runat="server" ID="lblMessageDate" CssClass="col-xs-2" Text='<%# Eval("MessageDate", "{0:d}") %>'></asp:Label>
                                <asp:Label runat="server" ID="lblContent" CssClass="col-xs-7" Text='<%# Eval("Content") %>'></asp:Label>
                                <asp:Label runat="server" ID="lblSender" CssClass="col-xs-3"></asp:Label>
                            </asp:HyperLink>
                        </div>
                        
                    </ItemTemplate>

                    <EmptyDataTemplate>
                        <div class="row formview-container-style">
                            <asp:Label runat="server" ID="lblNoData" CssClass="col-xs-12" meta:resourcekey="lblReceivedMessagesNoData"></asp:Label>
                        </div>
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>
            <div class="clear"></div>
        </asp:View>
    </asp:MultiView>

</asp:Content>
