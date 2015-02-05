<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" MasterPageFile="~/Site.Master" Inherits="FinalWebApplication.Login" EnableViewState="false"%>
<%@ Register Src="~/DateTime.ascx" TagPrefix="dtConrtol" TagName="DateTimeControl" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>Your University</h1>
            </hgroup>
        </div>        
    </section>    
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div style="text-align: right; margin-left: 90%;">
            <dtConrtol:DateTimeControl runat="server" ID="dateTimeCtrl" Visible="true"/>
    </div>

    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>            
            <asp:TableCell>
                <asp:Label ID="Label1" runat="server" Text="ENTER USER ID"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" ID="txtLoginID"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell> 
                <asp:Button runat="server" ID="btnLogin" OnClick="btnLogin_Click" Text="Login"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button runat="server" ID="btnSignUp" Text="Sign Up" OnClick="btnSignUp_Click"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label runat="server" ID="lblErrorMsg" Visible="false"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <%--<logCtrl:LoginControl runat="server" ID="loginCtrl" visible="true"></logCtrl:LoginControl>--%>
</asp:Content>