<%@ Page Title="Add category" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="WebVocabulary2.AddCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="pnlCategory" runat="server" CssClass="data-container" DefaultButton="btnAddCategory">
        
        <div class="col-md-8 col-md-offset-2" id="divEdit">
            <div class="col-xs-12 panel panel-info margin-after">
                <div class="panel-heading">
                    <asp:Label runat="server" ID="lblPanelTitle" meta:resourcekey="lblPanelTitle"></asp:Label>
                </div>
                <div class="panel-body">
                    <div class="input-form">
                        <asp:Label ID="lblCategoryEn" runat="server" AssociatedControlID="tbCategoryEn" CssClass="col-md-2" meta:resourcekey="lblCategoryEn"></asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="tbCategoryEn" MaxLength="90" meta:resourcekey="tbCategory" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCategoryEn" runat="server" ValidationGroup="AddCategory" ControlToValidate="tbCategoryEn" meta:resourcekey="requiredFieldValidator" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="cvLatin" runat="server" OnServerValidate="cvLatin_ServerValidate" ValidationGroup="AddCategory" meta:resourcekey="LatinValidator" ControlToValidate="tbCategoryEn" ForeColor="Red" Display="Dynamic"></asp:CustomValidator>                        
                            <asp:CustomValidator ID="cvExistingCategoryEn" OnServerValidate="cvExistingCategory_ServerValidate" runat="server" ValidationGroup="AddCategory" meta:resourcekey="IsCategoryExistValidator" ControlToValidate="tbCategoryEn" ForeColor="Red" Display="Dynamic"></asp:CustomValidator>
                    
                        </div>
                    </div>
                    <div class="col-md-12">
                        <hr />
                    </div>
                    <div class="input-form">
                        <asp:Label ID="lblCategoryBg" runat="server" AssociatedControlID="tbCategoryBg" CssClass="col-md-2" meta:resourcekey="lblCategoryBg"></asp:Label>                    
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="tbCategoryBg" MaxLength="90" meta:resourcekey="tbCategory" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCategoryBg" runat="server" ValidationGroup="AddCategory" ControlToValidate="tbCategoryBg" meta:resourcekey="requiredFieldValidator" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="cvCyrillic" runat="server" OnServerValidate="cvCyrillic_ServerValidate" ValidationGroup="AddCategory" meta:resourcekey="CyrillicValidator" ControlToValidate="tbCategoryBg" ForeColor="Red" Display="Dynamic"></asp:CustomValidator>                        
                            <asp:CustomValidator ID="cvExistingCategoryBg" runat="server" OnServerValidate="cvExistingCategory_ServerValidate" ValidationGroup="AddCategory" meta:resourcekey="IsCategoryExistValidator" ControlToValidate="tbCategoryBg" ForeColor="Red" Display="Dynamic"></asp:CustomValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xs-12 align-center">
                <asp:Button ID="btnAddCategory" runat="server" OnClick="btnAddCategory_Click" ValidationGroup="AddCategory" CssClass="ui-button ui-state-default ui-corner-all ui-button-text-only" meta:resourcekey="btnAddCategory" />
            </div>
        </div>
        
    </asp:Panel>     
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
