<%@ Page Title="Results" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="WebVocabulary2.Results" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="data-container">
        
        <div class="col-md-8 col-md-offset-2 container-border">

            <asp:ListView ID="lvResults" runat="server" OnItemDataBound="lvResults_ItemDataBound">
                <LayoutTemplate>
                    <div  class="row header-style align-center">
                        <h4 class="col-xs-12 "><asp:Literal runat="server" ID="litResults" meta:resourcekey="litResults"></asp:Literal></h4>
                    </div>

                    <asp:PlaceHolder ID="itemPlaceholder" runat="server">                
                    </asp:PlaceHolder>
                    <br />
                </LayoutTemplate>
                
                <ItemTemplate>
                    <div class='row <%# Convert.ToBoolean(Container.DataItemIndex % 2) ? "odd-row-style" : "even-row-style" %>'>
                        <asp:HyperLink runat="server" ID="hlWord" CssClass="col-xs-6" Text='<%# Eval("Name") %>' NavigateUrl='<%# "DisplayWord.aspx?pid=" + Eval("ID") %>'></asp:HyperLink>
                        <asp:Label runat="server" ID="lblCategory" CssClass="col-xs-6"></asp:Label>
                    </div>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <div class="row formview-container-style">
                        <asp:Label runat="server" ID="lblNoData" CssClass="col-xs-12" meta:resourcekey="lblNoData"></asp:Label>
                    </div>
                </EmptyDataTemplate>
            </asp:ListView>

        </div>
        
    </div>     
   <div class="clear"></div>
</asp:Content>
