<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebVocabulary2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="data-container">
        
        <div class="col-md-8 col-md-offset-2 container-border">
            <asp:ListView ID="lvCategories" runat="server" OnItemDataBound="lvCateories_ItemDataBound">
                <LayoutTemplate>
                    <div  class="row header-style">
                        <h4 class="col-xs-7 "><asp:Literal runat="server" ID="litCategories" meta:resourcekey="litCategories"></asp:Literal></h4>
                        <h4 class="col-xs-5 "><asp:Literal runat="server" ID="litWordCount" meta:resourcekey="litWordCount"></asp:Literal></h4>
                    </div>

                    <asp:PlaceHolder ID="itemPlaceholder" runat="server">
                
                    </asp:PlaceHolder>
                    <br />
                </LayoutTemplate>

                <ItemTemplate>
                    <div class='row <%# Convert.ToBoolean(Container.DataItemIndex % 2) ? "odd-row-style" : "even-row-style" %>'>
                        <asp:Label runat="server" ID="lblCategory" CssClass="col-xs-7" Text='<%# Eval("Name") %>'></asp:Label>
                        <asp:Label runat="server" ID="lblWordCountInCategory" CssClass="col-xs-5"></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>

    </div>
     
   <div class="clear"></div>
    
</asp:Content>
   