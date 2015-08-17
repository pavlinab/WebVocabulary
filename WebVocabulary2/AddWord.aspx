<%@ Page Title="Add word" Language="C#" MasterPageFile="~/Site.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="AddWord.aspx.cs" Inherits="WebVocabulary2.AddWord" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="pnlWord" runat="server" CssClass="data-container" DefaultButton="btnAddWord">
        
        <div class="col-md-10 col-md-offset-1" id="divEdit">
            
            <div class="col-md-6">
                <div class="panel panel-info margin-after">
                    <div class="panel-heading">
                        <asp:RequiredFieldValidator ID="rfvWordEn" runat="server" ValidationGroup="AddWord" ControlToValidate="tbWordEn" meta:resourcekey="requiredFieldValidator" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="cvWordEn" runat="server" OnServerValidate="cvLatin_ServerValidate" ValidationGroup="AddWord" meta:resourcekey="LatinValidator" ControlToValidate="tbWordEn" ForeColor="Red" Display="Dynamic"></asp:CustomValidator>                        
                        <asp:CustomValidator ID="cvExistingWordEn" runat="server" OnServerValidate="cvExistingWordEn_ServerValidate" ValidationGroup="AddWord" meta:resourcekey="IsWordExistValidator" ControlToValidate="tbWordEn" ForeColor="Red" Display="Dynamic"></asp:CustomValidator>
                        <asp:TextBox runat="server" ID="tbWordEn" MaxLength="90" meta:resourcekey="tbWord" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="panel-body">
                        <div class="div-dropdown">                            
                          <asp:DropDownList ID="ddlCategoriesEn" runat="server" CssClass="dropdownlist"></asp:DropDownList>
                           <span class="dropdown-button"></span>
                        </div>

                        <hr />
                        <asp:RequiredFieldValidator ID="rfvMeaningEn" runat="server" ValidationGroup="AddWord" ControlToValidate="ftbMeaningEn" meta:resourcekey="requiredFieldValidator" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="cvMeaningEn" runat="server" OnServerValidate="cvLatin_ServerValidate" ValidationGroup="AddWord" meta:resourcekey="LatinValidator" ControlToValidate="ftbMeaningEn" ForeColor="Red" Display="Dynamic"></asp:CustomValidator>                        
                        <FTB:FreeTextBox ID="ftbMeaningEn" BackColor="#AECBE9" runat="server" SupportFolder="Controls/FreeTextBox/" Height="300px" Width="100%"></FTB:FreeTextBox>

                    </div>
                </div>
            </div>            

            <div class="col-md-6">
                <div class="panel panel-info margin-before">
                    <div class="panel-heading">
                        <asp:RequiredFieldValidator ID="rfvWordBg" runat="server" ValidationGroup="AddWord" ControlToValidate="tbWordBg" meta:resourcekey="requiredFieldValidator" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="cvWordBg" runat="server" OnServerValidate="cvCyrillic_ServerValidate" ValidationGroup="AddWord" meta:resourcekey="CyrillicValidator" ControlToValidate="tbWordBg" ForeColor="Red" Display="Dynamic"></asp:CustomValidator>
                        <asp:CustomValidator ID="cvExistingWordBg" runat="server" OnServerValidate="cvExistingWordBg_ServerValidate" ValidationGroup="AddWord" meta:resourcekey="IsWordExistValidator" ControlToValidate="tbWordBg" ForeColor="Red" Display="Dynamic"></asp:CustomValidator>
                        <asp:TextBox runat="server" ID="tbWordBg" MaxLength="90" meta:resourcekey="tbWord" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="panel-body">
                        <div class="div-dropdown">                             
                          <asp:DropDownList ID="ddlCategoriesBg" runat="server" CssClass="dropdownlist"></asp:DropDownList>
                           <span class="dropdown-button"></span>
                        </div>
                       
                        <hr />
                        <asp:RequiredFieldValidator ID="rfvMeaningBg" runat="server" ValidationGroup="AddWord" ControlToValidate="ftbMeaningBg" meta:resourcekey="requiredFieldValidator" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="cuMeaningBg" runat="server" OnServerValidate="cvCyrillic_ServerValidate" ValidationGroup="AddWord" meta:resourcekey="CyrillicValidator" ControlToValidate="ftbMeaningBg" ForeColor="Red" Display="Dynamic"></asp:CustomValidator>
                        <FTB:FreeTextBox ID="ftbMeaningBg" BackColor="#AECBE9" runat="server" SupportFolder="Controls/FreeTextBox/" Height="300px" Width="100%"></FTB:FreeTextBox>                        
                    </div>
                </div>
            </div>                
            <div class="col-xs-12 align-center">
                <asp:Button ID="btnAddWord" runat="server" ValidationGroup="AddWord" CssClass="ui-button ui-state-default ui-corner-all ui-button-text-only" meta:resourcekey="btnAddWord" OnClick="btnAddWord_Click" />
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
            if (result == 1)
            {
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
