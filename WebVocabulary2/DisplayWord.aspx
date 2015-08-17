<%@ Page Title="Review word" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DisplayWord.aspx.cs" Inherits="WebVocabulary2.DisplayWord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="data-container">
        
        <div class="col-md-8 col-md-offset-2 container-border">
            <asp:FormView ID="fvWord" runat="server" RenderOuterTable="false" DataKeyNames="ID" ItemType="WebVocabulary2.Models.Word" 
                SelectMethod="fvWord_GetItem" OnDataBound="fvWord_DataBound">
                <ItemTemplate>
                    <div  class="row header-style">
                        <h4 class="col-xs-12 "><asp:Literal runat="server" ID="litWord" Text='<%#: Item.Name %>'></asp:Literal></h4>
                        <asp:ImageButton ID="ibtnDeleteWord" runat="server" CommandArgument='<%#: Item.ID %>' CssClass="delete-btn" OnCommand="ibtnDeleteWord_Command" ImageUrl="~/Images/18_Delete-icon.png" />                        
                    </div>
                    <div class="row formview-subtitle-style">
                        <h5 class="col-xs-12 "><asp:Literal runat="server" ID="litCategory" ></asp:Literal></h5>
                    </div>
                    <div class="row formview-container-style">
                        <asp:Label runat="server" ID="lblWordMeaning" CssClass="col-xs-12" Text="<%# Item.Description %>"></asp:Label>
                    </div>
                </ItemTemplate>
            </asp:FormView>
        </div>
        
    </div>     
   <div class="clear"></div>

</asp:Content>
