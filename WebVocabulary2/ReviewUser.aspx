<%@ Page Title="Review user" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReviewUser.aspx.cs" Inherits="WebVocabulary2.ReviewUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="data-container">
        <div class="col-md-8 col-md-offset-2 user-search-box">
            <div class="input-form1 input-group">
                <asp:TextBox runat="server" ID="tbUserName" MaxLength="30" CssClass="form-control" placeholder="Search for..."></asp:TextBox>

                <span class="input-group-btn">
                    <asp:Button ID="btnSearchUsers" runat="server" OnClick="btnSearchUsers_Click" CssClass="ui-button ui-state-default ui-corner-all user-search-btn" meta:resourcekey="btnSearchUsers" />
                </span>
            </div>
        </div>
        <br />
        <br />
        <br />
        <div id="divContainerBorder" runat="server" class="col-md-8 col-md-offset-2 container-border">
            <asp:ListView runat="server" ID="lvUserList">
                <LayoutTemplate>
                    <div class="row header-style align-center">
                        <h4 class="col-xs-12 ">
                            <asp:Literal runat="server" ID="litUserList" meta:resourcekey="litUserList"></asp:Literal></h4>
                    </div>

                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                    <br />
                </LayoutTemplate>

                <ItemTemplate>

                    <div class='row <%# Convert.ToBoolean(Container.DataItemIndex % 2) ? "odd-row-style" : "even-row-style" %>'>

                        <asp:Label runat="server" ID="lblUserName" CssClass="col-md-7" Text='<%# Eval("Name")%>'></asp:Label>

                        <span class="list-btns">
                            <asp:ImageButton ID="ibtnDeleteUser" runat="server" OnCommand="ibtnDeleteUser_Command" CommandArgument='<%#: Eval("ID") %>' ImageUrl="~/Images/12_Delete-icon.png" />
                        </span>

                        <asp:HyperLink ID="hlSendMessage" runat="server" NavigateUrl='<%#:"~/NewMessage.aspx?p=" + Eval("ID") %>'
                            CssClass="list-btns" ImageUrl="~/Images/Mail-12.png" />
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

    <script>

        $("#<%= tbUserName.ClientID %>").autocomplete({
            source: function (request, responce) {
                $.ajax({
                    type: "POST",
                    url: "GetAutoCompleteData.ashx/LoadUsers",
                    data: {
                        q: request.term
                    },
                    success: function (data) {
                        
                        responce($.map(data, function (item) {
                            return { value: item.Name, Name: item.Name };                            
                        }))                        
                    }                    
                });
            },
            minLength: 2
        });

    </script>

</asp:Content>
